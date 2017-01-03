using System;
using System.Threading.Tasks;
using NLog;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Services.WardenChecks.Services;
using Warden.Services.WardenChecks.Shared.Commands;
using Warden.Services.WardenChecks.Shared.Events;

namespace Warden.Services.WardenChecks.Handlers
{
    public class ProcessWardenCheckResultHandler : ICommandHandler<ProcessWardenCheckResult>
    {
        private readonly static ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly IBusClient _bus;
        private readonly IWardenCheckService _wardenCheckService;
        private readonly IWardenCheckStorage _wardenCheckStorage;

        public ProcessWardenCheckResultHandler(IBusClient bus,
            IWardenCheckService wardenCheckService,
            IWardenCheckStorage wardenCheckStorage)
        {
            _bus = bus;
            _wardenCheckService = wardenCheckService;
            _wardenCheckStorage = wardenCheckStorage;
        }

        public async Task HandleAsync(ProcessWardenCheckResult command)
        {
            //TODO: Fix createdAt date in command.
            var createdAt = DateTime.UtcNow;
            var checkResult = _wardenCheckService.ValidateAndParseResult(command.UserId,
                command.OrganizationId, command.WardenId, command.Check, createdAt);
            if (checkResult.HasNoValue)
            {
                Logger.Warn($"Warden check result for Warden with id: '{command.WardenId}' is invalid.");

                return;
            }

            Logger.Info($"Saving check result for Warden with id: '{command.WardenId}'.");
            await _wardenCheckStorage.SaveAsync(checkResult.Value);
            await _bus.PublishAsync(new WardenCheckResultProcessed(command.Request.Id, command.UserId,
                command.OrganizationId, command.WardenId, checkResult.Value.Result, createdAt));
        }
    }
}
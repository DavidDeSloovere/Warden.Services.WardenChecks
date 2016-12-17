using System.Threading.Tasks;
using RawRabbit;
using Warden.Common.Commands;
using Warden.Services.WardenChecks.Services;
using Warden.Services.WardenChecks.Shared.Commands;
using Warden.Services.WardenChecks.Shared.Events;

namespace Warden.Services.WardenChecks.Handlers
{
    public class ProcessWardenCheckResultHandler : ICommandHandler<ProcessWardenCheckResult>
    {
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
            var rootResult = _wardenCheckService.ValidateAndParseResult(command.UserId,
                command.OrganizationId, command.WardenId, command.Check, command.CreatedAt);
            if (rootResult.HasNoValue)
                return;

            await _wardenCheckStorage.SaveAsync(rootResult.Value);
            await _bus.PublishAsync(new WardenCheckResultProcessed(command.Request.Id, command.UserId,
                command.OrganizationId, command.WardenId, rootResult.Value.Result, command.CreatedAt));
        }
    }
}
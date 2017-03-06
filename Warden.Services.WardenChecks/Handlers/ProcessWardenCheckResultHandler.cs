using System.Threading.Tasks;
using AutoMapper;
using RawRabbit;
using Warden.Messages.Commands;
using Warden.Common.Handlers;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Services;
using Warden.Messages.Commands.WardenChecks;
using Warden.Services.WardenChecks.Dto;
using Warden.Messages.Events.WardenChecks;

namespace Warden.Services.WardenChecks.Handlers
{
    public class ProcessWardenCheckResultHandler : ICommandHandler<ProcessWardenCheckResult>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IWardenCheckService _wardenCheckService;
        private readonly IMapper _mapper;

        public ProcessWardenCheckResultHandler(IHandler handler, 
            IBusClient bus,
            IWardenCheckService wardenCheckService,
            IMapper mapper)
        {
            _handler = handler;
            _bus = bus;
            _wardenCheckService = wardenCheckService;
            _mapper = mapper;
        }

        public async Task HandleAsync(ProcessWardenCheckResult command)
        {
            CheckResult checkResult = null;
            await _handler
                .Run(async () => {
                    checkResult = _wardenCheckService.ValidateAndParseResult(command.UserId,
                    command.OrganizationId, command.WardenId, command.Check);
                    await _wardenCheckService.SaveAsync(checkResult);
                })
                .OnSuccess(async () => await _bus.PublishAsync(new WardenCheckResultProcessed(command.Request.Id, 
                    command.UserId, command.OrganizationId, command.WardenId, 
                    _mapper.Map<CheckResult, CheckResultDto>(checkResult))))
                .OnCustomError(async ex => await _bus.PublishAsync(new ProcessWardenCheckResultRejected(command.Request.Id,
                    command.UserId, ex.Code, ex.Message)))
                .OnError(async (ex, logger) =>
                {
                    logger.Error("Error occured while processing Warden check result.");
                    await _bus.PublishAsync(new ProcessWardenCheckResultRejected(command.Request.Id,
                        command.UserId, OperationCodes.Error, ex.Message));
                })
                .ExecuteAsync();
        }
    }
}
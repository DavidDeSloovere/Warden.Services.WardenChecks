using System.Threading.Tasks;
using RawRabbit;
using Warden.Messages.Events;
using Warden.Common.Handlers;
using Warden.Messages.Events.Organizations;
using Warden.Services.WardenChecks.Services;

namespace Warden.Services.WardenChecks.Handlers
{
    public class WardenCreatedHandler : IEventHandler<WardenCreated>
    {
        private readonly IWardenService _wardenService;
        private readonly IHandler _handler;
        private readonly IBusClient _bus;

        public WardenCreatedHandler(IHandler handler, 
            IBusClient bus,
            IWardenService wardenService)
        {
            _handler = handler;
            _bus = bus;
            _wardenService = wardenService;
        }

        public async Task HandleAsync(WardenCreated @event)
        {
            await _handler
                .Run(async () => await _wardenService.CreateWardenAsync(@event.WardenId,
                    @event.Name, @event.OrganizationId, @event.UserId, @event.Enabled))
                .OnError((ex, logger) => logger.Error("Error occured while creating a Warden."))
                .ExecuteAsync();
        }
    }
}
using System.Threading.Tasks;
using RawRabbit;
using Warden.Messages.Events;
using Warden.Common.Handlers;
using Warden.Messages.Events.Organizations;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Repositories;

namespace Warden.Services.WardenChecks.Handlers
{
    public class OrganizationCreatedHandler : IEventHandler<OrganizationCreated>
    {
        private readonly IHandler _handler;
        private readonly IBusClient _bus;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationCreatedHandler(IHandler handler, 
            IBusClient bus,
            IOrganizationRepository organizationRepository)
        {
            _handler = handler;
            _bus = bus;
            _organizationRepository = organizationRepository;
        }

        public async Task HandleAsync(OrganizationCreated @event)
        {
            await _handler
                .Run(async () => await _organizationRepository.AddAsync(
                    new Organization(@event.OrganizationId, @event.Name, @event.UserId)))
                .OnError((ex, logger) => logger.Error("Error occured while creating an Organization."))
                .ExecuteAsync();
        }
    }
}
﻿using System.Threading.Tasks;
using Warden.Common.Events;
using Warden.Services.Organizations.Shared.Events;
using Warden.Services.WardenChecks.Services;

namespace Warden.Services.WardenChecks.Handlers
{
    public class WardenCreatedHandler : IEventHandler<WardenCreated>
    {
        private readonly IWardenService _wardenService;

        public WardenCreatedHandler(IWardenService wardenService)
        {
            _wardenService = wardenService;
        }

        public async Task HandleAsync(WardenCreated @event)
        {
            await _wardenService.CreateWardenAsync(@event.WardenId,
                @event.Name, @event.OrganizationId, @event.UserId,
                @event.Enabled);
        }
    }
}
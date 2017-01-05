using System;
using Warden.Common.Domain;

namespace Warden.Services.WardenChecks.Domain
{
    public class CheckResult : IdentifiableEntity
    {
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid WardenId { get; set; }
        public DateTime CreatedAt { get; set; }
        public object Result { get; set; }
    }
}
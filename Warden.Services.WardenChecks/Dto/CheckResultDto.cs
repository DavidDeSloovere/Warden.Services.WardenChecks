using System;

namespace Warden.Services.WardenChecks.Dto
{
    public class CheckResultDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid WardenId { get; set; }
        public DateTime CreatedAt { get; set; }
        public WardenCheckResultDto Result { get; set; }
    }
}
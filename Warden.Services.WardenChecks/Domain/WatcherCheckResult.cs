using Warden.Common.Domain;

namespace Warden.Services.WardenChecks.Domain
{
    public class WatcherCheckResult : IValidatable
    {
        public string WatcherName { get; set; }
        public string WatcherGroup { get; set; }
        public string WatcherType { get; set; }
        public string WatcherFullType { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
    }
}
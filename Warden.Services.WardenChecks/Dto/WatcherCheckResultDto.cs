namespace Warden.Services.WardenChecks.Dto
{
    public class WatcherCheckResultDto
    {
        public string WatcherName { get; set; }
        public string WatcherGroup { get; set; }
        public string WatcherType { get; set; }
        public string WatcherFullType { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
        public object Data { get; set; }
    }
}
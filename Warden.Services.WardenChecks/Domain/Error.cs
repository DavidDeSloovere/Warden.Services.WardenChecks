namespace Warden.Services.WardenChecks.Domain
{
    public class Error
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Level { get; set; }
    }
}
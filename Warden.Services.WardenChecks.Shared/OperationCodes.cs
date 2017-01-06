namespace Warden.Services.WardenChecks.Shared
{
    public static class OperationCodes
    {
        public static string Success => "success";
        public static string EmptyWardenCheckResult => "empty_warden_check_result";
        public static string EmptyWatcherCheckResult => "empty_watcher_check_result";
        public static string EmptyWatcherName => "empty_watcher_name";
        public static string EmptyWatcherType => "empty_watcher_type";
        public static string Error => "error";
    }
}
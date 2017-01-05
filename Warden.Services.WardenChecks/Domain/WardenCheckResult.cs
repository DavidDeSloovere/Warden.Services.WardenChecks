using System;
using System.Collections.Generic;
using Warden.Common.Domain;

namespace Warden.Services.WardenChecks.Domain
{
    public class WardenCheckResult : IValidatable, ICompletable
    {
        private ISet<Error> _errors = new HashSet<Error>();

        public bool IsValid { get; set; }
        public WatcherCheckResult WatcherCheckResult { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public long ExecutionTimeTicks { get; set; }

        public IEnumerable<Error> Errors
        {
            get { return _errors; }
            protected set { _errors = new HashSet<Error>(value); }
        }
    }
}
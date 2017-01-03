using MongoDB.Driver;
using Warden.Common.Mongo;
using Warden.Services.WardenChecks.Domain;

namespace Warden.Services.WardenChecks.Repositories.Queries
{
    public static class CheckResultQueries
    {
        public static IMongoCollection<CheckResult> CheckResults(this IMongoDatabase database)
            => database.GetCollection<CheckResult>();
    }
}
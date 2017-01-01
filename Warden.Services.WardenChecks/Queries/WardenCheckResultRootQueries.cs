using MongoDB.Driver;
using Warden.Common.Mongo;
using Warden.Services.WardenChecks.Domain;

namespace Warden.Services.WardenChecks.Queries
{
    public static class WardenCheckResultRootQueries
    {
        public static IMongoCollection<WardenCheckResultRoot> WardenCheckResultRoots(this IMongoDatabase database)
            => database.GetCollection<WardenCheckResultRoot>();
    }
}
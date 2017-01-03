using System.Threading.Tasks;
using MongoDB.Driver;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Repositories.Queries;

namespace Warden.Services.WardenChecks.Repositories
{
    public class CheckResultRepository : ICheckResultRepository
    {
        private readonly IMongoDatabase _database;

        public CheckResultRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(CheckResult checkResult)
            => await _database.CheckResults().InsertOneAsync(checkResult);
    }
}
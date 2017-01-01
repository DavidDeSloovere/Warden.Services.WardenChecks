using System.Threading.Tasks;
using MongoDB.Driver;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Queries;

namespace Warden.Services.WardenChecks.Repositories
{
    public class WardenCheckResultRootRepository : IWardenCheckResultRootRepository
    {
        private readonly IMongoDatabase _database;

        public WardenCheckResultRootRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(WardenCheckResultRoot checkResult)
            => await _database.WardenCheckResultRoots().InsertOneAsync(checkResult);
    }
}
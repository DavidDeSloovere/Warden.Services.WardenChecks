using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Warden.Common.Mongo;
using Warden.Common.Types;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Queries;

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
            => await Collection.InsertOneAsync(checkResult);

        public async Task<Maybe<PagedResult<CheckResult>>> BrowseAsync(BrowseCheckResults query)
        {
            var values = Collection.AsQueryable();

            values = values.OrderBy(x => x.CreatedAt);

            return await values.PaginateAsync(query);
        }

        private IMongoCollection<CheckResult> Collection => _database.GetCollection<CheckResult>();
    }
}
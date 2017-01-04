using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Queries;

namespace Warden.Services.WardenChecks.Repositories
{
    public interface ICheckResultRepository
    {
        Task AddAsync(CheckResult checkResult);
        Task<Maybe<PagedResult<CheckResult>>> BrowseAsync(BrowseCheckResults query);
    }
}
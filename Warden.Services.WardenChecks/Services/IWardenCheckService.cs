using System;
using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Queries;

namespace Warden.Services.WardenChecks.Services
{
    public interface IWardenCheckService
    {
        CheckResult ValidateAndParseResult(string userId,
            Guid organizationId, Guid wardenId, object checkResult);

        Task SaveAsync(CheckResult checkResult);

        Task<Maybe<PagedResult<CheckResult>>> BrowseAsync(BrowseCheckResults query);
    }
}
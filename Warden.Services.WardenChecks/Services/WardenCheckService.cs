using System;
using Newtonsoft.Json;
using Warden.Services.WardenChecks.Domain;
using Warden.Common.Extensions;
using Warden.Common.Exceptions;
using Warden.Services.WardenChecks;
using Warden.Services.WardenChecks.Repositories;
using System.Threading.Tasks;
using Warden.Common.Types;
using Warden.Services.WardenChecks.Queries;
using System.Linq;

namespace Warden.Services.WardenChecks.Services
{
    public class WardenCheckService : IWardenCheckService
    {
        private readonly ICheckResultRepository _checkResultRepository;

        public WardenCheckService(ICheckResultRepository checkResultRepository)
        {
            _checkResultRepository = checkResultRepository;
        }

        public CheckResult ValidateAndParseResult(string userId, 
            Guid organizationId, Guid wardenId, object checkResult)
        {
            if (checkResult == null)
            {
                throw new ServiceException(OperationCodes.EmptyWardenCheckResult,
                    "Warden check result can not be null.");
            }

            var serializedResult = JsonConvert.SerializeObject(checkResult);
            var result = JsonConvert.DeserializeObject<WardenCheckResult>(serializedResult);
            ValidateCheckResult(result);
            result.WatcherCheckResult.WatcherFullType = result.WatcherCheckResult.WatcherType;
            if (result.WatcherCheckResult.WatcherType.Contains(","))
            {
                result.WatcherCheckResult.WatcherType = result.WatcherCheckResult.WatcherType
                    .Split(',').First()
                    .Split('.').LastOrDefault()
                    ?.TrimToLower()?.Replace("watcher", string.Empty);
            }

            return new CheckResult
            {
                UserId = userId,
                Result = result,
                WardenId = wardenId,
                OrganizationId = organizationId,
                CreatedAt = DateTime.UtcNow
            };
        }

        private void ValidateCheckResult(WardenCheckResult check)
        {
            if (check.WatcherCheckResult == null)
            {
                throw new ServiceException(OperationCodes.EmptyWatcherCheckResult,
                    "Watcher check result can not be null.");
            }
            if (check.WatcherCheckResult.WatcherName.Empty())
            {
                throw new ServiceException(OperationCodes.EmptyWatcherName,
                    "Watcher name can not be empty.");
            }
            if (check.WatcherCheckResult.WatcherType.Empty())
            {
                throw new ServiceException(OperationCodes.EmptyWatcherType,
                    "Watcher type can not be empty.");
            }
        }

        public async Task SaveAsync(CheckResult checkResult)
            => await _checkResultRepository.AddAsync(checkResult);

        public async Task<Maybe<PagedResult<CheckResult>>> BrowseAsync(BrowseCheckResults query)
            => await _checkResultRepository.BrowseAsync(query);
    }
}
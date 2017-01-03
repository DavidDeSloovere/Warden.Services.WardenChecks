using System.Threading.Tasks;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Repositories;

namespace Warden.Services.WardenChecks.Services
{
    public class WardenCheckStorage : IWardenCheckStorage
    {
        private readonly ICheckResultRepository _checkResultRepository;

        public WardenCheckStorage(ICheckResultRepository checkResultRepository)
        {
            _checkResultRepository = checkResultRepository;
        }

        public async Task SaveAsync(CheckResult checkResult)
            => await _checkResultRepository.AddAsync(checkResult);
    }
}
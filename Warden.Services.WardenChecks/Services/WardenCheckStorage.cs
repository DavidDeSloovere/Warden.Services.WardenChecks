using System.Threading.Tasks;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Repositories;

namespace Warden.Services.WardenChecks.Services
{
    public class WardenCheckStorage : IWardenCheckStorage
    {
        private readonly IWardenCheckResultRootRepository _wardenCheckResultRootRepository;

        public WardenCheckStorage(IWardenCheckResultRootRepository wardenCheckResultRootRepository)
        {
            _wardenCheckResultRootRepository = wardenCheckResultRootRepository;
        }

        public async Task SaveAsync(WardenCheckResultRoot checkResult)
            => await _wardenCheckResultRootRepository.AddAsync(checkResult);
    }
}
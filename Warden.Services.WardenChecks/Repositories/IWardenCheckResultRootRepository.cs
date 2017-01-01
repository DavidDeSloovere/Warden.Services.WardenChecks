using System.Threading.Tasks;
using Warden.Services.WardenChecks.Domain;

namespace Warden.Services.WardenChecks.Repositories
{
    public interface IWardenCheckResultRootRepository
    {
        Task AddAsync(WardenCheckResultRoot checkResult);         
    }
}
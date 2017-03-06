using AutoMapper;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Queries;
using Warden.Services.WardenChecks.Services;
using Warden.Services.WardenChecks.Dto;

namespace Warden.Services.WardenChecks.Modules
{
    public class CheckResultModule : ModuleBase
    {
        public CheckResultModule(IWardenCheckService wardenCheckService, IMapper mapper) : base(mapper, "checks")
        {
            Get("", async args => await FetchCollection<BrowseCheckResults, CheckResult>
                (async x => await wardenCheckService.BrowseAsync(x))
                .MapTo<CheckResultDto>()
                .HandleAsync());
        }
    }
}
using AutoMapper;
using Warden.Services.WardenChecks.Domain;
using Warden.Services.WardenChecks.Dto;

namespace Warden.Services.WardenChecks.Framework
{
    public class AutoMapperConfig
    {
        public static IMapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CheckResult, CheckResultDto>();
                cfg.CreateMap<WardenCheckResult, WardenCheckResultDto>();
                cfg.CreateMap<WatcherCheckResult, WatcherCheckResultDto>();
                cfg.CreateMap<Error, ErrorDto>();
            });

            return config.CreateMapper();
        }        
    }
}
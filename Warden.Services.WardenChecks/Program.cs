using Warden.Common.Host;
using Warden.Messages.Events.Organizations;
using Warden.Services.WardenChecks.Framework;
using Warden.Messages.Commands.WardenChecks;

namespace Warden.Services.WardenChecks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceHost
                .Create<Startup>(port: 5053)
                .UseAutofac(Bootstrapper.LifetimeScope)
                .UseRabbitMq(queueName: typeof(Program).Namespace)
                .SubscribeToCommand<ProcessWardenCheckResult>()
                .SubscribeToEvent<OrganizationCreated>()
                .SubscribeToEvent<WardenCreated>()
                .Build()
                .Run();
        }
    }
}

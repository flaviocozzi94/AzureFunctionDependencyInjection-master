using AzureFunctionDependencyInjection;
using AzureFunctionDependencyInjection.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunctionDependencyInjection
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Registering Configurations (IOptions pattern)
            //builder
            //    .Services
            //.AddOptions<MessageResponderConfiguration>()
            //.Configure<IConfiguration>((messageResponderSettings, configuration) =>
            //{
            //    configuration
            //    .GetSection("MessageResponder")
            //    .Bind(messageResponderSettings);
            //});

            // Registering Serilog provider
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Warning()
                //.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Services.AddLogging(lb => lb.AddSerilog(logger));

            // Registering services
            builder
                .Services
                .AddSingleton<IMessageResponderService, MessageResponderService>();
        }
    }
}
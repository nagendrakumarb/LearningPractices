using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace kafka.pubsub.consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // Add configuration sources (e.g., appsettings.json, environment variables, etc.)
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                    // You can add more configuration sources as needed
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.ClearProviders(); // Clear any existing logging providers
                    logging.AddConsole(); // Add Console logging
                })
                .ConfigureServices((hostContext, services) =>
                {
                    // Configure services
                    services.AddOptions<KafkaConsumerSettings>() // Add options for KafkaSettings
                            .Bind(hostContext.Configuration.GetSection("KafkaSettings")); // Bind configuration to KafkaSettings
                
                    services.AddHostedService<KafkaConsumerWorker>();
                });
    }
}

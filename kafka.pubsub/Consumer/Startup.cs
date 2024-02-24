using Microsoft.Extensions.DependencyInjection;

namespace kafka.pubsub.consumer
{
    // Startup.cs
  
    public class Startup
    {
        // ... (existing code)

        public void ConfigureServices(IServiceCollection services)
        {
            // ... (existing services)

            // Add Kafka consumer worker service
            services.AddHostedService<KafkaConsumerWorker>();
        }

        // ... (existing code)
    }

}

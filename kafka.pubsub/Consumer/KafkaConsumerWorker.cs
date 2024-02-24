using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
namespace kafka.pubsub.consumer
{
    // KafkaConsumerWorker.cs
   

    public class KafkaConsumerWorker : BackgroundService
    {
        private readonly KafkaConsumerSettings _kafkaSettings;
        private readonly IConsumer<Ignore, string> _consumer;

        public KafkaConsumerWorker(IOptions<KafkaConsumerSettings> kafkaSettingsOptions)
        {
            _kafkaSettings = kafkaSettingsOptions.Value;

            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaSettings.BootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                BrokerAddressFamily = BrokerAddressFamily.V4,
                GroupId = _kafkaSettings.GroupId,
                Debug = _kafkaSettings.Debug,
                ClientId = Dns.GetHostName(),
            };

            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            _consumer.Subscribe(_kafkaSettings.Topics);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);
                    await ProcessMessageAsync(consumeResult);
                }
                catch (OperationCanceledException)
                {
                    _consumer.Close();
                }
            }
        }

        private async Task ProcessMessageAsync(ConsumeResult<Ignore, string> consumeResult)
        {
            // Process the Kafka message asynchronously
            Console.WriteLine($"Message received from {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");

            // You can add your own logic here to handle the message
            // For example, you might want to perform some asynchronous processing.
            await Task.Delay(100); // Simulate some asynchronous processing time
        }
    }

}

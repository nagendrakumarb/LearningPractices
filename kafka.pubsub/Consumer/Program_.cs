using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace kafka.pubsub.consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The Kafka endpoint address
            // The Kafka endpoint address
            string kafkaEndpoint = "LDPA-SasiPasi-505:9092";

            // The Kafka topic we'll be using

            // The Kafka topic we'll be using
             List<string> kafkaTopics = new List<string>() { "testtopic" };
            var cts = new CancellationTokenSource();
            // Create the producer configuration
            //var producerConfig = new Dictionary<string, object> { { "bootstrap.servers", kafkaEndpoint } };
            var config = new ConsumerConfig()
            {
                BootstrapServers = kafkaEndpoint,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                BrokerAddressFamily = BrokerAddressFamily.V4,
                GroupId = "testtopic_group",
                Debug = "consumer", // Enable consumer debugging.
                ClientId = Dns.GetHostName(),
            };


            try
            {
                using (var consumerBuilder = new ConsumerBuilder
                <Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(kafkaTopics[0]);
                    var cancelToken = new CancellationTokenSource();

                    try
                    {
                        while (true)
                        {
                            var consumeResult = consumerBuilder.Consume(cancelToken.Token    );
                            Console.WriteLine($"Message received from {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
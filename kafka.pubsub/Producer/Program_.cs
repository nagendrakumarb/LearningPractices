using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace kafka.pubsub.producer
{
    class Program_
    {
        static string kafkaEndpoint = "LDPA-SasiPasi-505:9092";
        static List<string> kafkaTopics = new List<string>() { "testtopic" };

        static async Task Main(string[] args)
        {
            await CreateNewTopics(kafkaTopics);
            var cts = new CancellationTokenSource();

            var config = new ProducerConfig()
            {
                BootstrapServers = kafkaEndpoint,
                BrokerAddressFamily = BrokerAddressFamily.V4,
                ClientId = Dns.GetHostName(),
            };

            using var _producer = new ProducerBuilder<Null, string>(config).Build();

            Console.WriteLine("Enter messages to send (or type 'cancel' to exit):");

            while (true)
            {
                var messageInput = Console.ReadLine();

                if (messageInput.ToLower() == "cancel")
                {
                    Console.WriteLine("Message sending canceled.");
                    break;
                }

                var message = new Message<Null, string>
                {
                    Value = messageInput
                };

                var deliveryReport = await _producer.ProduceAsync(kafkaTopics[0], message);
                Console.WriteLine($"Message sent on Partition: {deliveryReport.Partition} with Offset: {deliveryReport.Offset}");
            }

            _producer.Flush(new TimeSpan(10));
        }

        static async Task CreateNewTopics(List<string> topicsToCreate)
        {
            var adminConfig = new AdminClientConfig
            {
                BootstrapServers = kafkaEndpoint
            };

            using (var adminClient = new AdminClientBuilder(adminConfig).Build())
            {
                foreach (var topic in topicsToCreate)
                {
                    var topicMetadata = adminClient.GetMetadata(topic, new TimeSpan(0, 5, 0));

                    if (topicMetadata.Topics.Count == 0)
                    {
                        var topicSpecification = new TopicSpecification
                        {
                            Name = topic,
                            NumPartitions = 1,
                            ReplicationFactor = 1,
                        };

                        await adminClient.CreateTopicsAsync(new[] { topicSpecification });
                        Console.WriteLine($"Topic '{topic}' created.");
                    }
                    else
                    {
                        Console.WriteLine($"Topic '{topic}' already exists.");
                    }
                }
            }
        }
    }
}

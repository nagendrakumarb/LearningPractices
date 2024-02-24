using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using kafka.pubsub.producer;
using static TopicManagementMiddlewareHelpers;
using Microsoft.Extensions.Options;

namespace KafkaPubSubProducer
{
    public class Program
    {

        internal static ProducerConfig producerConfig;
        internal static IConfiguration configuration = null;
        internal static KafkaProducerSettings kafkaSettings = null;
        internal static Dictionary<string, TopicSpecification> _topicConfigurations;
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            configuration = host.Services.GetRequiredService<IConfiguration>();
            kafkaSettings = new KafkaProducerSettings();
            configuration.GetSection("KafkaSettings").Bind(kafkaSettings);
            _topicConfigurations = DeserializeTopicSpecificationTopics(TopicManagementMiddlewareHelpers.FilePath);
            producerConfig = new ProducerConfig
            {
                BootstrapServers = kafkaSettings.Server
            };

            var SetupTheTopics = SetupTopics();
            var processCycleTask = ProcessCycle();
            await Task.WhenAll( host.RunAsync(), SetupTheTopics, processCycleTask);
        }

        private static async Task SetupTopics()
        {
            // Introduce a delay before creating topics
            //await Task.Delay(TimeSpan.FromSeconds(20)); // Adjust the delay time as needed

            //Load topics from topics.json
            Dictionary<string, TopicConfiguration> topics = DeserializeTopicConfiguration(TopicManagementMiddlewareHelpers.FilePath);

            foreach (var topic in topics)
            {
                await CreateTopicIfNotExists(topic.Value.Name); // Pass each topic to CreateTopicIfNotExists
            }
        }

        private static async Task CreateTopicIfNotExists(string newTopic)
        {

          
            using (var httpClient = new HttpClient())
            {


                var content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("action", "create"),
                new KeyValuePair<string, string>("topic", newTopic)
            });

                var response = await httpClient.PostAsync("http://localhost:54241/create", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Topic '{newTopic}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to create topic '{newTopic}'. Status code: {response.StatusCode}");
                }
            }

        }
        public static async Task CreateTopic()
        {
            using (var httpClient = new HttpClient())
            {
                Console.Write("Enter the name of the topic to create: ");
                var newTopic = Console.ReadLine();

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "create"),
                    new KeyValuePair<string, string>("topic", newTopic)
                });

                var response = await httpClient.PostAsync("http://localhost:54241/create", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Topic '{newTopic}' created successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to create topic '{newTopic}'. Status code: {response.StatusCode}");
                }
            }
        }
        public static async Task ProcessCycle()
        {
            await Task.Delay(TimeSpan.FromSeconds(10)); // Adjust the delay time as needed
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("0. Send message");
                Console.WriteLine("1. Create topic");
                Console.WriteLine("2. Update topic");
                Console.WriteLine("3. Patch topic");
                Console.WriteLine("4. Delete topic");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        await Send();
                        break;
                    case "1":
                        await CreateTopic();
                        break;
                    case "2":
                        await UpdateTopic();
                        break;
                    case "3":
                        await PatchTopic();
                        break;
                    case "4":
                        await DeleteTopic();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static async Task Send()
        {
            Console.Write("Enter Topic to send: ");
            var topic = Console.ReadLine();
            Console.Write("Enter message to send: ");
            var message = Console.ReadLine();

            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "send"),
                        new KeyValuePair<string, string>("topic", topic),
                    new KeyValuePair<string, string>("message", message)
                });

                var response = await httpClient.PostAsync("http://localhost:54241/send", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Message sent to Kafka.");
                }
                else
                {
                    Console.WriteLine($"Failed to send message. Status code: {response.StatusCode}");
                }
            }
        }

        public static async Task UpdateTopic()
        {
            using (var httpClient = new HttpClient())
            {
                Console.Write("Enter topic to update: ");
                var topic = Console.ReadLine();
                Console.WriteLine("Enter new Partitions to update: ");
                var newPartitions = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new ReplicationFactor to update: ");
                var newReplicationFactor = short.Parse(Console.ReadLine());

                var content = new FormUrlEncodedContent(new[]
                {
                    
                    new KeyValuePair<string, string>("action", "update"),
                    new KeyValuePair<string, string>("topic", topic),
                    new KeyValuePair<string, string>("partitions", newPartitions.ToString()),
                    new KeyValuePair<string, string>("replicationFactor", newReplicationFactor.ToString())
                });

                var response = await httpClient.PostAsync("http://localhost:54241/update", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Topic '{topic}' updated with {newPartitions} partitions and replication factor {newReplicationFactor}.");
                }
                else
                {
                    Console.WriteLine($"Failed to update topic '{topic}'. Status code: {response.StatusCode}");
                }
            }
        }

        public static async Task PatchTopic()
        {
            using (var httpClient = new HttpClient())
            {
                Console.Write("Enter topic to patch: ");
                var topic = Console.ReadLine();
                Console.Write("Enter new configuration: ");
                var newConfiguration = Console.ReadLine();

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "patch"),
                    new KeyValuePair<string, string>("topic", topic),
                    new KeyValuePair<string, string>("newConfiguration", newConfiguration)
                });

                var response = await httpClient.PostAsync("http://localhost:54241/patch", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Topic '{topic}' patched with new configuration: {newConfiguration}.");
                }
                else
                {
                    Console.WriteLine($"Failed to patch topic '{topic}'. Status code: {response.StatusCode}");
                }
            }
        }

        public static async Task DeleteTopic()
        {
            using (var httpClient = new HttpClient())
            {
                Console.Write("Enter topic to delete: ");
                var topic = Console.ReadLine();

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "delete"),
                    new KeyValuePair<string, string>("topic", topic)
                });

                var response = await httpClient.PostAsync("http://localhost:54241/delete", content); // Replace with your actual URL

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Topic '{topic}' deleted.");
                }
                else
                {
                    Console.WriteLine($"Failed to delete topic '{topic}'. Status code: {response.StatusCode}");
                }
            }
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostContext, config) =>
               {
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHttpContextAccessor();
                   services.Configure<KafkaProducerSettings>(hostContext.Configuration.GetSection("KafkaSettings"));

                   services.AddSingleton<IProducer<Null, string>>(provider =>
                   {
                       var kafkaSettings = provider.GetRequiredService<IOptions<KafkaProducerSettings>>().Value;
                       var producerConfig = new ProducerConfig
                       {
                           BootstrapServers = kafkaSettings.Server
                       };
                       return new ProducerBuilder<Null, string>(producerConfig).Build();
                   });
                   // Register Kafka producer
                   services.AddSingleton<IProducer<Null, byte[]>>(provider =>
                   {
                       var producerConfig = new ProducerConfig
                       {
                           BootstrapServers = kafkaSettings.Server
                           // Configure other producer settings here
                       };

                       return new ProducerBuilder<Null, byte[]>(producerConfig).Build();
                   });
                   services.AddSingleton< IAdminClient>(provider =>
                   {
                       var kafkaSettings = provider.GetRequiredService<IOptions<KafkaProducerSettings>>().Value;
                       var adminConfig = new AdminClientConfig
                       {
                           BootstrapServers = kafkaSettings.Server
                       };
                       return new AdminClientBuilder(adminConfig).Build();
                   });

                   services.AddSingleton<SenderMiddleware>();
                   services.AddSingleton<TopicManagementMiddleware>();
               })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.Configure(app =>
                   {
                       app.UseRouting();

                       app.UseEndpoints(endpoints =>
                       {
                           endpoints.MapPost("/send", async context =>
                           {
                               var message = context.Request.Form["message"];
                               using (var scope = app.ApplicationServices.CreateScope())
                               {
                                   var senderMiddleware = scope.ServiceProvider.GetRequiredService<SenderMiddleware>();
                                   await senderMiddleware.Invoke(context);
                               }
                               await context.Response.WriteAsync("Message sent to Kafka.");
                           });

                           endpoints.MapPost("/update", async context =>
                           {
                               using (var scope = app.ApplicationServices.CreateScope())
                               {
                                   var topicManagementMiddleware = scope.ServiceProvider.GetRequiredService<TopicManagementMiddleware>();
                                   await topicManagementMiddleware.Invoke(context);
                               }
                           });

                           endpoints.MapPost("/patch", async context =>
                           {
                               using (var scope = app.ApplicationServices.CreateScope())
                               {
                                   var topicManagementMiddleware = scope.ServiceProvider.GetRequiredService<TopicManagementMiddleware>();
                                   await topicManagementMiddleware.Invoke(context);
                               }
                           });

                           endpoints.MapPost("/delete", async context =>
                           {
                               using (var scope = app.ApplicationServices.CreateScope())
                               {
                                   var topicManagementMiddleware = scope.ServiceProvider.GetRequiredService<TopicManagementMiddleware>();
                                   await topicManagementMiddleware.Invoke(context);
                               }
                           });

                           endpoints.MapPost("/create", async context =>
                           {
                               using (var scope = app.ApplicationServices.CreateScope())
                               {
                                   var topicManagementMiddleware = scope.ServiceProvider.GetRequiredService<TopicManagementMiddleware>();
                                   await topicManagementMiddleware.Invoke(context);
                               }
                           });
                       });
                   });
               });
    }

    // Define a class representing topic information
    public class TopicInfo
    {
        public string Name { get; set; }
        public int NumPartitions { get; set; }
        public short ReplicationFactor { get; set; }
    }
}

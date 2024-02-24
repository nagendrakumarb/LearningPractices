using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.AspNetCore.Http;
using static TopicManagementMiddlewareHelpers;
namespace KafkaPubSubProducer
{
    public partial class TopicManagementMiddleware
    {
        private readonly IAdminClient _adminClient;


        public TopicManagementMiddleware(IAdminClient adminClient)
        {
            _adminClient = adminClient ?? throw new ArgumentNullException(nameof(adminClient));

        }

        public async Task Invoke(HttpContext context)
        {
            var action = context.Request.Form["action"].ToString().ToLowerInvariant();
            var topic = context.Request.Form["topic"];

            switch (action)
            {
                case "create":
                    await CreateTopicAsync(topic);
                    await context.Response.WriteAsync($"Topic '{topic}' created.");
                    break;
                case "update":
                    var partitions = int.Parse(context.Request.Query["partitions"]);
                    var replicationFactor = short.Parse(context.Request.Query["replicationFactor"]);
                    await UpdateTopicAsync(topic, partitions, replicationFactor);
                    await context.Response.WriteAsync($"Topic '{topic}' updated with {partitions} partitions and replication factor {replicationFactor}.");
                    break;
                case "patch":
                    var newConfiguration = context.Request.Query["newConfiguration"];
                    await PatchTopicAsync(topic, newConfiguration);
                    await context.Response.WriteAsync($"Topic '{topic}' patched with new configuration: {newConfiguration}.");
                    break;
                case "delete":
                    await DeleteTopicAsync(topic);
                    await context.Response.WriteAsync($"Topic '{topic}' deleted.");
                    break;
                default:
                    await context.Response.WriteAsync("Invalid action.");
                    break;
            }
        }

        private async Task CreateTopicAsync(string topic)
        {
            //if (IsTopictExists(topic) || _topicConfigurations.ContainsKey(topic))
            //    throw new InvalidOperationException($"Topic '{topic}' already exists.");

            var topicSpecification = new TopicSpecification
            {
                Name = topic,
                NumPartitions = 1,
                ReplicationFactor = 1,
            };

            try
            {
                await _adminClient.CreateTopicsAsync(new[] { topicSpecification });

                _topicConfigurations.Add(topic, new TopicSpecification
                {
                    Name = topic,
                    NumPartitions = 1, // Default value for new topic
                    ReplicationFactor = 1 // Default value for new topic
                }); // Add to configurations
                UpdateTopicsJsonFile(topic, isAdding: true); // Update JSON file
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error creating topic '{topic}': {ex.Message}");
              //  throw; // Rethrow the exception
            }
        }
        private bool IsTopictExists(string topic)
        {
            var topicMetadata = _adminClient.GetMetadata(topic, TimeSpan.FromSeconds(5));
            return topicMetadata.Topics.Count == 0;
        }
        private async Task UpdateTopicAsync(string topic, int newPartitions, short newReplicationFactor)
        {
            if (!(IsTopictExists(topic) || _topicConfigurations.ContainsKey(topic)))
                throw new InvalidOperationException($"Topic '{topic}' does not exist.");

            _topicConfigurations[topic] = new TopicSpecification
            {
                NumPartitions = newPartitions,
                ReplicationFactor = newReplicationFactor
            };

            var topicSpecification = new TopicSpecification
            {
                Name = topic,
                NumPartitions = newPartitions,
                ReplicationFactor = newReplicationFactor
            };

            try
            {
                await _adminClient.CreateTopicsAsync(new List<TopicSpecification> { topicSpecification });

                UpdateTopicsJsonFile(topic, isAdding: false);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error updating topic '{topic}': {ex.Message}");
                throw; // Rethrow the exception
            }
        }

        private async Task PatchTopicAsync(string topic, string newConfiguration)
        {
            // Logic for patching topic configuration goes here
            // For example, using AdminClient.AlterConfigsAsync method
        }

        private async Task DeleteTopicAsync(string topic)
        {
            if (!(IsTopictExists(topic) || _topicConfigurations.ContainsKey(topic)))
                throw new InvalidOperationException($"Topic '{topic}' does not exist.");

            try
            {
                await _adminClient.DeleteTopicsAsync(new List<string> { topic });
                _topicConfigurations.Remove(topic);
                UpdateTopicsJsonFile(topic, isAdding: false);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error deleting topic '{topic}': {ex.Message}");
                throw; // Rethrow the exception
            }
        }




    }
}

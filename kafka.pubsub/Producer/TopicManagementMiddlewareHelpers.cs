using Confluent.Kafka.Admin;
using KafkaPubSubProducer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class TopicManagementMiddlewareHelpers
{
    public  const string FilePath = "app_data/topics.json";
    public static Dictionary<string, TopicSpecification> _topicConfigurations;

    static TopicManagementMiddlewareHelpers()
    {
        _topicConfigurations = new Dictionary<string, TopicSpecification>();
        _topicConfigurations = DeserializeTopicSpecificationTopics(FilePath);
    }
   
    public static Dictionary<string, TopicSpecification> DeserializeTopicSpecificationTopics( string jsonFilePath)
    {

        Dictionary<string, TopicConfiguration> topics = DeserializeTopicConfiguration(jsonFilePath);
        Dictionary<string, TopicSpecification> topicSpecifications = topics.ToDictionary(topic => topic.Key, item => new TopicSpecification()
        {
            Name = item.Value.Name,
            ReplicationFactor = item.Value.ReplicationFactor,
            NumPartitions = item.Value.NumPartitions,
        });
        return topicSpecifications;
    }

    public static Dictionary<string, TopicConfiguration> DeserializeTopicConfiguration(string jsonFilePath)
    {
        string json = File.ReadAllText(jsonFilePath);
        Dictionary<string, TopicConfiguration> topics = JsonSerializer.Deserialize<Dictionary<string, TopicConfiguration>>(json);
        if (topics == null)
        {
            throw new Exception("No topics found in the JSON file.");
        }

        return topics;
    }

    

    public static void UpdateTopicsJsonFile(string topicName, bool isAdding)
    {

        try
        {
            Dictionary<string, TopicConfiguration> topics= DeserializeTopicConfiguration(TopicManagementMiddlewareHelpers.FilePath);

            // Update the list of topics based on the operation
            if (isAdding)
            {
                topics.Add(topicName,  new TopicConfiguration()
                {
                    Name= _topicConfigurations[topicName].Name,
                    NumPartitions= _topicConfigurations[topicName].NumPartitions,
                    ReplicationFactor= _topicConfigurations[topicName].ReplicationFactor,
                });
            }
            else
            {
                topics.Remove(topicName);
            }

            // Write the updated list back to the JSON file
            var updatedJson = JsonSerializer.Serialize(topics, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(TopicManagementMiddlewareHelpers.FilePath, updatedJson);
            Console.WriteLine("Topics JSON file updated successfully.");
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error updating topics JSON file: {ex.Message}");
        }
    }



    //private static void UpdateTopicsJsonFile(string topicName, bool isAdding)
    //{

    //    try
    //    {
    //        List<TopicInfo> topics;
    //        if (File.Exists(TopicManagementMiddlewareHelpers.FilePath))
    //        {
    //            // Read existing topics from the JSON file
    //            var json = File.ReadAllText(TopicManagementMiddlewareHelpers.FilePath);
    //            topics = JsonSerializer.Deserialize<List<TopicInfo>>(json);
    //        }
    //        else
    //        {
    //            topics = new List<TopicInfo>();
    //        }

    //        // Update the list of topics based on the operation
    //        if (isAdding)
    //        {
    //            topics.Add(new TopicInfo { Name = topicName, NumPartitions = 1, ReplicationFactor = 1 });
    //        }
    //        else
    //        {
    //            topics.RemoveAll(t => t.Name == topicName);
    //        }

    //        // Write the updated list back to the JSON file
    //        var updatedJson = JsonSerializer.Serialize(topics, new JsonSerializerOptions { WriteIndented = true });
    //        File.WriteAllText(TopicManagementMiddlewareHelpers.FilePath, updatedJson);
    //        Console.WriteLine("Topics JSON file updated successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error updating topics JSON file: {ex.Message}");
    //    }
    //}

}
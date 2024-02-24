using Confluent.Kafka.Admin;
using System;
using System.Collections.Generic;
using System.Json;
using System.Text.Json;

namespace KafkaPubSubProducer
{
    public class CustomTopicSpecificationConverter : System.Text.Json.Serialization.JsonConverter<TopicSpecification>
    {
        public override TopicSpecification Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Parse the JSON document
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                // Get the root JSON element
                JsonElement root = document.RootElement;

                // Check if the ReplicasAssignments property exists
                if (root.TryGetProperty("ReplicasAssignments", out _))
                {
                    // Remove the ReplicasAssignments property
                    root = RemoveProperty(root, "ReplicasAssignments");
                }

                // Create a TopicSpecification instance
                return CreateTopicSpecification(root);
            }
        }

        private TopicSpecification CreateTopicSpecification(JsonElement root)
        {
            TopicSpecification topicSpecification = new TopicSpecification();

            // Assign properties dynamically
            foreach (var property in root.EnumerateObject())
            {
                if (property.Name != "ReplicasAssignments") // Ignore ReplicasAssignments property
                {
                    var value = GetValue(property.Value, GetPropertyType(topicSpecification, property.Name));
                    SetProperty(topicSpecification, property.Name, value);
                }
            }

            return topicSpecification;
        }

        private Type GetPropertyType(TopicSpecification topicSpecification, string propertyName)
        {
            return typeof(TopicSpecification).GetProperty(propertyName)?.PropertyType;
        }

        private object GetValue(JsonElement value, Type targetType)
        {
            // Add logic to handle different value types if needed
            switch (value.ValueKind)
            {
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.Number:
                    return GetNumberValue(value, targetType);
                case JsonValueKind.String:
                    return GetString(value, targetType);
                case JsonValueKind.Object:
                    // Handle object value if needed
                    break;
                case JsonValueKind.Array:
                    // Handle array value if needed
                    break;
                default:
                    // Handle other value kinds if necessary
                    break;
            }

            // Return default value if type not handled
            return null;
        }

        private object GetNumberValue(JsonElement value, Type targetType)
        {
            // Determine the appropriate numeric type based on the size of the number
            if (value.TryGetInt32(out int intValue))
            {
                return Convert.ChangeType(intValue, targetType);
            }
            else if (value.TryGetInt64(out long longValue))
            {
                return Convert.ChangeType(longValue, targetType);
            }
            else if (value.TryGetDouble(out double doubleValue))
            {
                return Convert.ChangeType(doubleValue, targetType);
            }
            else if (value.TryGetDecimal(out decimal decimalValue))
            {
                return Convert.ChangeType(decimalValue, targetType);
            }
            // Handle other numeric types if necessary

            // Return default value if type not handled
            return null;
        }

        private object GetString(JsonElement value, Type targetType)
        {
            string stringValue = value.GetString();
            if (targetType == typeof(string))
            {
                return stringValue;
            }

            // Handle conversion to other types from string if needed
            if (targetType.IsEnum)
            {
                return Enum.Parse(targetType, stringValue);
            }

            // Return default value if type not handled
            return null;
        }

        private void SetProperty(TopicSpecification topicSpecification, string propertyName, object value)
        {
            var property = typeof(TopicSpecification).GetProperty(propertyName);
            if (property != null && property.CanWrite)
            {
                property.SetValue(topicSpecification, value);
            }
        }
 

        private JsonElement RemoveProperty(JsonElement root, string propertyName)
        {
            if (root.ValueKind != JsonValueKind.Object)
            {
                return root; // If the root is not an object, return it unchanged
            }

            Dictionary<string, JsonElement> updatedObject = new Dictionary<string, JsonElement>();
            foreach (var property in root.EnumerateObject())
            {
                if (property.Name != propertyName)
                {
                    updatedObject.Add(property.Name, property.Value.Clone());
                }
            }
            return JsonSerializer.Deserialize<JsonElement>(JsonSerializer.Serialize(updatedObject)); ;
        }
        public override void Write(Utf8JsonWriter writer, TopicSpecification value, JsonSerializerOptions options)
        {
            // Use the default serialization behavior
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}

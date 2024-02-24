namespace MYProgressAdmin.Model
{
    using System;
    using Newtonsoft.Json;

    public class CommandModelRequest 
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("ActionSourceId")]
        public int ActionSourceId { get; set; }

        [JsonProperty("ActionSource")]
        public string ActionSource { get; set; }

        [JsonProperty("ActionId")]
        public int ActionId { get; set; }

        [JsonProperty("ActionName")]
        public  string ActionName { get; set; }

        [JsonProperty("Description")]
        public  string Description { get; set; }

        [JsonProperty("CsvData")]
        public CsvInfoModel CsvData { get; set; }

        [JsonProperty("ImageData")]
        public ImageInfoModel ImageData{ get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; } // Timestamp or date/time when the command was created or last updated

        [JsonProperty("UserId")]
        public string UserId { get; set; } // ID of the user associated with the command

        [JsonProperty("UploadSourceType")]
        public UploadFileSourceTypesEnum UploadSourceType { get; internal set; }
        [JsonProperty("Status")]
        public UserActionStatus Status { get; set; }

        // Additional properties for other file types or specific data can be added as needed

        // Method to serialize the object to JSON string
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        // Method to deserialize JSON string to object
        public static CommandModelRequest FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommandModelRequest>(json);
        }
    }

}

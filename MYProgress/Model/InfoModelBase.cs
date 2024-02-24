using Newtonsoft.Json;

namespace MYProgressAdmin.Model
{
    public class InfoModelBase
    {
     
        [JsonProperty("DesiredFileName")]
        public required string DesiredFileName { get; set; }

        [JsonProperty("FileName")]
        public required string FileName { get; set; }

        [JsonProperty("Filetype")]
        public required string Filetype { get; set; }

        [JsonProperty("Data")]
        public required string Data { get; set; } // Base64-encoded image data & CSV data content as string

        [JsonProperty("FileSize")]
        public long FileSize { get; set; } // Image file size in bytes

        [JsonProperty("FileFormat")]
        public required string FileFormat { get; set; } // Image file format or MIME type
         
        [JsonProperty("Description")]
        public required string Description { get; set; }
         
    }
}
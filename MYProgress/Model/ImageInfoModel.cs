namespace MYProgressAdmin.Model
{
    using Newtonsoft.Json;

    public class ImageInfoModel : InfoModelBase
    {

        [JsonProperty("Width")]
        public int Width { get; set; } // Image width

        [JsonProperty("Height")]
        public int Height { get; set; } // Image height

    }
}

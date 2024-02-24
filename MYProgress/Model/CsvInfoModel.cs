namespace MYProgressAdmin.Model
{
    using Newtonsoft.Json;

    public class CsvInfoModel: InfoModelBase
    {
 
        [JsonProperty("Fields")]
        public string[] Fields { get; set; } // CSV field names

      
    }

}

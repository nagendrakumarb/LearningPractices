namespace kafka.pubsub.producer
{
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    public static class HttpRequestExtensions
    {
        public static async Task<string> ReadAsStringAsync(this HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }

}

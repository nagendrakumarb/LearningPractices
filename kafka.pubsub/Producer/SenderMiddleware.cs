using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class SenderMiddleware
{
    private readonly IProducer<Null, byte[]> _producer;

    public SenderMiddleware(IProducer<Null, byte[]> producer)
    {
        _producer = producer ?? throw new ArgumentNullException(nameof(producer));
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "POST" && context.Request.Path == "/send")
        {
            var topic = context.Request.Form["topic"];
            if (context.Request.HasFormContentType)
            {
                // Check if the request contains a file
                var file = context.Request.Form.Files.FirstOrDefault();
                if (file != null && file.Length > 0)
                {
                    await SendImageAsync(topic, file);
                }
                else
                {
                    var message = context.Request.Form["message"];
                    await SendTextAsync(topic, message);
                }
            }
            else
            {
                await context.Response.WriteAsync("Invalid request. Must be a POST request with form data.");
                return;
            }

            await context.Response.WriteAsync("Message sent to Kafka.");
        }
        else
        {
            // If this middleware doesn't match the request, simply return without invoking the next middleware
            await Task.CompletedTask;
        }
    }

    private async Task SendImageAsync(string topic, IFormFile image)
    {
        using (var ms = new MemoryStream())
        {
            await image.CopyToAsync(ms);
            var imageData = ms.ToArray();

            Message<Null, byte[]> kafkaMessage = new Message<Null, byte[]>
            {
                Value = imageData
            };

            await _producer.ProduceAsync(topic, kafkaMessage);
            Console.WriteLine("Image sent to Kafka.");
        }
    }

    private async Task SendTextAsync(string topic, string message)
    {
        Message<Null, byte[]> kafkaMessage = new Message<Null, byte[]>
        {
            Value = System.Text.Encoding.UTF8.GetBytes(message)
        };

        await _producer.ProduceAsync(topic, kafkaMessage);
        Console.WriteLine("Text message sent to Kafka.");
    }
}

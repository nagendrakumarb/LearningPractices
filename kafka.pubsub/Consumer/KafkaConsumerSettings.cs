namespace kafka.pubsub.consumer
{
    public class KafkaConsumerSettings
    {
        public string BootstrapServers { get; set; }
        public string[] Topics { get; set; }
        public string GroupId { get; set; }
        public string Debug { get; set; }
    }
}

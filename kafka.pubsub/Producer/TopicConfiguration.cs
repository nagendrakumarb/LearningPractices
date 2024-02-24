namespace KafkaPubSubProducer
{
    public class TopicConfiguration
    {
        public string Name { get; set; }
        public int NumPartitions { get; set; }
        public short ReplicationFactor { get; set; }
    }
}

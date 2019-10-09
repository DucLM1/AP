namespace AP.Infrastructure.Caching.Configs
{
    public class RedisConfig
    {
        public string IpServer { get; set; }
        public int Port { get; set; }
        public int DB { get; set; }
        public int ConnectTimeout { get; set; }
        public string AuthName { get; set; }
        public string AuthPassword { get; set; }
        public string RedisSlotNameInMemory { get; set; }
    }
}
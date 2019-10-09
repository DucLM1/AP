using Microsoft.Extensions.Configuration;

namespace AP.Infrastructure.Utility
{
    public class AppSettings
    {
        private static AppSettings _instance;
        private static readonly object ObjLocked = new object();
        public IConfiguration Configuration { get; private set; }

        public static AppSettings Instance
        {
            get
            {
                if (null == _instance)

                    lock (ObjLocked)
                    {
                        _instance = new AppSettings();
                    }
                return _instance;
            }
        }
        public void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static T Get<T>(string key = null)
        {
            if (string.IsNullOrWhiteSpace(key)) return Instance.Configuration.Get<T>();
            var section = Instance.Configuration.GetSection(key);
            return section.Get<T>();
        }

        public static T Get<T>(string key, T defaultValue)
        {
            if (Instance.Configuration.GetSection(key) == null)
                return defaultValue;

            if (string.IsNullOrWhiteSpace(key))
                return Instance.Configuration.Get<T>();
            return Instance.Configuration.GetSection(key).Get<T>();
        }
    }
}
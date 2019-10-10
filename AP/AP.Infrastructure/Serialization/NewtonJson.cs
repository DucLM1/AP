using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP.Infrastructure.Serialization
{
    public class NewtonJson
    {
        private static readonly JsonSerializerSettings MicrosoftDateFormatSettings;
        //private static readonly ILoggerEs _loggerES = DVGServiceLocator.Current.GetInstance<ILoggerEs>();

        static NewtonJson()
        {
            var settings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
            };
            MicrosoftDateFormatSettings = settings;
        }

        public static T Deserialize<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, MicrosoftDateFormatSettings);
            }
            catch (Exception exception)
            {
                //_loggerES.WriteLogExeption(exception, jsonString);
                return default;
            }
        }

        public static T Deserialize<T>(string jsonString, string dateTimeFormat)
        {
            try
            {
                var converters = new JsonConverter[1];
                var converter = new IsoDateTimeConverter
                {
                    DateTimeFormat = dateTimeFormat
                };
                converters[0] = converter;
                return JsonConvert.DeserializeObject<T>(jsonString, converters);
            }
            catch (Exception exception)
            {
                //_loggerES.WriteLogExeption(exception, jsonString, dateTimeFormat);
                return default;
            }
        }

        public static object DeserializeObject(string jsonString, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(jsonString, type);
            }
            catch (Exception exception)
            {
                //_loggerES.WriteLogExeption(exception, jsonString, type);
                return default;
            }
        }

        public static string Serialize(object @object)
        {
            try
            {
                return JsonConvert.SerializeObject(@object, MicrosoftDateFormatSettings);
            }
            catch (Exception exception)
            {
                // _loggerES.WriteLogExeption(exception);
                return string.Empty;
            }
        }

        public static string Serialize(object @object, string dateTimeFormat)
        {
            try
            {
                var converters = new JsonConverter[1];
                var converter = new IsoDateTimeConverter
                {
                    DateTimeFormat = dateTimeFormat
                };
                converters[0] = converter;
                return JsonConvert.SerializeObject(@object, converters);
            }
            catch (Exception exception)
            {
                // _loggerES.WriteLogExeption(exception, dateTimeFormat);
                return string.Empty;
            }
        }
    }
}

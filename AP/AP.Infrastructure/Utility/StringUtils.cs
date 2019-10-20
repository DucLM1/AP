using System;
using System.ComponentModel;

namespace AP.Infrastructure.Utility
{
    public class StringUtils
    {
        public static string GetEnumDescription(Enum value)
        {
            try
            {
                var fi = value.GetType().GetField(value.ToString());

                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute),
                        false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                return value.ToString();
            }
            catch (Exception ex)
            {                
                return string.Empty;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace AP.Infrastructure.Utility
{
     //
    // Summary:
    //     Represents an instant in time, typically expressed as a date and time of day.
    //     Override on System.DateTime of .NET famework
    //
    // Summary:
    //     Represents an instant in time, typically expressed as a date and time of day.
    //     Override on System.DateTime of .NET famework
    public class CustomDateTime
    {
        #region Constructors

        public CustomDateTime()
        {
            var inputTime = new DateTime();

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to a specified number
        //     of ticks.
        //
        // Parameters:
        //   ticks:
        //     A date and time expressed in the number of 100-nanosecond intervals that have
        //     elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     ticks is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public CustomDateTime(long ticks)
        {
            var inputTime = new DateTime(ticks);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to a specified number
        //     of ticks and to Coordinated Universal Time (UTC) or local time.
        //
        // Parameters:
        //   ticks:
        //     A date and time expressed in the number of 100-nanosecond intervals that have
        //     elapsed since January 1, 0001 at 00:00:00.000 in the Gregorian calendar.
        //
        //   kind:
        //     One of the enumeration values that indicates whether ticks specifies a local
        //     time, Coordinated Universal Time (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     ticks is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public CustomDateTime(long ticks, DateTimeKind kind)
        {
            var inputTime = new DateTime(ticks, kind);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, and day.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999.-or- month is less than 1 or greater
        //     than 12.-or- day is less than 1 or greater than the number of days in month.
        public CustomDateTime(int year, int month, int day)
        {
            var inputTime = new DateTime(year, month, day);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, and day for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar.-or- month is less than 1 or greater
        //     than the number of months in calendar.-or- day is less than 1 or greater than
        //     the number of days in month.
        public CustomDateTime(int year, int month, int day, Calendar calendar)
        {
            var inputTime = new DateTime(year, month, day, calendar);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, and second.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.-or-
        //     hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and Coordinated Universal Time (UTC)
        //     or local time.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute and second specify a local time, Coordinated Universal Time (UTC), or
        //     neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999. -or- month is less than 1 or greater
        //     than 12. -or- day is less than 1 or greater than the number of days in month.-or-
        //     hour is less than 0 or greater than 23. -or- minute is less than 0 or greater
        //     than 59. -or- second is less than 0 or greater than 59.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, kind);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, and second for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar.-or- month is less than 1 or greater
        //     than the number of months in calendar.-or- day is less than 1 or greater than
        //     the number of days in month.-or- hour is less than 0 or greater than 23 -or-
        //     minute is less than 0 or greater than 59. -or- second is less than 0 or greater
        //     than 59.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, calendar);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and millisecond.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999.-or- month is less than 1 or greater
        //     than 12.-or- day is less than 1 or greater than the number of days in month.-or-
        //     hour is less than 0 or greater than 23.-or- minute is less than 0 or greater
        //     than 59.-or- second is less than 0 or greater than 59.-or- millisecond is less
        //     than 0 or greater than 999.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, millisecond);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, millisecond, and Coordinated Universal
        //     Time (UTC) or local time.
        //
        // Parameters:
        //   year:
        //     The year (1 through 9999).
        //
        //   month:
        //     The month (1 through 12).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute, second, and millisecond specify a local time, Coordinated Universal Time
        //     (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     year is less than 1 or greater than 9999.-or- month is less than 1 or greater
        //     than 12.-or- day is less than 1 or greater than the number of days in month.-or-
        //     hour is less than 0 or greater than 23.-or- minute is less than 0 or greater
        //     than 59.-or- second is less than 0 or greater than 59.-or- millisecond is less
        //     than 0 or greater than 999.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond,
            DateTimeKind kind)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, millisecond, kind);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, and millisecond for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar.-or- month is less than 1 or greater
        //     than the number of months in calendar.-or- day is less than 1 or greater than
        //     the number of days in month.-or- hour is less than 0 or greater than 23.-or-
        //     minute is less than 0 or greater than 59.-or- second is less than 0 or greater
        //     than 59.-or- millisecond is less than 0 or greater than 999.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond,
            Calendar calendar)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);

            Date = ConvertDate(inputTime);
        }

        //
        // Summary:
        //     Initializes a new instance of the System.DateTime structure to the specified
        //     year, month, day, hour, minute, second, millisecond, and Coordinated Universal
        //     Time (UTC) or local time for the specified calendar.
        //
        // Parameters:
        //   year:
        //     The year (1 through the number of years in calendar).
        //
        //   month:
        //     The month (1 through the number of months in calendar).
        //
        //   day:
        //     The day (1 through the number of days in month).
        //
        //   hour:
        //     The hours (0 through 23).
        //
        //   minute:
        //     The minutes (0 through 59).
        //
        //   second:
        //     The seconds (0 through 59).
        //
        //   millisecond:
        //     The milliseconds (0 through 999).
        //
        //   calendar:
        //     The calendar that is used to interpret year, month, and day.
        //
        //   kind:
        //     One of the enumeration values that indicates whether year, month, day, hour,
        //     minute, second, and millisecond specify a local time, Coordinated Universal Time
        //     (UTC), or neither.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     calendar is null.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     year is not in the range supported by calendar.-or- month is less than 1 or greater
        //     than the number of months in calendar.-or- day is less than 1 or greater than
        //     the number of days in month.-or- hour is less than 0 or greater than 23.-or-
        //     minute is less than 0 or greater than 59.-or- second is less than 0 or greater
        //     than 59.-or- millisecond is less than 0 or greater than 999.
        //
        //   T:System.ArgumentException:
        //     kind is not one of the System.DateTimeKind values.
        public CustomDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond,
            Calendar calendar, DateTimeKind kind)
        {
            var inputTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);

            Date = ConvertDate(inputTime);
        }

        #endregion Constructors

        #region Static methods

        /// <summary>
        ///     Gets a System.DateTime object that is set to the current date and time on this
        ///     computer, expressed as the local time.
        ///     <returns>An object whose value is the current local date and time.</returns>
        /// </summary>
        public static DateTime Now
        {
            get
            {
                var now = DateTime.Now;

                var dateTime = ConvertDate(now);

                return dateTime;
            }
        }

        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the Coordinated Universal Time (UTC).
        //
        // Returns:
        //     An object whose value is the current UTC date and time.
        public static DateTime UtcNow => DateTime.UtcNow;

        //
        // Summary:
        //     Represents the smallest possible value of System.DateTime. This field is read-only.
        public static DateTime MinValue => DateTime.MinValue;

        //
        // Summary:
        //     Represents the largest possible value of System.DateTime. This field is read-only.
        public static DateTime MaxValue => DateTime.MaxValue;

        //
        // Summary:
        //     Gets the current date.
        //
        // Returns:
        //     An object that is set to today's date, with the time component set to 00:00:00.
        public static DateTime Today
        {
            get
            {
                var today = DateTime.Today;

                var dateTime = ConvertDate(today);

                return dateTime;
            }
        }

        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        public static DateTime Parse(string s)
        {
            var dt = DateTime.Parse(s);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent by using culture-specific format information.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s as specified
        //     by provider.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        public static DateTime Parse(string s, IFormatProvider provider)
        {
            var dt = DateTime.Parse(s, provider);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the string representation of a date and time to its System.DateTime
        //     equivalent by using culture-specific format information and formatting style.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   styles:
        //     A bitwise combination of the enumeration values that indicates the style elements
        //     that can be present in s for the parse operation to succeed, and that defines
        //     how to interpret the parsed date in relation to the current time zone or the
        //     current date. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by provider and styles.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s is null.
        //
        //   T:System.FormatException:
        //     s does not contain a valid string representation of a date and time.
        //
        //   T:System.ArgumentException:
        //     styles contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime Parse(string s, IFormatProvider provider, DateTimeStyles styles)
        {
            var dt = DateTime.Parse(s, provider, styles);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format and culture-specific format information.
        //     The format of the string representation must match the specified format exactly.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   format:
        //     A format specifier that defines the required format of s. For more information,
        //     see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by format and provider.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or format is null.
        //
        //   T:System.FormatException:
        //     s or format is an empty string. -or- s does not contain a date and time that
        //     corresponds to the pattern specified in format. -or-The hour component and the
        //     AM/PM designator in s do not agree.
        public static DateTime ParseExact(string s, string format, IFormatProvider provider)
        {
            var dt = DateTime.ParseExact(s, format, provider);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format, culture-specific format information, and
        //     style. The format of the string representation must match the specified format
        //     exactly or an exception is thrown.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   format:
        //     A format specifier that defines the required format of s. For more information,
        //     see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   style:
        //     A bitwise combination of the enumeration values that provides additional information
        //     about s, about style elements that may be present in s, or about the conversion
        //     from s to a System.DateTime value. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by format, provider, and style.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or format is null.
        //
        //   T:System.FormatException:
        //     s or format is an empty string. -or- s does not contain a date and time that
        //     corresponds to the pattern specified in format. -or-The hour component and the
        //     AM/PM designator in s do not agree.
        //
        //   T:System.ArgumentException:
        //     style contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style)
        {
            var dt = DateTime.ParseExact(s, format, provider, style);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified array of formats, culture-specific format information,
        //     and style. The format of the string representation must match at least one of
        //     the specified formats exactly or an exception is thrown.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   formats:
        //     An array of allowable formats of s. For more information, see the Remarks section.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the permitted format
        //     of s. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        // Returns:
        //     An object that is equivalent to the date and time contained in s, as specified
        //     by formats, provider, and style.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     s or formats is null.
        //
        //   T:System.FormatException:
        //     s is an empty string. -or- an element of formats is an empty string. -or- s does
        //     not contain a date and time that corresponds to any element of formats. -or-The
        //     hour component and the AM/PM designator in s do not agree.
        //
        //   T:System.ArgumentException:
        //     style contains an invalid combination of System.Globalization.DateTimeStyles
        //     values. For example, both System.Globalization.DateTimeStyles.AssumeLocal and
        //     System.Globalization.DateTimeStyles.AssumeUniversal.
        public static DateTime ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style)
        {
            var dt = DateTime.ParseExact(s, formats, provider, style);

            var dtConverted = ConvertDate(dt);

            return dtConverted;
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent and returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if the s parameter is null, is
        //     an empty string (""), or does not contain a valid string representation of a
        //     date and time. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        public static bool TryParse(string s, out DateTime result)
        {
            result = MinValue;

            try
            {
                var isTryPass = DateTime.TryParse(s, out result);

                result = ConvertDate(result);

                return isTryPass;
            }
            catch
            {
                return false;
            }
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified culture-specific format information and formatting
        //     style, and returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   styles:
        //     A bitwise combination of enumeration values that defines how to interpret the
        //     parsed date in relation to the current time zone or the current date. A typical
        //     value to specify is System.Globalization.DateTimeStyles.None.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if the s parameter is null, is
        //     an empty string (""), or does not contain a valid string representation of a
        //     date and time. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value.-or-styles contains
        //     an invalid combination of System.Globalization.DateTimeStyles values (for example,
        //     both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        //
        //   T:System.NotSupportedException:
        //     provider is a neutral culture and cannot be used in a parsing operation.
        public static bool TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result)
        {
            result = MinValue;

            try
            {
                var isTryPass = DateTime.TryParse(s, provider, styles, out result);

                result = ConvertDate(result);

                return isTryPass;
            }
            catch
            {
                return false;
            }
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified array of formats, culture-specific format information,
        //     and style. The format of the string representation must match at least one of
        //     the specified formats exactly. The method returns a value that indicates whether
        //     the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string that contains a date and time to convert.
        //
        //   formats:
        //     An array of allowable formats of s. See the Remarks section for more information.
        //
        //   provider:
        //     An object that supplies culture-specific format information about s.
        //
        //   style:
        //     A bitwise combination of enumeration values that indicates the permitted format
        //     of s. A typical value to specify is System.Globalization.DateTimeStyles.None.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if s or formats is null, s or
        //     an element of formats is an empty string, or the format of s is not exactly as
        //     specified by at least one of the format patterns in formats. This parameter is
        //     passed uninitialized.
        //
        // Returns:
        //     true if the s parameter was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value.-or-styles contains
        //     an invalid combination of System.Globalization.DateTimeStyles values (for example,
        //     both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        public static bool TryParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style,
            out DateTime result)
        {
            result = MinValue;

            try
            {
                var isTryPass = DateTime.TryParseExact(s, formats, provider, style, out result);

                result = ConvertDate(result);

                return isTryPass;
            }
            catch
            {
                return false;
            }
        }

        //
        // Summary:
        //     Converts the specified string representation of a date and time to its System.DateTime
        //     equivalent using the specified format, culture-specific format information, and
        //     style. The format of the string representation must match the specified format
        //     exactly. The method returns a value that indicates whether the conversion succeeded.
        //
        // Parameters:
        //   s:
        //     A string containing a date and time to convert.
        //
        //   format:
        //     The required format of s. See the Remarks section for more information.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information about s.
        //
        //   style:
        //     A bitwise combination of one or more enumeration values that indicate the permitted
        //     format of s.
        //
        //   result:
        //     When this method returns, contains the System.DateTime value equivalent to the
        //     date and time contained in s, if the conversion succeeded, or System.DateTime.MinValue
        //     if the conversion failed. The conversion fails if either the s or format parameter
        //     is null, is an empty string, or does not contain a date and time that correspond
        //     to the pattern specified in format. This parameter is passed uninitialized.
        //
        // Returns:
        //     true if s was converted successfully; otherwise, false.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     styles is not a valid System.Globalization.DateTimeStyles value.-or-styles contains
        //     an invalid combination of System.Globalization.DateTimeStyles values (for example,
        //     both System.Globalization.DateTimeStyles.AssumeLocal and System.Globalization.DateTimeStyles.AssumeUniversal).
        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style,
            out DateTime result)
        {
            result = MinValue;

            try
            {
                var isTryPass = DateTime.TryParseExact(s, format, provider, style, out result);

                result = ConvertDate(result);

                return isTryPass;
            }
            catch
            {
                return false;
            }
        }

        #endregion Static methods

        #region Properties

        public static TimeSpan TimeZoneSystem { get; } = TimeZoneInfo.Local.BaseUtcOffset;

        public static string TimeZoneDestination { get; set; } = TimeZoneInfo.Local.Id;

        public long Ticks => Date.Ticks;

        //
        // Summary:
        //     Gets the date component of this instance.
        //
        // Returns:
        //     A new object with the same date as this instance, and the time value set to 12:00:00
        //     midnight (00:00:00).
        public DateTime Date { get; }

        //
        // Summary:
        //     Gets the month component of the date represented by this instance.
        //
        // Returns:
        //     The month component, expressed as a value between 1 and 12.
        public int Month => Date.Month;

        //
        // Summary:
        //     Gets the minute component of the date represented by this instance.
        //
        // Returns:
        //     The minute component, expressed as a value between 0 and 59.
        public int Minute => Date.Minute;

        //
        // Summary:
        //     Gets the milliseconds component of the date represented by this instance.
        //
        // Returns:
        //     The milliseconds component, expressed as a value between 0 and 999.
        public int Millisecond => Date.Millisecond;

        //
        // Summary:
        //     Gets the hour component of the date represented by this instance.
        //
        // Returns:
        //     The hour component, expressed as a value between 0 and 23.
        public int Hour => Date.Hour;

        //
        // Summary:
        //     Gets the day of the year represented by this instance.
        //
        // Returns:
        //     The day of the year, expressed as a value between 1 and 366.
        public int DayOfYear => Date.DayOfYear;

        //
        // Summary:
        //     Gets the day of the week represented by this instance.
        //
        // Returns:
        //     An enumerated constant that indicates the day of the week of this System.DateTime
        //     value.
        public DayOfWeek DayOfWeek => Date.DayOfWeek;

        //
        // Summary:
        //     Gets the day of the month represented by this instance.
        //
        // Returns:
        //     The day component, expressed as a value between 1 and 31.
        public int Day => Date.Day;

        //
        // Summary:
        //     Gets the seconds component of the date represented by this instance.
        //
        // Returns:
        //     The seconds component, expressed as a value between 0 and 59.
        public int Second => Date.Second;

        //
        // Summary:
        //     Gets the time of day for this instance.
        //
        // Returns:
        //     A time interval that represents the fraction of the day that has elapsed since
        //     midnight.
        public TimeSpan TimeOfDay => Date.TimeOfDay;

        //
        // Summary:
        //     Gets the year component of the date represented by this instance.
        //
        // Returns:
        //     The year, between 1 and 9999.
        public int Year => Date.Year;

        #endregion Properties

        #region Public Methods

        //
        // Summary:
        //     Returns a new System.DateTime that adds the value of the specified System.TimeSpan
        //     to the value of this instance.
        //
        // Parameters:
        //   value:
        //     A positive or negative time interval.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the time interval represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime Add(TimeSpan value)
        {
            var dt = Date.Add(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of days to the value
        //     of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional days. The value parameter can be negative or
        //     positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of days represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.ConvertDate
        public DateTime AddDays(double value)
        {
            var dt = Date.AddDays(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of hours to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional hours. The value parameter can be negative or
        //     positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of hours represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddHours(double value)
        {
            var dt = Date.AddHours(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of milliseconds
        //     to the value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional milliseconds. The value parameter can be negative
        //     or positive. Note that this value is rounded to the nearest integer.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of milliseconds represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddMilliseconds(double value)
        {
            var dt = Date.AddMilliseconds(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of minutes to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional minutes. The value parameter can be negative
        //     or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of minutes represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddMinutes(double value)
        {
            var dt = Date.AddMinutes(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of months to the
        //     value of this instance.
        //
        // Parameters:
        //   months:
        //     A number of months. The months parameter can be negative or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and months.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.-or- months is less than -120,000 or greater than
        //     120,000.
        public DateTime AddMonths(int value)
        {
            var dt = Date.AddMonths(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of seconds to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of whole and fractional seconds. The value parameter can be negative
        //     or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of seconds represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddSeconds(double value)
        {
            var dt = Date.AddSeconds(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of ticks to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of 100-nanosecond ticks. The value parameter can be positive or negative.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the time represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting System.DateTime is less than System.DateTime.MinValue or greater
        //     than System.DateTime.MaxValue.
        public DateTime AddTicks(long value)
        {
            var dt = Date.AddTicks(value);

            return dt;
        }

        //
        // Summary:
        //     Returns a new System.DateTime that adds the specified number of years to the
        //     value of this instance.
        //
        // Parameters:
        //   value:
        //     A number of years. The value parameter can be negative or positive.
        //
        // Returns:
        //     An object whose value is the sum of the date and time represented by this instance
        //     and the number of years represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     value or the resulting System.DateTime is less than System.DateTime.MinValue
        //     or greater than System.DateTime.MaxValue.
        public DateTime AddYears(int value)
        {
            var dt = Date.AddYears(value);

            return dt;
        }

        //
        // Summary:
        //     Subtracts the specified date and time from this instance.
        //
        // Parameters:
        //   value:
        //     The date and time value to subtract.
        //
        // Returns:
        //     A time interval that is equal to the date and time represented by this instance
        //     minus the date and time represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The result is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public TimeSpan Subtract(DateTime value)
        {
            var dt = Date.Subtract(value);

            return dt;
        }

        //
        // Summary:
        //     Subtracts the specified duration from this instance.
        //
        // Parameters:
        //   value:
        //     The time interval to subtract.
        //
        // Returns:
        //     An object that is equal to the date and time represented by this instance minus
        //     the time interval represented by value.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The result is less than System.DateTime.MinValue or greater than System.DateTime.MaxValue.
        public DateTime Subtract(TimeSpan value)
        {
            var dt = Date.Subtract(value);

            return dt;
        }

        //
        // Summary:
        //     Serializes the current System.DateTime object to a 64-bit binary value that subsequently
        //     can be used to recreate the System.DateTime object.
        //
        // Returns:
        //     A 64-bit signed integer that encodes the System.DateTime.Kind and System.DateTime.Ticks
        //     properties.
        public long ToBinary()
        {
            return Date.ToBinary();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to a Windows file time.
        //
        // Returns:
        //     The value of the current System.DateTime object expressed as a Windows file time.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting file time would represent a date and time before 12:00 midnight
        //     January 1, 1601 C.E. UTC.
        public long ToFileTime()
        {
            return Date.ToFileTime();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to a Windows file time.
        //
        // Returns:
        //     The value of the current System.DateTime object expressed as a Windows file time.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The resulting file time would represent a date and time before 12:00 midnight
        //     January 1, 1601 C.E. UTC.
        public long ToFileTimeUtc()
        {
            return Date.ToFileTimeUtc();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to local time.
        //
        // Returns:
        //     An object whose System.DateTime.Kind property is System.DateTimeKind.Local, and
        //     whose value is the local time equivalent to the value of the current System.DateTime
        //     object, or System.DateTime.MaxValue if the converted value is too large to be
        //     represented by a System.DateTime object, or System.DateTime.MinValue if the converted
        //     value is too small to be represented as a System.DateTime object.
        public DateTime ToLocalTime()
        {
            return Date.ToLocalTime();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent long
        //     date string representation.
        //
        // Returns:
        //     A string that contains the long date string representation of the current System.DateTime
        //     object.
        public string ToLongDateString()
        {
            return Date.ToLongDateString();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent long
        //     time string representation.
        //
        // Returns:
        //     A string that contains the long time string representation of the current System.DateTime
        //     object.
        public string ToLongTimeString()
        {
            return Date.ToLongTimeString();
        }

        //
        // Summary:
        //     Converts the value of this instance to the equivalent OLE Automation date.
        //
        // Returns:
        //     A double-precision floating-point number that contains an OLE Automation date
        //     equivalent to the value of this instance.
        //
        // Exceptions:
        //   T:System.OverflowException:
        //     The value of this instance cannot be represented as an OLE Automation Date.
        public double ToOADate()
        {
            return Date.ToOADate();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent short
        //     date string representation.
        //
        // Returns:
        //     A string that contains the short date string representation of the current System.DateTime
        //     object.
        public string ToShortDateString()
        {
            return Date.ToShortDateString();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent short
        //     time string representation.
        //
        // Returns:
        //     A string that contains the short time string representation of the current System.DateTime
        //     object.
        public string ToShortTimeString()
        {
            return Date.ToShortTimeString();
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified format and culture-specific format information.
        //
        // Parameters:
        //   format:
        //     A standard or custom date and time format string.
        //
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by format and provider.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     The length of format is 1, and it is not one of the format specifier characters
        //     defined for System.Globalization.DateTimeFormatInfo.-or- format does not contain
        //     a valid custom format pattern.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by provider.
        public string ToString(string format, IFormatProvider provider)
        {
            return Date.ToString(format, provider);
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified culture-specific format information.
        //
        // Parameters:
        //   provider:
        //     An object that supplies culture-specific formatting information.
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by provider.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by provider.
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        public string ToString(IFormatProvider provider)
        {
            return Date.ToString(provider);
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation using the specified format.
        //
        // Parameters:
        //   format:
        //     A standard or custom date and time format string (see Remarks).
        //
        // Returns:
        //     A string representation of value of the current System.DateTime object as specified
        //     by format.
        //
        // Exceptions:
        //   T:System.FormatException:
        //     The length of format is 1, and it is not one of the format specifier characters
        //     defined for System.Globalization.DateTimeFormatInfo.-or- format does not contain
        //     a valid custom format pattern.
        //
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by the current culture.
        public string ToString(string format)
        {
            return Date.ToString(format);
        }

        //
        // Summary:
        //     Converts the value of the current System.DateTime object to its equivalent string
        //     representation.
        //
        // Returns:
        //     A string representation of the value of the current System.DateTime object.
        //
        // Exceptions:
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by the current culture.
        public override string ToString()
        {
            return Date.ToString();
        }

        #endregion Public Methods

        #region Private Methods

        public static DateTime ConvertDate(DateTime inputTime, string destinationTimeZone)
        {
            var dateTime = TimeZoneInfo.ConvertTime(inputTime, TZConvert.GetTimeZoneInfo(destinationTimeZone));

            return dateTime;
        }

        private static DateTime ConvertDate(DateTime inputTime)
        {
            var dateTime = TimeZoneInfo.ConvertTime(inputTime, TZConvert.GetTimeZoneInfo(TimeZoneDestination));

            return dateTime;
        }

        #endregion Private Methods

        #region Defined Structs

        public struct DefinedGMT
        {
            /// <summary>
            ///     (UTC-12:00) International Date Line West
            /// </summary>
            public static string DatelineStandardTime = "-12:00:00";

            /// <summary>
            ///     (UTC-11:00) Coordinated Universal Time-11
            /// </summary>
            public static string UTC_sub_11 = "-11:00:00";

            /// <summary>
            ///     (UTC-10:00) Aleutian Islands
            /// </summary>
            public static string AleutianStandardTime = "-10:00:00";

            /// <summary>
            ///     (UTC-10:00) Hawaii
            /// </summary>
            public static string HawaiianStandardTime = "-10:00:00";

            /// <summary>
            ///     (UTC-09:30) Marquesas Islands
            /// </summary>
            public static string MarquesasStandardTime = "-09:30:00";

            /// <summary>
            ///     (UTC-09:00) Alaska
            /// </summary>
            public static string AlaskanStandardTime = "-09:00:00";

            /// <summary>
            ///     (UTC-09:00) Coordinated Universal Time-09
            /// </summary>
            public static string UTC_sub_09 = "-09:00:00";

            /// <summary>
            ///     (UTC-08:00) Baja California
            /// </summary>
            public static string PacificStandardTime_Mexico = "-08:00:00";

            /// <summary>
            ///     (UTC-08:00) Coordinated Universal Time-08
            /// </summary>
            public static string UTC_sub_08 = "-08:00:00";

            /// <summary>
            ///     (UTC-08:00) Pacific Time (US & Canada)
            /// </summary>
            public static string PacificStandardTime = "-08:00:00";

            /// <summary>
            ///     (UTC-07:00) Arizona
            /// </summary>
            public static string USMountainStandardTime = "-07:00:00";

            /// <summary>
            ///     (UTC-07:00) Chihuahua, La Paz, Mazatlan
            /// </summary>
            public static string MountainStandardTime_Mexico = "-07:00:00";

            /// <summary>
            ///     (UTC-07:00) Mountain Time (US & Canada)
            /// </summary>
            public static string MountainStandardTime = "-07:00:00";

            /// <summary>
            ///     (UTC-06:00) Central America
            /// </summary>
            public static string CentralAmericaStandardTime = "-06:00:00";

            /// <summary>
            ///     (UTC-06:00) Central Time (US & Canada)
            /// </summary>
            public static string CentralStandardTime = "-06:00:00";

            /// <summary>
            ///     (UTC-06:00) Easter Island
            /// </summary>
            public static string EasterIslandStandardTime = "-06:00:00";

            /// <summary>
            ///     (UTC-06:00) Guadalajara, Mexico City, Monterrey
            /// </summary>
            public static string CentralStandardTime_Mexico = "-06:00:00";

            /// <summary>
            ///     (UTC-06:00) Saskatchewan
            /// </summary>
            public static string CanadaCentralStandardTime = "-06:00:00";

            /// <summary>
            ///     (UTC-05:00) Bogota, Lima, Quito, Rio Branco
            /// </summary>
            public static string SAPacificStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Chetumal
            /// </summary>
            public static string EasternStandardTime_Mexico = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Eastern Time (US & Canada)
            /// </summary>
            public static string EasternStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Haiti
            /// </summary>
            public static string HaitiStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Havana
            /// </summary>
            public static string CubaStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Indiana (East)
            /// </summary>
            public static string USEasternStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-05:00) Turks and Caicos
            /// </summary>
            public static string TurksAndCaicosStandardTime = "-05:00:00";

            /// <summary>
            ///     (UTC-04:00) Asuncion
            /// </summary>
            public static string ParaguayStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-04:00) Atlantic Time (Canada)
            /// </summary>
            public static string AtlanticStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-04:00) Caracas
            /// </summary>
            public static string VenezuelaStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-04:00) Cuiaba
            /// </summary>
            public static string CentralBrazilianStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-04:00) Georgetown, La Paz, Manaus, San Juan
            /// </summary>
            public static string SAWesternStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-04:00) Santiago
            /// </summary>
            public static string PacificSAStandardTime = "-04:00:00";

            /// <summary>
            ///     (UTC-03:30) Newfoundland
            /// </summary>
            public static string NewfoundlandStandardTime = "-03:30:00";

            /// <summary>
            ///     (UTC-03:00) Araguaina
            /// </summary>
            public static string TocantinsStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Brasilia
            /// </summary>
            public static string E_SouthAmericaStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Cayenne, Fortaleza
            /// </summary>
            public static string SAEasternStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) City of Buenos Aires
            /// </summary>
            public static string ArgentinaStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Greenland
            /// </summary>
            public static string GreenlandStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Montevideo
            /// </summary>
            public static string MontevideoStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Punta Arenas
            /// </summary>
            public static string MagallanesStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Saint Pierre and Miquelon
            /// </summary>
            public static string SaintPierreStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-03:00) Salvador
            /// </summary>
            public static string BahiaStandardTime = "-03:00:00";

            /// <summary>
            ///     (UTC-02:00) Coordinated Universal Time-02
            /// </summary>
            public static string UTC_sub_02 = "-02:00:00";

            /// <summary>
            ///     (UTC-02:00) Mid-Atlantic - Old
            /// </summary>
            public static string Mid_sub_AtlanticStandardTime = "-02:00:00";

            /// <summary>
            ///     (UTC-01:00) Azores
            /// </summary>
            public static string AzoresStandardTime = "-01:00:00";

            /// <summary>
            ///     (UTC-01:00) Cabo Verde Is.
            /// </summary>
            public static string CapeVerdeStandardTime = "-01:00:00";

            /// <summary>
            ///     (UTC) Coordinated Universal Time
            /// </summary>
            public static string UTC = "00:00:00";

            /// <summary>
            ///     (UTC+00:00) Casablanca
            /// </summary>
            public static string MoroccoStandardTime = "00:00:00";

            /// <summary>
            ///     (UTC+00:00) Dublin, Edinburgh, Lisbon, London
            /// </summary>
            public static string GMTStandardTime = "00:00:00";

            /// <summary>
            ///     (UTC+00:00) Monrovia, Reykjavik
            /// </summary>
            public static string GreenwichStandardTime = "00:00:00";

            /// <summary>
            ///     (UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
            /// </summary>
            public static string W_EuropeStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
            /// </summary>
            public static string CentralEuropeStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+01:00) Brussels, Copenhagen, Madrid, Paris
            /// </summary>
            public static string RomanceStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+01:00) Sao Tome
            /// </summary>
            public static string SaoTomeStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb
            /// </summary>
            public static string CentralEuropeanStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+01:00) West Central Africa
            /// </summary>
            public static string W_CentralAfricaStandardTime = "01:00:00";

            /// <summary>
            ///     (UTC+02:00) Amman
            /// </summary>
            public static string JordanStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Athens, Bucharest
            /// </summary>
            public static string GTBStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Beirut
            /// </summary>
            public static string MiddleEastStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Cairo
            /// </summary>
            public static string EgyptStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Chisinau
            /// </summary>
            public static string E_EuropeStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Damascus
            /// </summary>
            public static string SyriaStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Gaza, Hebron
            /// </summary>
            public static string WestBankStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Harare, Pretoria
            /// </summary>
            public static string SouthAfricaStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius
            /// </summary>
            public static string FLEStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Jerusalem
            /// </summary>
            public static string IsraelStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Kaliningrad
            /// </summary>
            public static string KaliningradStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Khartoum
            /// </summary>
            public static string SudanStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Tripoli
            /// </summary>
            public static string LibyaStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+02:00) Windhoek
            /// </summary>
            public static string NamibiaStandardTime = "02:00:00";

            /// <summary>
            ///     (UTC+03:00) Baghdad
            /// </summary>
            public static string ArabicStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:00) Istanbul
            /// </summary>
            public static string TurkeyStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:00) Kuwait, Riyadh
            /// </summary>
            public static string ArabStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:00) Minsk
            /// </summary>
            public static string BelarusStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:00) Moscow, St. Petersburg, Volgograd
            /// </summary>
            public static string RussianStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:00) Nairobi
            /// </summary>
            public static string E_AfricaStandardTime = "03:00:00";

            /// <summary>
            ///     (UTC+03:30) Tehran
            /// </summary>
            public static string IranStandardTime = "03:30:00";

            /// <summary>
            ///     (UTC+04:00) Abu Dhabi, Muscat
            /// </summary>
            public static string ArabianStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Astrakhan, Ulyanovsk
            /// </summary>
            public static string AstrakhanStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Baku
            /// </summary>
            public static string AzerbaijanStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Izhevsk, Samara
            /// </summary>
            public static string RussiaTimeZone3 = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Port Louis
            /// </summary>
            public static string MauritiusStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Saratov
            /// </summary>
            public static string SaratovStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Tbilisi
            /// </summary>
            public static string GeorgianStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:00) Yerevan
            /// </summary>
            public static string CaucasusStandardTime = "04:00:00";

            /// <summary>
            ///     (UTC+04:30) Kabul
            /// </summary>
            public static string AfghanistanStandardTime = "04:30:00";

            /// <summary>
            ///     (UTC+05:00) Ashgabat, Tashkent
            /// </summary>
            public static string WestAsiaStandardTime = "05:00:00";

            /// <summary>
            ///     (UTC+05:00) Ekaterinburg
            /// </summary>
            public static string EkaterinburgStandardTime = "05:00:00";

            /// <summary>
            ///     (UTC+05:00) Islamabad, Karachi
            /// </summary>
            public static string PakistanStandardTime = "05:00:00";

            /// <summary>
            ///     (UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi
            /// </summary>
            public static string IndiaStandardTime = "05:30:00";

            /// <summary>
            ///     (UTC+05:30) Sri Jayawardenepura
            /// </summary>
            public static string SriLankaStandardTime = "05:30:00";

            /// <summary>
            ///     (UTC+05:45) Kathmandu
            /// </summary>
            public static string NepalStandardTime = "05:45:00";

            /// <summary>
            ///     (UTC+06:00) Astana
            /// </summary>
            public static string CentralAsiaStandardTime = "06:00:00";

            /// <summary>
            ///     (UTC+06:00) Dhaka
            /// </summary>
            public static string BangladeshStandardTime = "06:00:00";

            /// <summary>
            ///     (UTC+06:00) Omsk
            /// </summary>
            public static string OmskStandardTime = "06:00:00";

            /// <summary>
            ///     (UTC+06:30) Yangon (Rangoon)
            /// </summary>
            public static string MyanmarStandardTime = "06:30:00";

            /// <summary>
            ///     (UTC+07:00) Bangkok, Hanoi, Jakarta
            /// </summary>
            public static string SEAsiaStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+07:00) Barnaul, Gorno-Altaysk
            /// </summary>
            public static string AltaiStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+07:00) Hovd
            /// </summary>
            public static string W_MongoliaStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+07:00) Krasnoyarsk, Ha Noi, Jakagta
            /// </summary>
            public static string NorthAsiaStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+07:00) Novosibirsk
            /// </summary>
            public static string N_CentralAsiaStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+07:00) Tomsk
            /// </summary>
            public static string TomskStandardTime = "07:00:00";

            /// <summary>
            ///     (UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi
            /// </summary>
            public static string ChinaStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:00) Irkutsk
            /// </summary>
            public static string NorthAsiaEastStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:00) Kuala Lumpur, Singapore
            /// </summary>
            public static string SingaporeStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:00) Perth
            /// </summary>
            public static string W_AustraliaStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:00) Taipei
            /// </summary>
            public static string TaipeiStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:00) Ulaanbaatar
            /// </summary>
            public static string UlaanbaatarStandardTime = "08:00:00";

            /// <summary>
            ///     (UTC+08:30) Pyongyang
            /// </summary>
            public static string NorthKoreaStandardTime = "08:30:00";

            /// <summary>
            ///     (UTC+08:45) Eucla
            /// </summary>
            public static string AusCentralW_StandardTime = "08:45:00";

            /// <summary>
            ///     (UTC+09:00) Chita
            /// </summary>
            public static string TransbaikalStandardTime = "09:00:00";

            /// <summary>
            ///     (UTC+09:00) Osaka, Sapporo, Tokyo
            /// </summary>
            public static string TokyoStandardTime = "09:00:00";

            /// <summary>
            ///     (UTC+09:00) Seoul
            /// </summary>
            public static string KoreaStandardTime = "09:00:00";

            /// <summary>
            ///     (UTC+09:00) Yakutsk
            /// </summary>
            public static string YakutskStandardTime = "09:00:00";

            /// <summary>
            ///     (UTC+09:30) Adelaide
            /// </summary>
            public static string Cen_AustraliaStandardTime = "09:30:00";

            /// <summary>
            ///     (UTC+09:30) Darwin
            /// </summary>
            public static string AUSCentralStandardTime = "09:30:00";

            /// <summary>
            ///     (UTC+10:00) Brisbane
            /// </summary>
            public static string E_AustraliaStandardTime = "10:00:00";

            /// <summary>
            ///     (UTC+10:00) Canberra, Melbourne, Sydney
            /// </summary>
            public static string AUSEasternStandardTime = "10:00:00";

            /// <summary>
            ///     (UTC+10:00) Guam, Port Moresby
            /// </summary>
            public static string WestPacificStandardTime = "10:00:00";

            /// <summary>
            ///     (UTC+10:00) Hobart
            /// </summary>
            public static string TasmaniaStandardTime = "10:00:00";

            /// <summary>
            ///     (UTC+10:00) Vladivostok
            /// </summary>
            public static string VladivostokStandardTime = "10:00:00";

            /// <summary>
            ///     (UTC+10:30) Lord Howe Island
            /// </summary>
            public static string LordHoweStandardTime = "10:30:00";

            /// <summary>
            ///     (UTC+11:00) Bougainville Island
            /// </summary>
            public static string BougainvilleStandardTime = "11:00:00";

            /// <summary>
            ///     (UTC+11:00) Chokurdakh
            /// </summary>
            public static string RussiaTimeZone10 = "11:00:00";

            /// <summary>
            ///     (UTC+11:00) Magadan
            /// </summary>
            public static string MagadanStandardTime = "11:00:00";

            /// <summary>
            ///     (UTC+11:00) Norfolk Island
            /// </summary>
            public static string NorfolkStandardTime = "11:00:00";

            /// <summary>
            ///     (UTC+11:00) Sakhalin
            /// </summary>
            public static string SakhalinStandardTime = "11:00:00";

            /// <summary>
            ///     (UTC+11:00) Solomon Is., New Caledonia
            /// </summary>
            public static string CentralPacificStandardTime = "11:00:00";

            /// <summary>
            ///     (UTC+12:00) Anadyr, Petropavlovsk-Kamchatsky
            /// </summary>
            public static string RussiaTimeZone11 = "12:00:00";

            /// <summary>
            ///     (UTC+12:00) Auckland, Wellington
            /// </summary>
            public static string NewZealandStandardTime = "12:00:00";

            /// <summary>
            ///     (UTC+12:00) Coordinated Universal Time+12
            /// </summary>
            public static string UTC_plus_12 = "12:00:00";

            /// <summary>
            ///     (UTC+12:00) Fiji
            /// </summary>
            public static string FijiStandardTime = "12:00:00";

            /// <summary>
            ///     (UTC+12:00) Petropavlovsk-Kamchatsky - Old
            /// </summary>
            public static string KamchatkaStandardTime = "12:00:00";

            /// <summary>
            ///     (UTC+12:45) Chatham Islands
            /// </summary>
            public static string ChathamIslandsStandardTime = "12:45:00";

            /// <summary>
            ///     (UTC+13:00) Coordinated Universal Time+13
            /// </summary>
            public static string UTC_plus_13 = "13:00:00";

            /// <summary>
            ///     (UTC+13:00) Nuku'alofa
            /// </summary>
            public static string TongaStandardTime = "13:00:00";

            /// <summary>
            ///     (UTC+13:00) Samoa
            /// </summary>
            public static string SamoaStandardTime = "13:00:00";

            /// <summary>
            ///     (UTC+14:00) Kiritimati Island
            /// </summary>
            public static string LineIslandsStandardTime = "14:00:00";
        }

        public struct DefinedTimeZone
        {
            /// <summary>
            ///     (UTC-12:00) International Date Line West
            /// </summary>
            public static string DatelineStandardTime = "Dateline Standard Time";

            /// <summary>
            ///     (UTC-11:00) Coordinated Universal Time-11
            /// </summary>
            public static string UTC_sub_11 = "UTC-11";

            /// <summary>
            ///     (UTC-10:00) Aleutian Islands
            /// </summary>
            public static string AleutianStandardTime = "Aleutian Standard Time";

            /// <summary>
            ///     (UTC-10:00) Hawaii
            /// </summary>
            public static string HawaiianStandardTime = "Hawaiian Standard Time";

            /// <summary>
            ///     (UTC-09:30) Marquesas Islands
            /// </summary>
            public static string MarquesasStandardTime = "Marquesas Standard Time";

            /// <summary>
            ///     (UTC-09:00) Alaska
            /// </summary>
            public static string AlaskanStandardTime = "Alaskan Standard Time";

            /// <summary>
            ///     (UTC-09:00) Coordinated Universal Time-09
            /// </summary>
            public static string UTC_sub_09 = "UTC-09";

            /// <summary>
            ///     (UTC-08:00) Baja California
            /// </summary>
            public static string PacificStandardTime_Mexico = "Pacific Standard Time (Mexico)";

            /// <summary>
            ///     (UTC-08:00) Coordinated Universal Time-08
            /// </summary>
            public static string UTC_sub_08 = "UTC-08";

            /// <summary>
            ///     (UTC-08:00) Pacific Time (US & Canada)
            /// </summary>
            public static string PacificStandardTime = "Pacific Standard Time";

            /// <summary>
            ///     (UTC-07:00) Arizona
            /// </summary>
            public static string USMountainStandardTime = "US Mountain Standard Time";

            /// <summary>
            ///     (UTC-07:00) Chihuahua, La Paz, Mazatlan
            /// </summary>
            public static string MountainStandardTime_Mexico = "Mountain Standard Time (Mexico)";

            /// <summary>
            ///     (UTC-07:00) Mountain Time (US & Canada)
            /// </summary>
            public static string MountainStandardTime = "Mountain Standard Time";

            /// <summary>
            ///     (UTC-06:00) Central America
            /// </summary>
            public static string CentralAmericaStandardTime = "Central America Standard Time";

            /// <summary>
            ///     (UTC-06:00) Central Time (US & Canada)
            /// </summary>
            public static string CentralStandardTime = "Central Standard Time";

            /// <summary>
            ///     (UTC-06:00) Easter Island
            /// </summary>
            public static string EasterIslandStandardTime = "Easter Island Standard Time";

            /// <summary>
            ///     (UTC-06:00) Guadalajara, Mexico City, Monterrey
            /// </summary>
            public static string CentralStandardTime_Mexico = "Central Standard Time (Mexico)";

            /// <summary>
            ///     (UTC-06:00) Saskatchewan
            /// </summary>
            public static string CanadaCentralStandardTime = "Canada Central Standard Time";

            /// <summary>
            ///     (UTC-05:00) Bogota, Lima, Quito, Rio Branco
            /// </summary>
            public static string SAPacificStandardTime = "SA Pacific Standard Time";

            /// <summary>
            ///     (UTC-05:00) Chetumal
            /// </summary>
            public static string EasternStandardTime_Mexico = "Eastern Standard Time (Mexico)";

            /// <summary>
            ///     (UTC-05:00) Eastern Time (US & Canada)
            /// </summary>
            public static string EasternStandardTime = "Eastern Standard Time";

            /// <summary>
            ///     (UTC-05:00) Haiti
            /// </summary>
            public static string HaitiStandardTime = "Haiti Standard Time";

            /// <summary>
            ///     (UTC-05:00) Havana
            /// </summary>
            public static string CubaStandardTime = "Cuba Standard Time";

            /// <summary>
            ///     (UTC-05:00) Indiana (East)
            /// </summary>
            public static string USEasternStandardTime = "US Eastern Standard Time";

            /// <summary>
            ///     (UTC-05:00) Turks and Caicos
            /// </summary>
            public static string TurksAndCaicosStandardTime = "Turks And Caicos Standard Time";

            /// <summary>
            ///     (UTC-04:00) Asuncion
            /// </summary>
            public static string ParaguayStandardTime = "Paraguay Standard Time";

            /// <summary>
            ///     (UTC-04:00) Atlantic Time (Canada)
            /// </summary>
            public static string AtlanticStandardTime = "Atlantic Standard Time";

            /// <summary>
            ///     (UTC-04:00) Caracas
            /// </summary>
            public static string VenezuelaStandardTime = "Venezuela Standard Time";

            /// <summary>
            ///     (UTC-04:00) Cuiaba
            /// </summary>
            public static string CentralBrazilianStandardTime = "Central Brazilian Standard Time";

            /// <summary>
            ///     (UTC-04:00) Georgetown, La Paz, Manaus, San Juan
            /// </summary>
            public static string SAWesternStandardTime = "SA Western Standard Time";

            /// <summary>
            ///     (UTC-04:00) Santiago
            /// </summary>
            public static string PacificSAStandardTime = "Pacific SA Standard Time";

            /// <summary>
            ///     (UTC-03:30) Newfoundland
            /// </summary>
            public static string NewfoundlandStandardTime = "Newfoundland Standard Time";

            /// <summary>
            ///     (UTC-03:00) Araguaina
            /// </summary>
            public static string TocantinsStandardTime = "Tocantins Standard Time";

            /// <summary>
            ///     (UTC-03:00) Brasilia
            /// </summary>
            public static string E_SouthAmericaStandardTime = "E. South America Standard Time";

            /// <summary>
            ///     (UTC-03:00) Cayenne, Fortaleza
            /// </summary>
            public static string SAEasternStandardTime = "SA Eastern Standard Time";

            /// <summary>
            ///     (UTC-03:00) City of Buenos Aires
            /// </summary>
            public static string ArgentinaStandardTime = "Argentina Standard Time";

            /// <summary>
            ///     (UTC-03:00) Greenland
            /// </summary>
            public static string GreenlandStandardTime = "Greenland Standard Time";

            /// <summary>
            ///     (UTC-03:00) Montevideo
            /// </summary>
            public static string MontevideoStandardTime = "Montevideo Standard Time";

            /// <summary>
            ///     (UTC-03:00) Punta Arenas
            /// </summary>
            public static string MagallanesStandardTime = "Magallanes Standard Time";

            /// <summary>
            ///     (UTC-03:00) Saint Pierre and Miquelon
            /// </summary>
            public static string SaintPierreStandardTime = "Saint Pierre Standard Time";

            /// <summary>
            ///     (UTC-03:00) Salvador
            /// </summary>
            public static string BahiaStandardTime = "Bahia Standard Time";

            /// <summary>
            ///     (UTC-02:00) Coordinated Universal Time-02
            /// </summary>
            public static string UTC_sub_02 = "UTC-02";

            /// <summary>
            ///     (UTC-02:00) Mid-Atlantic - Old
            /// </summary>
            public static string Mid_sub_AtlanticStandardTime = "Mid-Atlantic Standard Time";

            /// <summary>
            ///     (UTC-01:00) Azores
            /// </summary>
            public static string AzoresStandardTime = "Azores Standard Time";

            /// <summary>
            ///     (UTC-01:00) Cabo Verde Is.
            /// </summary>
            public static string CapeVerdeStandardTime = "Cape Verde Standard Time";

            /// <summary>
            ///     (UTC) Coordinated Universal Time
            /// </summary>
            public static string UTC = "UTC";

            /// <summary>
            ///     (UTC+00:00) Casablanca
            /// </summary>
            public static string MoroccoStandardTime = "Morocco Standard Time";

            /// <summary>
            ///     (UTC+00:00) Dublin, Edinburgh, Lisbon, London
            /// </summary>
            public static string GMTStandardTime = "GMT Standard Time";

            /// <summary>
            ///     (UTC+00:00) Monrovia, Reykjavik
            /// </summary>
            public static string GreenwichStandardTime = "Greenwich Standard Time";

            /// <summary>
            ///     (UTC+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna
            /// </summary>
            public static string W_EuropeStandardTime = "W. Europe Standard Time";

            /// <summary>
            ///     (UTC+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague
            /// </summary>
            public static string CentralEuropeStandardTime = "Central Europe Standard Time";

            /// <summary>
            ///     (UTC+01:00) Brussels, Copenhagen, Madrid, Paris
            /// </summary>
            public static string RomanceStandardTime = "Romance Standard Time";

            /// <summary>
            ///     (UTC+01:00) Sao Tome
            /// </summary>
            public static string SaoTomeStandardTime = "Sao Tome Standard Time";

            /// <summary>
            ///     (UTC+01:00) Sarajevo, Skopje, Warsaw, Zagreb
            /// </summary>
            public static string CentralEuropeanStandardTime = "Central European Standard Time";

            /// <summary>
            ///     (UTC+01:00) West Central Africa
            /// </summary>
            public static string W_CentralAfricaStandardTime = "W. Central Africa Standard Time";

            /// <summary>
            ///     (UTC+02:00) Amman
            /// </summary>
            public static string JordanStandardTime = "Jordan Standard Time";

            /// <summary>
            ///     (UTC+02:00) Athens, Bucharest
            /// </summary>
            public static string GTBStandardTime = "GTB Standard Time";

            /// <summary>
            ///     (UTC+02:00) Beirut
            /// </summary>
            public static string MiddleEastStandardTime = "Middle East Standard Time";

            /// <summary>
            ///     (UTC+02:00) Cairo
            /// </summary>
            public static string EgyptStandardTime = "Egypt Standard Time";

            /// <summary>
            ///     (UTC+02:00) Chisinau
            /// </summary>
            public static string E_EuropeStandardTime = "E. Europe Standard Time";

            /// <summary>
            ///     (UTC+02:00) Damascus
            /// </summary>
            public static string SyriaStandardTime = "Syria Standard Time";

            /// <summary>
            ///     (UTC+02:00) Gaza, Hebron
            /// </summary>
            public static string WestBankStandardTime = "West Bank Standard Time";

            /// <summary>
            ///     (UTC+02:00) Harare, Pretoria
            /// </summary>
            public static string SouthAfricaStandardTime = "South Africa Standard Time";

            /// <summary>
            ///     (UTC+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius
            /// </summary>
            public static string FLEStandardTime = "FLE Standard Time";

            /// <summary>
            ///     (UTC+02:00) Jerusalem
            /// </summary>
            public static string IsraelStandardTime = "Israel Standard Time";

            /// <summary>
            ///     (UTC+02:00) Kaliningrad
            /// </summary>
            public static string KaliningradStandardTime = "Kaliningrad Standard Time";

            /// <summary>
            ///     (UTC+02:00) Khartoum
            /// </summary>
            public static string SudanStandardTime = "Sudan Standard Time";

            /// <summary>
            ///     (UTC+02:00) Tripoli
            /// </summary>
            public static string LibyaStandardTime = "Libya Standard Time";

            /// <summary>
            ///     (UTC+02:00) Windhoek
            /// </summary>
            public static string NamibiaStandardTime = "Namibia Standard Time";

            /// <summary>
            ///     (UTC+03:00) Baghdad
            /// </summary>
            public static string ArabicStandardTime = "Arabic Standard Time";

            /// <summary>
            ///     (UTC+03:00) Istanbul
            /// </summary>
            public static string TurkeyStandardTime = "Turkey Standard Time";

            /// <summary>
            ///     (UTC+03:00) Kuwait, Riyadh
            /// </summary>
            public static string ArabStandardTime = "Arab Standard Time";

            /// <summary>
            ///     (UTC+03:00) Minsk
            /// </summary>
            public static string BelarusStandardTime = "Belarus Standard Time";

            /// <summary>
            ///     (UTC+03:00) Moscow, St. Petersburg, Volgograd
            /// </summary>
            public static string RussianStandardTime = "Russian Standard Time";

            /// <summary>
            ///     (UTC+03:00) Nairobi
            /// </summary>
            public static string E_AfricaStandardTime = "E. Africa Standard Time";

            /// <summary>
            ///     (UTC+03:30) Tehran
            /// </summary>
            public static string IranStandardTime = "Iran Standard Time";

            /// <summary>
            ///     (UTC+04:00) Abu Dhabi, Muscat
            /// </summary>
            public static string ArabianStandardTime = "Arabian Standard Time";

            /// <summary>
            ///     (UTC+04:00) Astrakhan, Ulyanovsk
            /// </summary>
            public static string AstrakhanStandardTime = "Astrakhan Standard Time";

            /// <summary>
            ///     (UTC+04:00) Baku
            /// </summary>
            public static string AzerbaijanStandardTime = "Azerbaijan Standard Time";

            /// <summary>
            ///     (UTC+04:00) Izhevsk, Samara
            /// </summary>
            public static string RussiaTimeZone3 = "Russia Time Zone 3";

            /// <summary>
            ///     (UTC+04:00) Port Louis
            /// </summary>
            public static string MauritiusStandardTime = "Mauritius Standard Time";

            /// <summary>
            ///     (UTC+04:00) Saratov
            /// </summary>
            public static string SaratovStandardTime = "Saratov Standard Time";

            /// <summary>
            ///     (UTC+04:00) Tbilisi
            /// </summary>
            public static string GeorgianStandardTime = "Georgian Standard Time";

            /// <summary>
            ///     (UTC+04:00) Yerevan
            /// </summary>
            public static string CaucasusStandardTime = "Caucasus Standard Time";

            /// <summary>
            ///     (UTC+04:30) Kabul
            /// </summary>
            public static string AfghanistanStandardTime = "Afghanistan Standard Time";

            /// <summary>
            ///     (UTC+05:00) Ashgabat, Tashkent
            /// </summary>
            public static string WestAsiaStandardTime = "West Asia Standard Time";

            /// <summary>
            ///     (UTC+05:00) Ekaterinburg
            /// </summary>
            public static string EkaterinburgStandardTime = "Ekaterinburg Standard Time";

            /// <summary>
            ///     (UTC+05:00) Islamabad, Karachi
            /// </summary>
            public static string PakistanStandardTime = "Pakistan Standard Time";

            /// <summary>
            ///     (UTC+05:30) Chennai, Kolkata, Mumbai, New Delhi
            /// </summary>
            public static string IndiaStandardTime = "India Standard Time";

            /// <summary>
            ///     (UTC+05:30) Sri Jayawardenepura
            /// </summary>
            public static string SriLankaStandardTime = "Sri Lanka Standard Time";

            /// <summary>
            ///     (UTC+05:45) Kathmandu
            /// </summary>
            public static string NepalStandardTime = "Nepal Standard Time";

            /// <summary>
            ///     (UTC+06:00) Astana
            /// </summary>
            public static string CentralAsiaStandardTime = "Central Asia Standard Time";

            /// <summary>
            ///     (UTC+06:00) Dhaka
            /// </summary>
            public static string BangladeshStandardTime = "Bangladesh Standard Time";

            /// <summary>
            ///     (UTC+06:00) Omsk
            /// </summary>
            public static string OmskStandardTime = "Omsk Standard Time";

            /// <summary>
            ///     (UTC+06:30) Yangon (Rangoon)
            /// </summary>
            public static string MyanmarStandardTime = "Myanmar Standard Time";

            /// <summary>
            ///     (UTC+07:00) Bangkok, Hanoi, Jakarta
            /// </summary>
            public static string SEAsiaStandardTime = "SE Asia Standard Time";

            /// <summary>
            ///     (UTC+07:00) Barnaul, Gorno-Altaysk
            /// </summary>
            public static string AltaiStandardTime = "Altai Standard Time";

            /// <summary>
            ///     (UTC+07:00) Hovd
            /// </summary>
            public static string W_MongoliaStandardTime = "W. Mongolia Standard Time";

            /// <summary>
            ///     (UTC+07:00) Krasnoyarsk
            /// </summary>
            public static string NorthAsiaStandardTime = "North Asia Standard Time";

            /// <summary>
            ///     (UTC+07:00) Novosibirsk
            /// </summary>
            public static string N_CentralAsiaStandardTime = "N. Central Asia Standard Time";

            /// <summary>
            ///     (UTC+07:00) Tomsk
            /// </summary>
            public static string TomskStandardTime = "Tomsk Standard Time";

            /// <summary>
            ///     (UTC+08:00) Beijing, Chongqing, Hong Kong, Urumqi
            /// </summary>
            public static string ChinaStandardTime = "China Standard Time";

            /// <summary>
            ///     (UTC+08:00) Irkutsk
            /// </summary>
            public static string NorthAsiaEastStandardTime = "North Asia East Standard Time";

            /// <summary>
            ///     (UTC+08:00) Kuala Lumpur, Singapore
            /// </summary>
            public static string SingaporeStandardTime = "Singapore Standard Time";

            /// <summary>
            ///     (UTC+08:00) Perth
            /// </summary>
            public static string W_AustraliaStandardTime = "W. Australia Standard Time";

            /// <summary>
            ///     (UTC+08:00) Taipei
            /// </summary>
            public static string TaipeiStandardTime = "Taipei Standard Time";

            /// <summary>
            ///     (UTC+08:00) Ulaanbaatar
            /// </summary>
            public static string UlaanbaatarStandardTime = "Ulaanbaatar Standard Time";

            /// <summary>
            ///     (UTC+08:30) Pyongyang
            /// </summary>
            public static string NorthKoreaStandardTime = "North Korea Standard Time";

            /// <summary>
            ///     (UTC+08:45) Eucla
            /// </summary>
            public static string AusCentralW_StandardTime = "Aus Central W. Standard Time";

            /// <summary>
            ///     (UTC+09:00) Chita
            /// </summary>
            public static string TransbaikalStandardTime = "Transbaikal Standard Time";

            /// <summary>
            ///     (UTC+09:00) Osaka, Sapporo, Tokyo
            /// </summary>
            public static string TokyoStandardTime = "Tokyo Standard Time";

            /// <summary>
            ///     (UTC+09:00) Seoul
            /// </summary>
            public static string KoreaStandardTime = "Korea Standard Time";

            /// <summary>
            ///     (UTC+09:00) Yakutsk
            /// </summary>
            public static string YakutskStandardTime = "Yakutsk Standard Time";

            /// <summary>
            ///     (UTC+09:30) Adelaide
            /// </summary>
            public static string Cen_AustraliaStandardTime = "Cen. Australia Standard Time";

            /// <summary>
            ///     (UTC+09:30) Darwin
            /// </summary>
            public static string AUSCentralStandardTime = "AUS Central Standard Time";

            /// <summary>
            ///     (UTC+10:00) Brisbane
            /// </summary>
            public static string E_AustraliaStandardTime = "E. Australia Standard Time";

            /// <summary>
            ///     (UTC+10:00) Canberra, Melbourne, Sydney
            /// </summary>
            public static string AUSEasternStandardTime = "AUS Eastern Standard Time";

            /// <summary>
            ///     (UTC+10:00) Guam, Port Moresby
            /// </summary>
            public static string WestPacificStandardTime = "West Pacific Standard Time";

            /// <summary>
            ///     (UTC+10:00) Hobart
            /// </summary>
            public static string TasmaniaStandardTime = "Tasmania Standard Time";

            /// <summary>
            ///     (UTC+10:00) Vladivostok
            /// </summary>
            public static string VladivostokStandardTime = "Vladivostok Standard Time";

            /// <summary>
            ///     (UTC+10:30) Lord Howe Island
            /// </summary>
            public static string LordHoweStandardTime = "Lord Howe Standard Time";

            /// <summary>
            ///     (UTC+11:00) Bougainville Island
            /// </summary>
            public static string BougainvilleStandardTime = "Bougainville Standard Time";

            /// <summary>
            ///     (UTC+11:00) Chokurdakh
            /// </summary>
            public static string RussiaTimeZone10 = "Russia Time Zone 10";

            /// <summary>
            ///     (UTC+11:00) Magadan
            /// </summary>
            public static string MagadanStandardTime = "Magadan Standard Time";

            /// <summary>
            ///     (UTC+11:00) Norfolk Island
            /// </summary>
            public static string NorfolkStandardTime = "Norfolk Standard Time";

            /// <summary>
            ///     (UTC+11:00) Sakhalin
            /// </summary>
            public static string SakhalinStandardTime = "Sakhalin Standard Time";

            /// <summary>
            ///     (UTC+11:00) Solomon Is., New Caledonia
            /// </summary>
            public static string CentralPacificStandardTime = "Central Pacific Standard Time";

            /// <summary>
            ///     (UTC+12:00) Anadyr, Petropavlovsk-Kamchatsky
            /// </summary>
            public static string RussiaTimeZone11 = "Russia Time Zone 11";

            /// <summary>
            ///     (UTC+12:00) Auckland, Wellington
            /// </summary>
            public static string NewZealandStandardTime = "New Zealand Standard Time";

            /// <summary>
            ///     (UTC+12:00) Coordinated Universal Time+12
            /// </summary>
            public static string UTC_plus_12 = "UTC+12";

            /// <summary>
            ///     (UTC+12:00) Fiji
            /// </summary>
            public static string FijiStandardTime = "Fiji Standard Time";

            /// <summary>
            ///     (UTC+12:00) Petropavlovsk-Kamchatsky - Old
            /// </summary>
            public static string KamchatkaStandardTime = "Kamchatka Standard Time";

            /// <summary>
            ///     (UTC+12:45) Chatham Islands
            /// </summary>
            public static string ChathamIslandsStandardTime = "Chatham Islands Standard Time";

            /// <summary>
            ///     (UTC+13:00) Coordinated Universal Time+13
            /// </summary>
            public static string UTC_plus_13 = "UTC+13";

            /// <summary>
            ///     (UTC+13:00) Nuku'alofa
            /// </summary>
            public static string TongaStandardTime = "Tonga Standard Time";

            /// <summary>
            ///     (UTC+13:00) Samoa
            /// </summary>
            public static string SamoaStandardTime = "Samoa Standard Time";

            /// <summary>
            ///     (UTC+14:00) Kiritimati Island
            /// </summary>
            public static string LineIslandsStandardTime = "Line Islands Standard Time";
        }

        #endregion Defined Structs
    }
}

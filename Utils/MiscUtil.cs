using StepHR365.Utils;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace StepronEOP.Utils
{
    public static class MiscUtil
    {

        public static string GetMethodName(this object type, [CallerMemberName] string caller = null, bool fullName = false)
        {
            if (type == null) return "Unknown";
            var name = fullName ? type.GetType().FullName : type.GetType().Name;
            return $"{name}.{caller}()";
        }

        public static int GetInt(object value, int defValue)
        {
            return GetInt(value, defValue, NumberStyles.Integer);
        }


        public static bool GetBool(object value, bool defValue)
        {
            if (value is bool)
                return (bool)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {
                    if (value.ToString().Trim() == "1")
                        return true;

                    if (bool.TryParse(value as string, out bool result))
                        return result;
                    return defValue;
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (bool)value;
            }
            catch
            {
                return defValue;
            }
        }
        /// <summary>
        /// Returns the int value of the object, or <c>devValue</c> if conversion is not possible
        /// </summary>
        public static int GetInt(object value, int defValue, NumberStyles style)
        {
            if (value is int)
                return (int)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {
                    //is not convertin 20.0
                    //if (int.TryParse(value as string, style, CultureInfo.InvariantCulture, out int result))
                    //    return result;
                    //return defValue;

                    return (int)GetDecimal(value, defValue);
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (int)value;
            }
            catch
            {
                return defValue;
            }
        }

        public static long GetLong(object value, long defValue)
        {
            if (value is long)
                return (long)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {

                    if (long.TryParse(value as string, out long result))
                        return result;
                    return defValue;
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (long)value;
            }
            catch
            {
                return defValue;
            }
        }

        public static decimal GetDecimal(object value, decimal defValue)
        {
            if (value is decimal)
                return (decimal)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {

                    if (decimal.TryParse(value as string, out decimal result))
                        return result;

                    return defValue;
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (decimal)value;
            }
            catch
            {
                return defValue;
            }
        }

        public static DateTime GetDate(object value, DateTime defValue)
        {
            if (value is DateTime)
                return (DateTime)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {

                    if (DateTime.TryParse(value as string, out DateTime result))
                        return result;

                    return defValue;
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (DateTime)value;
            }
            catch
            {
                return defValue;
            }
        }

        public static DateTime? GetDateOrNull(object value, DateTime? defValue)
        {
            if (value is DateTime)
                return (DateTime)value;
            if (value == null || value is DBNull)
                return defValue;
            if (value is string)
                try
                {

                    if (DateTime.TryParse(value as string, out DateTime result))
                        return result;

                    return defValue;
                }
                catch
                {
                    return defValue;
                }
            try
            {
                return (DateTime)value;
            }
            catch
            {
                return defValue;
            }
        }

        public static DateTime? GetDateFromQB(string qbDate)
        {
            if (String.IsNullOrEmpty(qbDate))
                return null;

            long ll = GetLong(qbDate, 0);
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(ll);
            DateTime dateTime = dateTimeOffset.Date;
            return dateTime;
        }

        public static DateTime? GetDateTimeFromQB(string qbDate)
        {
            if (String.IsNullOrEmpty(qbDate))
                return null;

            long ll = GetLong(qbDate, 0);
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(ll);
            DateTime dateTime = dateTimeOffset.DateTime.AddHours(-6);
            return dateTime;
        }

        public static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public static DateTime GetEndOfTheWeek(DateTime refDate)
        {
            DayOfWeek day = refDate.DayOfWeek;
            int days = day - DayOfWeek.Monday;
            DateTime start = refDate.AddDays(-(days + 1));
            DateTime end = start.AddDays(6);

            return end;
        }

        public static DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }

        public static string GetUniqueName()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }

        public static string GetUniqueString(int size)
        {
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";

            String randomstring = "";

            Random res = new Random();

            for (int i = 0; i < size; i++)
            {

                // Selecting a index randomly
                int x = res.Next(str.Length);

                // Appending the character at the 
                // index to the random alphanumeric string.
                randomstring = randomstring + str[x];
            }

            return randomstring.ToUpper();
        }

        public static ResponseModel<string> HandleControllerError(string innerMessage, string message, string logMessage)
        {
            var obj = new ResponseModel<string>
            {
                Message = "API: " + (String.IsNullOrEmpty(innerMessage) ? message : innerMessage),
                Status = false,
                Data = String.Empty
            };

            return obj;
        }

        public static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }

    }
}

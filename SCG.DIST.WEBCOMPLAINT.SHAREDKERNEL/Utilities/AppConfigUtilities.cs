using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Utilities
{
    public class AppConfigUtilities
    {
        public static IConfiguration _configuration { get; set; }

        public static T GetAppConfig<T>(string key)
        {
            var value = AppConfigUtilities._configuration.GetSection("AppSettings:" + key).Value;
            if (string.IsNullOrEmpty(value)) throw new Exception(string.Format("Config {0} value not found", key));
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                var result = (T)converter.ConvertFromString(null,
                    CultureInfo.InvariantCulture, value);
                return result;

            }
            catch (Exception)
            {
                throw new Exception(string.Format("Invalid Convert type Value:{0}", key));
            }


        }
    }
}

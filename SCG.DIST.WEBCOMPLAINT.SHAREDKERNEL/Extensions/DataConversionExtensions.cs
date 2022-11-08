using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Extensions
{
    public static class DataConversionExtensions
    {
        public static string ListToString(this List<string> strs)
        {
            if (strs.AnyAndNotNull() == false) return "";

            var r = string.Join(",", strs);
            return r;
        }

        public static bool AnyAndNotNull<T>(this IEnumerable<T> l)
        {
            if (l == null) return false;
            if (l.Any() == false) return false;
            return true;
        }

        public static T ToObject<T>(this string str)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception e)
            {
                var ex = new Exception("Can't deserialzeObject object:" + str);
                throw ex;
            }
        }

        public static string ListToHtmlString(this List<string> strs)
        {
            var str = new StringBuilder();
            str.Append("<ul>");
            if (strs.AnyAndNotNull())
            {
                strs.ForEach(s =>
                {
                    str.Append($"<li>{s}</li>");
                });
            }
            else
            {
                return "";
            }
            str.Append("</ul>");
            return str.ToString();
        }
    }
}

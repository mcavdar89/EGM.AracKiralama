using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToByteArray<T>(this T obj)
        {
            if (obj == null)
            {
                return null;
            }
            return JsonSerializer.SerializeToUtf8Bytes(obj);
        }

        public static T? ToObject<T>(this byte[] arrBytes)
        {
            if (arrBytes == null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(arrBytes);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublisherApiSubscriberFunctions.src.Util
{
    class JsonUtil
    {
        public static string SerializeContent<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public static T DeserializeContent<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}

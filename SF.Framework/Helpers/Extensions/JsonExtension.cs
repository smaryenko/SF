using System;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SF.Helpers.Extensions
{
    public static class JsonExtensions
    {
        public static T TryDeserializeJson<T>(this HttpResponseMessage httpResponse)
        {
            T result = default(T);
            try
            {
                result = JsonConvert.DeserializeObject<T>(httpResponse.Content.ReadAsStringAsync().Result);

            }
            catch (Exception e)
            {
                Assert.Fail("Unable to deserialize response content: " + e.Message);
            }

            return result;
        }
    }
}

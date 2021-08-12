using System.Net;
using System.Net.Http;
using SF.Helpers.Configuration;
using Flurl;
using NUnit.Framework;

namespace SF.Api
{
    public class BaseApi
    {
        public static readonly Url BaseUrl = ConfigurationProvider.TestsConfiguration["ApiUrl"];
        public HttpResponseMessage result;

        public void AssertStatusCode(HttpStatusCode expectedStatus)
        {
            Assert.AreEqual(expectedStatus, result.StatusCode, "Status code is not as expected");
        }
    }
}

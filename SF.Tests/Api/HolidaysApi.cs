using SF.Helpers.Attributes;
using Flurl;
using Flurl.Http;

namespace SF.Api
{
    [RelativeUrl("/publicholidays")]
    public class HolidaysApi : BaseApi
    {
        Url classUrl;

        public HolidaysApi()
        {
            classUrl = BaseUrl.Clone().AppendPathSegments(GetType().GetRelativeUrlAttribute());
        }

        public void GetHolidays(int year, string country)
        {
            var testUrl = classUrl.Clone().AppendPathSegments(year, country);

            result = testUrl.GetAsync().Result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using SF.Api;
using SF.Helpers.Extensions;
using SF.Models;

namespace SF.Tests
{
    public class HolidaysTests
    {
        HolidaysApi holidaysApi;

        [OneTimeSetUp]
        public void HolidaysTestsSetup()
        {
            holidaysApi = new HolidaysApi();
        }

        [Test]
        public void Test_NL_NewYear_Success(
            [Range(2015, 2025, 1)] int year,
            [Values("NL")] string country)
        {
            //Arrange

            //Act
            holidaysApi.GetHolidays(year, country);
            holidaysApi.AssertStatusCode(HttpStatusCode.OK);

            //Assert
            List<Holiday> holidays = holidaysApi.result.TryDeserializeJson<List<Holiday>>();
            Assert.IsNotNull(holidays.SingleOrDefault(h => h.Name == "New Year's Day"),
                "New Year is not present in the list");
        }

        [Test]
        public void Test_NL_AscentionDay_OnThursday_Success(
            [Range(2000, 2025, 1)] int year,
            [Values("NL")] string country)
        {
            //Arrange

            //Act
            holidaysApi.GetHolidays(year, country);
            holidaysApi.AssertStatusCode(HttpStatusCode.OK);

            //Assert
            List<Holiday> holidays = holidaysApi.result.TryDeserializeJson<List<Holiday>>();
            Holiday ascentionDay = holidays.SingleOrDefault(h => h.LocalName == "Hemelvaartsdag");
            Assert.IsNotNull(ascentionDay, "Ascention day is not present in the list");

            Assert.AreEqual(DayOfWeek.Thursday, ascentionDay.Date.DayOfWeek);
        }
    }
}

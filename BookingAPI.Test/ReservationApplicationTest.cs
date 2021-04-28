using BookingAPI.Test.ResultObjects;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace BookingAPI.Test
{
    /// <summary>
    /// For automated testing, data must be previously inserted into the database
    /// </summary>
    public class ReservationApplicationTest : IClassFixture<WebApplicationFactory<Services.Api.Startup>>
    {
        #region Attributes
        private readonly WebApplicationFactory<BookingAPI.Services.Api.Startup> _factory;
        #endregion

        #region Constructors
        public ReservationApplicationTest(WebApplicationFactory<BookingAPI.Services.Api.Startup> factory)
        {
            _factory = factory;
        }
        #endregion

        #region Tests Methods
        [Fact]
        public async void ShouldSearchBookingByCode()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var responseList = await client.GetAsync($"/api/Reservation/GetListReservationsAsync?checkIn=2021-01-01&checkOut=2021-12-31");
            var jsonResultList = responseList.Content.ReadAsStringAsync().Result;
            var reservationList = JsonConvert.DeserializeObject<List<ReservationSimplified>>(jsonResultList);

            var response = await client.GetAsync($"/api/Reservation/SearchBookingByCodeAsync?code={reservationList.FirstOrDefault().ReservationCode}");
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var reservation = JsonConvert.DeserializeObject<ReservationSimplified>(jsonResult);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(reservationList.FirstOrDefault().ReservationCode, reservation.ReservationCode);
        }

        [Fact]
        public async void ShouldGetListReservationsAsync()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/Reservation/GetListReservationsAsync?checkIn=2021-04-01&checkOut=2021-05-30");

            var jsonResult = response.Content.ReadAsStringAsync().Result;

            var reservation = JsonConvert.DeserializeObject<List<ReservationSimplified>>(jsonResult);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.True(reservation.Count > 0);
        }

        [Fact]
        public async void ShouldCheckAvailableAsync()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/Reservation/CheckAvailableAsync?checkIn={DateTime.Now.AddDays(10).Date.ToShortDateString()}&checkOut={DateTime.Now.AddDays(12).Date.ToShortDateString()}");

            var jsonResult = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("true", jsonResult);
        }

        [Fact]
        public async void ShouldCancelAsync()
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var responseList = await client.GetAsync($"/api/Reservation/GetListReservationsAsync?checkIn=2021-01-01&checkOut=2021-12-31");
            var jsonResultList = responseList.Content.ReadAsStringAsync().Result;
            var reservationList = JsonConvert.DeserializeObject<List<ReservationSimplified>>(jsonResultList);

            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("code", reservationList.FirstOrDefault().ReservationCode),
            });

            var response = await client.PatchAsync($"/api/Reservation/CancelAsync?code={reservationList.FirstOrDefault().ReservationCode}", stringContent);
            var jsonResult = response.Content.ReadAsStringAsync().Result;

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("true", jsonResult);
        }
        #endregion
    }
}

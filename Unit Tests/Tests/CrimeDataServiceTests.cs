using System.Net;
using System.Text.Json;
using UKCrimeApp.Models;
using UKCrimeApp.Services;
using Unit_Tests.Helpers;
using Xunit;

namespace Unit_Tests.Tests
{
    public class CrimeDataServiceTests
    {
        public static async Task GetCrimesAsync_ReturnsCrimes(string latitude, string longitude, string date)
        {
            // Arrange
            var expectedCrimes = new List<CrimeData>();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedCrimes))
            };

            var mockHttpMessageHandler = new MockHttpMessageHandler(response);
            var httpClient = new HttpClient(mockHttpMessageHandler);

            var crimeDataService = new CrimeDataService(httpClient);

            // Act
            var actualCrimes = await crimeDataService.GetCrimesAsync(latitude, longitude, date);

            // Assert
            Xunit.Assert.Equal(expectedCrimes, actualCrimes);
        }

        public static async Task GetCrimeOutcomeAsync_ReturnsExpectedOutcome(
            string persistentId,
            string expectedCategory,
            string expectedLocationType,
            string expectedStreetName,
            string expectedCrimeMonth)
        {
            // Arrange
            var expectedCrime = new CrimeData
            {
                Category = expectedCategory,
                LocationType = expectedLocationType,
                Location = new Location
                {
                    Street = new Street { Name = expectedStreetName }
                },
                Month = expectedCrimeMonth
            };

            var expectedOutcome = new CrimeOutcome
            {
                Outcomes = new List<Outcome>(),
                Crime = expectedCrime
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(expectedOutcome))
            };

            var mockHttpMessageHandler = new MockHttpMessageHandler(response);
            var httpClient = new HttpClient(mockHttpMessageHandler);
            var crimeDataService = new CrimeDataService(httpClient);

            // Act
            var actualOutcome = await crimeDataService.GetCrimeOutcomeAsync(persistentId);

            // Assert
            Xunit.Assert.Equal(expectedCategory, actualOutcome.Crime.Category);
            Xunit.Assert.Equal(expectedLocationType, actualOutcome.Crime.LocationType);
            Xunit.Assert.Equal(expectedStreetName, actualOutcome.Crime.Location.Street.Name);
            Xunit.Assert.Equal(expectedCrimeMonth, actualOutcome.Crime.Month);
        }
    }
}
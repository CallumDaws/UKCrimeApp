using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Unit_Tests.Tests
{
    public class CrimeDataServiceTestRunner
    {
        [Fact]
        public async Task GetCrimesAsync_ReturnsCrimes_ForLondonJanuary()
        {
            await CrimeDataServiceTests.GetCrimesAsync_ReturnsCrimes("51.5074", "-0.1278", "2021-01");
        }

        [Fact]
        public async Task GetCrimesAsync_ReturnsCrimes_ForBerlinFebruary()
        {
            await CrimeDataServiceTests.GetCrimesAsync_ReturnsCrimes("52.5200", "13.4050", "2021-02");
        }

        [Fact]
        public async Task GetCrimesAsync_ReturnsCrimes_ForNewYorkMarch()
        {
            await CrimeDataServiceTests.GetCrimesAsync_ReturnsCrimes("40.7128", "-74.0060", "2021-03");
        }

        [Fact]
        public async Task GetCrimeOutcomeAsync_ForShopliftingSupermarket()
        {
            await CrimeDataServiceTests.GetCrimeOutcomeAsync_ReturnsExpectedOutcome("8cbcbb2e7f55e847287173eb9145ee0353f8f427a2fe663544b214c65158fa31", "shoplifting", 
                                                                                    "Force", "On or near Supermarket", "2021-01");
        }

    }
}

using System.Globalization;
using System.Net.Http.Json;
using UKCrimeApp.Models;

namespace UKCrimeApp.Services
{
    public class CrimeDataService
    {
        private readonly HttpClient _httpClient;

        public CrimeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CrimeData>> GetCrimesAsync(string lat, string lng, string date)
        {
            var url = $"https://data.police.uk/api/crimes-street/all-crime?lat={lat}&lng={lng}&date={date}";
            var crimes = await _httpClient.GetFromJsonAsync<List<CrimeData>>(url) ?? new List<CrimeData>();

            // Format category for each crime
            foreach (var crime in crimes)
            {
                crime.Category = FormatCategory(crime.Category);
            }

            return crimes;
        }

        private string FormatCategory(string category)
        {
            // Replace dashes with spaces and capitalize the first letter of each word
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(category.Replace("-", " "));
        }

        //Groups by category to display on summary page
        public Dictionary<string, int> GroupCrimesByCategory(List<CrimeData> crimes)
        {
            return crimes.GroupBy(c => c.Category)
                         .ToDictionary(g => g.Key, g => g.Count());
        }

        //Get specific crimes details and the outcome of the crime
        public async Task<CrimeOutcome> GetCrimeOutcomeAsync(string persistentId)
        {
            var url = $"https://data.police.uk/api/outcomes-for-crime/{persistentId}";
            return await _httpClient.GetFromJsonAsync<CrimeOutcome>(url);
        }

        //Filters crimes by their category to display on category details page
        public List<CrimeData> FilterCrimesByCategory(List<CrimeData> crimes, string category)
        {
            return crimes.Where(crime => crime.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}

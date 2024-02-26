using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UKCrimeApp.Models;
using UKCrimeApp.Pages;

namespace UKCrimeApp.Services { 
public class CrimeDataService
{
    private readonly HttpClient _httpClient;

    public CrimeDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Gets full list of crimes based on user input
    public async Task<List<CrimeData>> GetCrimesAsync(string lat, string lng, string date)
    {
        var url = $"https://data.police.uk/api/crimes-street/all-crime?lat={lat}&lng={lng}&date={date}";
        var crimes = await _httpClient.GetFromJsonAsync<List<CrimeData>>(url);
        return crimes ?? new List<CrimeData>();
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

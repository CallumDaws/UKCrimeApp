using UKCrimeApp.Models;

namespace UKCrimeApp.Services
{
    public class AppState
    {
        public CrimeSearchModel CurrentSearch { get; set; } = new CrimeSearchModel();
    }

}

using System.Collections.Generic;
using UKCrimeApp.Models;

namespace UKCrimeApp.Services
{
    public class AppState
    {
        public CrimeSearchModel CurrentSearch { get; set; } = new CrimeSearchModel();
        public List<CrimeData> CurrentCrimes { get; set; } = new List<CrimeData>();
    }
}

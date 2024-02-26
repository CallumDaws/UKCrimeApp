namespace UKCrimeApp.Models
{
    public class CrimeData
    {
        public string Category { get; set; }
        public string LocationType { get; set; }
        public Location Location { get; set; }
        public string Context { get; set; }
        public string OutcomeStatus { get; set; }
        public string persistent_id { get; set; }
        public int Id { get; set; }
        public string LocationSubtype { get; set; }
        public string Month { get; set; }
    }

    public class Location
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Street Street { get; set; }
    }

    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CrimeOutcome
    {
        public List<Outcome> Outcomes { get; set; }
        public CrimeData Crime { get; set; }
    }

    public class Outcome
    {
        public Category Category { get; set; }
        public string Date { get; set; }
        public string? PersonId { get; set; }
    }

    public class Category
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

}


using System;
using System.ComponentModel.DataAnnotations;

namespace UKCrimeApp.Models
{
    public class CrimeSearchModel
    {
        [Required(ErrorMessage = "Latitude is required")]
        [RegularExpression(@"^-?([1-8]?[0-9](\.\d{1,6})?|90(\.0{1,6})?)$", ErrorMessage = "Enter a valid latitude")]
        public string Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required")]
        [RegularExpression(@"^-?((([1-9]?[0-9]|1[0-7][0-9])(\.\d{1,6})?)|180(\.0{1,6})?)$", ErrorMessage = "Enter a valid longitude")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [RegularExpression(@"^\d{4}-(0[1-9]|1[0-2])$", ErrorMessage = "Enter a valid date in YYYY-MM format")]
        public string Date { get; set; }
    }

}

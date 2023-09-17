using System.ComponentModel.DataAnnotations;

namespace ArdonaghTestWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name of the customer")]
        [StringLength(25)]
        public string Name { get; set; } = string.Empty;
        [Range(0, 110, ErrorMessage = "Please enter a value between 0 and 110")]
        public int Age { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Postcode can only contain numbers and letters")]
        public string PostCode { get; set; } = string.Empty;
        [Range(0.00, 2.50, ErrorMessage = "Please enter the Height of the customer between 0 and 2.50 (Meters)")]
        public double Height { get; set; }
    }
}

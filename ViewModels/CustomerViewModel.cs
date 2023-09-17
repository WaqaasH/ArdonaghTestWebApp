using ArdonaghTestWebApp.Models;

namespace ArdonaghTestWebApp.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; } = null!;
        public List<Customer> ExistingCustomers { get; set; } = null!;
    }
}

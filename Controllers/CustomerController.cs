using ArdonaghTestWebApp.InMemoryDatabase;
using ArdonaghTestWebApp.Models;
using ArdonaghTestWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArdonaghTestWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ArdonaghDbContext _ardonaghDbContext;

        public CustomerController(ArdonaghDbContext ardonaghDbContext)
        {
            _ardonaghDbContext = ardonaghDbContext;
        }

        public IActionResult Index()
        {
            CustomerViewModel viewModel = new CustomerViewModel();
            viewModel.ExistingCustomers = _ardonaghDbContext.Customers.ToList();
            return View(viewModel);
        }

        public IActionResult AddEdit(int? id)
        {
            if (id.HasValue)
            {
                var customer = _ardonaghDbContext.Customers.FirstOrDefault(c => c.Id == id.Value);
                return PartialView("../Customer/_AddEdit", customer);
            }

            return PartialView("../Customer/_AddEdit", new Customer());
        }

        // Handle the form submission for Add/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            ModelState.Remove("Id");
            if (!ModelState.IsValid)
            {
                return PartialView("../Customer/_AddEdit", customer);
            }

            if (customer.Id == 0)
            {
                // Add a new customer
                customer.Id = _ardonaghDbContext.Customers.Count() + 1;
                _ardonaghDbContext.Customers.Add(customer);
            }
            else
            {
                // Update an existing customer
                var existingCustomer = _ardonaghDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Age = customer.Age;
                    existingCustomer.Height = customer.Height;
                    existingCustomer.PostCode = customer.PostCode;
                }
            }
            _ardonaghDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
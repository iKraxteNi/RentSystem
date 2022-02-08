using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentSystem.Models;

namespace RentSystem.Controllers
{
    public class TableController : Controller
    {
        private readonly RentDbContext _context;

        public TableController(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult RentTable()
        {
            ViewBag.Customers = _context.Customers.Select(x => new Customer()
                {
                    Id= x.Id,
                    Name = x.Name,
                    Adress = x.Adress,
                    Mobile = x.Mobile,
                    BooksRented = x.BooksRented
                }
            ).ToList();

            ViewBag.Books = _context.Books.Where(z => z.CustomerId != null ).Select(x => new Book()
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Available = x.Available,
                Customer = x.Customer,


            }).ToList();

            return View();
        }

        public IActionResult DeleteRent(long Id)
        {
            var book = _context.Books.Include(x => x.Customer)
                .FirstOrDefault(y => y.Id == Id);
            var customer = book?.Customer;
            if (customer != null)
                book.Customer = null ;
            book.Available = true;
            _context.SaveChanges();

            return RedirectToAction("RentTable");



        }
        
    }
}

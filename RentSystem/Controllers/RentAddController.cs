using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentSystem.Models;

namespace RentSystem.Controllers
{
    public class RentAddController : Controller
    {
        private readonly RentDbContext _context;

        public RentAddController(RentDbContext context)
        {
            _context = context;
        }

        public IActionResult RentAdd()
        {
            ViewBag.Customers = _context.Customers.Select(x => new Customer()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Adress = x.Adress,
                    Mobile = x.Mobile,
                    BooksRented = x.BooksRented
                }
            ).ToList();

            ViewBag.Books = _context.Books.Where(z => z.Available == true).Select(x => new Book()
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Available = x.Available,
                Customer = x.Customer,


            }).ToList();

            return View();

        }

        public IActionResult AddRent(long bookId, long customerId)
        {
            var book = _context.Books.Where(x=>x.Available==true).
                FirstOrDefault(y => y.Id == bookId);
            var customer =_context.Customers.FirstOrDefault(z =>z.Id==customerId);
            book.Customer=customer;

            book.Available = false;
            _context.SaveChanges();

            return RedirectToAction("RentAdd");



        }
    }
}

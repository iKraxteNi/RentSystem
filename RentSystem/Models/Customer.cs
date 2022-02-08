using System.Collections.ObjectModel;

namespace RentSystem.Models
{
    public class Customer
    {
        public Customer()
        {
            BooksRented = new Collection<Book>();
        }
       
        
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Mobile { get; set; }


        public virtual IList<Book> BooksRented { get; set; }


    }
}

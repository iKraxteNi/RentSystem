using System.Diagnostics.CodeAnalysis;

namespace RentSystem.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }

        public long? CustomerId { get; set; }
        
        public virtual Customer? Customer { get; set; }
    }
}

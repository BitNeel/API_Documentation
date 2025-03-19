using System.Data.SqlTypes;

namespace library.core
{
    public class Category:Entity
    {
        public required string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}

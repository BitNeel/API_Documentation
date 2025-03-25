using System.Data.SqlTypes;
using System.Text.Json.Serialization;

namespace library.core
{
    public class Category:Entity
    {
        public required string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Book> Books { get; set; }
    }
}

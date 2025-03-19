using System.Data.SqlTypes;

namespace library.core
{
    public class Book: Entity
    {
        public required string Title { get; set; }
        public DateOnly PublishedOn { get; set; }
        public required string ISBN { get; set; }
        public string? Description { get; set; }

        public required long CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

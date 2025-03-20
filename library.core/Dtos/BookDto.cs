namespace library.core.Dtos
{
    public class BookDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public EntityLink _links { get; set; }
    }

    public class EntityLink
    {
        public string Self { get; set; }
    }
}

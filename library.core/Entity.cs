using System.Data.SqlTypes;

namespace library.core
{
    /// <summary>
    /// Entity is the base interface of all the Model classes in this project. Every model that inherits from entity automatically
    /// gets the primary key [ID] and mantainance columns CreatedOn and UpdatedOn
    /// </summary>
    public class Entity
    {
        public long ID {  get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}
    }
}

using System.Data.SqlTypes;

namespace library.core
{
    /// <summary>
    /// Entity is the base class of all the Model classes in this project. Every model that inherits from entity automatically
    /// gets the primary key [ID] and mantainance columns CreatedOn and UpdatedOn
    /// </summary>
    public abstract class Entity
    {
        protected long ID {  get; set; }
        protected SqlDateTime CreatedOn { get; set; }
        protected SqlDateTime UpdatedOn { get; set;}
    }
}

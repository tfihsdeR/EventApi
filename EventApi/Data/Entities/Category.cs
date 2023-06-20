using EventApi.Core;

namespace EventApi.Data.Entities
{
	public class Category : EntityBase
	{
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
using System.Collections.Generic;

namespace SearchParty.Models
{
    public class Resource : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Uri { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<Tag> Tags { get; set; }

    }
}
namespace SearchParty.Api.Models
{
    using System.Collections.Generic;

    public class Resource : IEntity
    {
        public virtual string Uri { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual int Id { get; set; }
    }
}
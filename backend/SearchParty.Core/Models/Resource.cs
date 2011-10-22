namespace SearchParty.Api.Models
{
    using System.Collections.Generic;

    public class Resource : IEntity
    {
        public virtual string Uri { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tags { get; set; }
        public virtual int Id { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual string ResultType { get; set; }
    }
}
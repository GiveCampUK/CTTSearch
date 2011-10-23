using System;

namespace SearchParty.Core.Models
{
    public class Resource : IEntity
    {
        public virtual string Uri { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tags { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual string ResourceType { get; set; }
        public virtual int Id { get; set; }
    }

    public class SearchQuery : IEntity
    {
        public SearchQuery()
        {
            TimeStamp = DateTime.UtcNow;
        }

        public virtual int Id { get; set; }
        public virtual DateTime TimeStamp { get; set; }
        public virtual string QueryString { get; set; }
        public virtual int ResultsCount { get; set; }
    }
}
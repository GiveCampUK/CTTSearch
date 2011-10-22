namespace SearchParty.Api.Models
{
    using System.Collections.Generic;

    public class SearchResultLink: IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}
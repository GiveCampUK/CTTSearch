namespace SearchParty.Api.Models
{
    using System.Collections.Generic;

    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Blurb { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<SearchResultLink> SearchResultLinks { get; set; }
        public virtual IList<Category> SubCategories { get; set; }
    }
}
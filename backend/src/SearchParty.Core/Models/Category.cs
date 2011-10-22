namespace SearchParty.Core.Models
{
    using System.Collections.Generic;

    public class Category : IEntity
    {
        public virtual string Title { get; set; }
        public virtual string Blurb { get; set; }
        public virtual string Tags { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<SearchResultLink> SearchResultLinks { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual int Id { get; set; }
    }
}
﻿using System.Collections.Generic;

namespace SearchParty.Core.Models
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Blurb { get; set; }
        public virtual string Tags { get; set; }
        public virtual Category Parent { get; set; }
        public virtual IList<SearchResultLink> SearchResultLinks { get; set; }
        public virtual IList<Category> SubCategories { get; set; }
    }
}
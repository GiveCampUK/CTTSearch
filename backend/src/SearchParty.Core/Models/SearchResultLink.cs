using System.Collections.Generic;

namespace SearchParty.Core.Models
{
    public class SearchResultLink: IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tags { get; set; }
    }
}
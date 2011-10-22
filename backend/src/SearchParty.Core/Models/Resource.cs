namespace SearchParty.Core.Models
{
    public class Resource : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Uri { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tags { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string LongDescription { get; set; }
        public virtual string ResourceType { get; set; }
    }
}
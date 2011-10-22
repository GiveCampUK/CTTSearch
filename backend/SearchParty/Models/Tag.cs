namespace SearchParty.Models
{
    public class Tag : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
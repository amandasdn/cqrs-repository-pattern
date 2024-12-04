namespace BookCatalog.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public void SetAsInactive()
        {
            IsActive = false;
        }
    }
}
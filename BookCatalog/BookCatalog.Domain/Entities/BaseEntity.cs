namespace BookCatalog.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsActive { get; private set; }

        public void SetAsInactive()
        {
            IsActive = false;
        }
    }
}
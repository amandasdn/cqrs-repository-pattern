namespace BookCatalog.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<Guid> Add(T entity);
    }
}

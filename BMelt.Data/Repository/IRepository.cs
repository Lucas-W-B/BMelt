namespace BMelt.Data.Repository
{
    public interface IRepository<T>
    {
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> GetAsync();
        public Task<Guid> AddAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task<bool> DeleteAsync(Guid id);
    }
}

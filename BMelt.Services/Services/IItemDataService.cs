namespace BMelt.Services.Services
{
    public interface IItemDataService<T>
    {
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> GetAsync();
        public Task<Guid> AddAsync(T item);
        public Task<T> UpdateAsync(T item);
        public Task<bool> DeleteAsync(Guid id);
    }
}

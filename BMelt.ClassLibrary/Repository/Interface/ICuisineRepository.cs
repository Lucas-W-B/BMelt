using BMelt.ClassLibrary.Models;

namespace BMelt.ClassLibrary.Repository.Interface
{
    public interface ICuisineRepository
    {
        public Task<Cuisine> GetCuisineAsync(Guid id);
        public Task<IEnumerable<Cuisine>> GetCuisinesAsync();
        public Task<Cuisine> AddCuisineAsync(Cuisine cuisine);
        public Task<Cuisine> UpdateCuisineAsync(Cuisine cuisine);
        public Task<bool> DeleteCuisineAsync(Guid id);
    }
}
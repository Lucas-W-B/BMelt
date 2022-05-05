using BMelt.ClassLibrary.Models;
using System.Net.Http.Json;

namespace BMelt.Services.Services
{
    public class RecipeDataService : ItemDataService<Recipe>, IRecipeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _typeName;

        public RecipeDataService(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
            _typeName = "Recipe";
        }

        public async Task<IEnumerable<Recipe>> GetByCuisineAsync(Guid cuisineId) => await _httpClient.GetFromJsonAsync<IEnumerable<Recipe>>($"/{_typeName}/CuisineId/{cuisineId}") ?? throw new KeyNotFoundException();
    }
}

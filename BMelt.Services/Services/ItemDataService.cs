using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BMelt.Services.Services
{
    public class ItemDataService<T> : IItemDataService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _typeName;
        
        public ItemDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _typeName = typeof(T).Name;
        }

        public async Task<T> GetAsync(Guid id) => await _httpClient.GetFromJsonAsync<T>($"/{_typeName}/{id}") ?? throw new KeyNotFoundException();

        public async Task<IEnumerable<T>> GetAsync() => await _httpClient.GetFromJsonAsync<IEnumerable<T>>($"/{_typeName}") ?? throw new KeyNotFoundException();

        public async Task<Guid> AddAsync(T item)
        {
            var serializedItem = new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/{_typeName}", serializedItem);
            var responseItem = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync());
            return typeof(T).GetProperty("Id")?.GetValue(responseItem) as Guid? ?? Guid.Empty;
        }

        public async Task<T> UpdateAsync(T item)
        {
            var id = typeof(T).GetProperty("Id")?.GetValue(item) as Guid? ?? Guid.Empty;
            var response = await _httpClient.PutAsJsonAsync($"/{_typeName}/{id}", item);
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()) ?? throw new KeyNotFoundException();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"/{_typeName}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

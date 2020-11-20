using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using CodingChallengeLike.Domain.Interfaces.Services;
using CodingChallengeLike.Domain.Models.Services;
using System.Text;

namespace CodingChallengeLike.Infra.Services
{
    public class SsoService : ISsoService
    {
        private readonly HttpClient _httpClient;

        public SsoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<object> ConnectToken(AuthenticationRequest auth)
        {
            var response = await _httpClient.PostAsync("connect/token", new StringContent(JsonSerializer.Serialize(auth, new JsonSerializerOptions() { IgnoreNullValues = true }), Encoding.UTF8, "application/json"));
            var stringResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<SsoError>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            return JsonSerializer.Deserialize<AuthenticationResponse>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<object> RegisterClient(RegisterClientRequest client)
        {
            var response = await _httpClient.PostAsync("applications", new StringContent(JsonSerializer.Serialize(client, new JsonSerializerOptions() { IgnoreNullValues = true }), Encoding.UTF8, "application/json"));
            var stringResponse = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<SsoError>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            return JsonSerializer.Deserialize<RegisterClientResponse>(stringResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
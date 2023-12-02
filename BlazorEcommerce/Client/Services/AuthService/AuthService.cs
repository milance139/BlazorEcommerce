
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient http, AuthenticationStateProvider authenticationStateProvider)
        {
            _http = http;
            _authStateProvider = authenticationStateProvider;
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword requestModel)
        {
            var result = await _http.PostAsJsonAsync("api/auth/change-password", requestModel.Password);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin requestModel)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", requestModel);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister requestModel)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", requestModel);

            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}

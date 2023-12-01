namespace BlazorEcommerce.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister requestModel);

        Task<ServiceResponse<string>> Login(UserLogin requestModel);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword requestModel);
    }
}

namespace BlazorEcommerce.Client.Pages
{
    public partial class Profile
    {
        UserChangePassword requestModel = new UserChangePassword();

        string message = string.Empty;
        private string messageCssClass = string.Empty;

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(requestModel);

            message = result.Message;

            if (!result.Success)
                messageCssClass = "text-danger";
            else
                messageCssClass = "text-success";
        }
    }
}

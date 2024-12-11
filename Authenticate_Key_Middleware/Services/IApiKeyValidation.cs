namespace Authenticate_Key_Middleware.Services
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}

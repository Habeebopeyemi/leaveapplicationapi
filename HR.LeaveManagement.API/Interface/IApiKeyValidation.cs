namespace HR.LeaveManagement.API.Interface
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}

namespace BlogProject.Core.Models.Auth
{
    public class AuthenticatedResult
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}

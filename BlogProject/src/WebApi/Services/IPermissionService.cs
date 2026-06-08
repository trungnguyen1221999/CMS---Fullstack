namespace BlogProject.Api.Services
{
    public interface IPermissionService
    {
        public Task<List<string>> GetPermissionByIdAsync(string userId);
    }
}

using BlogProject.Core.Domain.Content;
using BlogProject.Core.Models;
using BlogProject.Core.SeedWorks;

namespace BlogProject.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);

        Task<PageResult<Post>> GetPostPagingAsync(
            string? keyword,
            Guid? categoryId,
            int pageIndex = 1,
            int pageSize = 10
        );
    }
}
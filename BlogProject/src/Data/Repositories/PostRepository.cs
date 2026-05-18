using BlogProject.Core.Domain.Content;
using BlogProject.Core.Repositories;
using BlogProject.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(BlogContext context)
            : base(context) { }

        public Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return _context.Posts.OrderByDescending(p => p.ViewCount).Take(count).ToListAsync();
        }
    }
}
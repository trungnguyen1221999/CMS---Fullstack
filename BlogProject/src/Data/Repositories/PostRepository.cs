using BlogProject.Core.Domain.Content;
using BlogProject.Core.Models;
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

        public async Task<PageResult<Post>> GetPostPagingAsync(
            string? keyword,
            Guid? categoryId,
            int pageIndex = 1,
            int pageSize = 10
        )
        {
            var query = _context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }
            var totalRow = await query.CountAsync();
            query = query
                .OrderByDescending(p => p.DateCreated)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
            return new PageResult<Post>
            {
                Result = await query.ToListAsync(),
                CurrentPage = pageIndex,
                PageSize = pageSize,
                RowCount = totalRow,
            };
        }
    }
}
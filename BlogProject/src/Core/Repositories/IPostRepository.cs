using System;
using System.Collections.Generic;
using System.Text;
using BlogProject.Core.Domain.Content;
using BlogProject.Core.SeedWorks;

namespace BlogProject.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}
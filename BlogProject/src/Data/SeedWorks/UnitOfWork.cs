using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BlogProject.Core.Repositories;
using BlogProject.Core.SeedWorks;
using BlogProject.Data.Repositories;

namespace BlogProject.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        public IPostRepository Posts { get; private set; }

        public UnitOfWork(BlogContext context, IMapper mapper)
        {
            _context = context;
            Posts = new PostRepository(_context, mapper);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
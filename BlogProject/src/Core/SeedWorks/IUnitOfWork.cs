using System;
using System.Collections.Generic;
using System.Text;
using BlogProject.Core.Repositories;

namespace BlogProject.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        Task<int> CompleteAsync();
    }
}
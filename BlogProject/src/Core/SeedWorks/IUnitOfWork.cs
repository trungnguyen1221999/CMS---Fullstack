using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
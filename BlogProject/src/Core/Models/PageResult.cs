using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.Models
{
    public class PageResult<T> : PageResultBase
        where T : class
    {
        public List<T> Result { get; set; }

        public PageResult()
        {
            Result = new List<T>();
        }
    }
}
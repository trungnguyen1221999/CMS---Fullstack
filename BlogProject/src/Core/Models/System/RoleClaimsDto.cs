using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.Models.System
{
    public class RoleClaimsDto
    {
        public string Type { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool Selected { get; set; } 
    }
}

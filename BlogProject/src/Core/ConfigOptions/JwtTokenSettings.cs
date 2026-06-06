using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core.ConfigOptions
{
    public class JwtTokenSettings
    {
        public string Key { get; set; } = string.Empty;
        
        public string Issuer {  get; set; } = string.Empty;

        public string Audience {  get; set; } = string.Empty;

        public int ExpireInHours { get; set; }
    }
}

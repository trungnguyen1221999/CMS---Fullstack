using AutoMapper;
using BlogProject.Core.Domain.Content;

namespace BlogProject.Core.Models.Content
{
    public class CreateUpdatePostRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Thumbnail { get; set; }
        public Guid CategoryId { get; set; }

        public string? Content { get; set; }

        public string? Source { get; set; }

        public string? Tags { get; set; }

        public string? SeoDescription { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<CreateUpdatePostRequest, Post>();
            }
        }
    }
}
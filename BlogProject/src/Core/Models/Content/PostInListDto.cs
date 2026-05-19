using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlogProject.Core.Domain.Content;

namespace BlogProject.Core.Models.Content
{
    public class PostInListDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? Thumbnail { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public string CategorySlug { set; get; } = string.Empty;

        public string CategoryName { set; get; } = string.Empty;
        public string AuthorUserName { set; get; } = string.Empty;
        public string AuthorName { set; get; } = string.Empty;

        public PostStatus Status { set; get; }
        public bool IsPaid { get; set; }
        public double RoyaltyAmount { get; set; }
        public DateTime? PaidDate { get; set; }

        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Post, PostInListDto>();
            }
        }
    }
}
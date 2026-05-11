using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Slug { get; set; } = string.Empty;

        [Required]
        public string? Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(500)]
        public string Thumbnail { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Source { get; set; }

        public PostStatus Status { get; set; }
        public int ViewCount { get; set; }

        [MaxLength(200)]
        public string? Tags { get; set; }

        [MaxLength(300)]
        public string? SeoDescription { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid? ApprovedUserId { get; set; }
        public bool IsPaid { get; set; }
        public decimal RoyaltyAmount { get; set; }
    }

    public enum PostStatus
    {
        Draft = 1,
        Cancelled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublish = 5,
        Published = 6,
    }
}
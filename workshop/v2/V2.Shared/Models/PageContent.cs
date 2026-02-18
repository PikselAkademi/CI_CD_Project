using System.ComponentModel.DataAnnotations;

namespace V2.Shared.Models;

public class PageContent
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Slug { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [MaxLength(5000)]
    public string Body { get; set; } = string.Empty;

    [Required]
    [MaxLength(80)]
    public string UpdatedBy { get; set; } = "System";

    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}

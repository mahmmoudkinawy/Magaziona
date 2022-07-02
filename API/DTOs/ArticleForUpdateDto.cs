namespace API.DTOs;
public class ArticleForUpdateDto
{
    [Required]
    [MaxLength(70)]
    public string Title { get; set; }

    [Required]
    [MaxLength(3000)]
    [MinLength(50)]
    public string Contents { get; set; }

    [Required]
    [MaxLength(300)]
    [MinLength(30)]
    public string Summary { get; set; }
}

namespace API.DTOs;
public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Contents { get; set; }
    public string Summary { get; set; }
    public string ImageUrl { get; set; }
}

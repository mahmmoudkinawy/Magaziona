namespace API.Entities;
public class ImageEntity
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string PublishId { get; set; }

    [ForeignKey(nameof(ArticleId))]
    public ArticleEntity ArticleEntity { get; set; }
    public Guid ArticleId { get; set; }
}

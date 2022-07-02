namespace API.Controllers;

[Route("api/images")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly MagazineDbContext _magazineDbContext;
    private readonly IImageService _imageService;

    public ImagesController(MagazineDbContext magazineDbContext, IImageService imageService)
    {
        _magazineDbContext = magazineDbContext;
        _imageService = imageService;
    }

    [HttpPost("{articleId}/add-image")]
    public async Task<IActionResult> UploadImageForArticle([FromRoute] Guid articleId,
        [FromForm] IFormFile file)
    {
        var articleFromDb = await _magazineDbContext.Articles.FindAsync(articleId);

        if (articleFromDb == null) return NotFound("The Article Id was not found!!");

        var result = await _imageService.AddImageAsync(file);

        if (result.Error != null) return BadRequest(result.Error.Message);

        var imageToCreated = new ImageEntity
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublishId = result.PublicId,
            ArticleId = articleFromDb.Id
        };

        _magazineDbContext.Images.Add(imageToCreated);
        await _magazineDbContext.SaveChangesAsync();

        return Ok($"Image was added to the Article with this Id: {articleId}");
    }

    [HttpDelete("{articleId}/remove-image-for-article")]
    public async Task<IActionResult> DeleteImageFor([FromRoute] Guid articleId)
    {
        var articleFromDb = await _magazineDbContext.Articles
            .Include(i => i.Image)
            .FirstOrDefaultAsync(a => a.Id == articleId);

        if (articleFromDb == null) return NotFound("The Article Id was not found!!");

        var imageFromDb = articleFromDb.Image;

        if (imageFromDb == null) return NotFound("Image was not found");

        var result = await _imageService.DeleteImageAsync(imageFromDb.PublishId);

        if (result.Error != null) return BadRequest(result.Error.Message);

        _magazineDbContext.Images.Remove(imageFromDb);
        await _magazineDbContext.SaveChangesAsync();

        return Ok("Done deleted successfully");
    }

}

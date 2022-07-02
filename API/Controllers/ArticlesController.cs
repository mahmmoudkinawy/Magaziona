namespace API.Controllers;

[ApiController]
[Route("api/articles")]
public class ArticlesController : ControllerBase
{
    private readonly MagazineDbContext _magazineDbContext;
    private readonly IMapper _mapper;

    public ArticlesController(MagazineDbContext magazineDbContext, IMapper mapper)
    {
        _magazineDbContext = magazineDbContext;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
    {
        var result = _mapper.Map<IEnumerable<ArticleDto>>(
            await _magazineDbContext.Articles
            .Include(i => i.Image)
            .AsNoTracking()
            .ToListAsync());

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetArticle")]
    public async Task<ActionResult<ArticleDto>> GetArticle([FromRoute] Guid id)
    {
        var articleFromDb = await _magazineDbContext.Articles
            .Include(i => i.Image)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        if (articleFromDb == null) return NotFound();

        return Ok(_mapper.Map<ArticleDto>(articleFromDb));
    }

    [HttpPost]
    [Authorize(Roles = Constants.Admin)]
    public async Task<ActionResult<ArticleDto>> PostArticle(
        [FromBody] ArticleForCreationDto articleForCreationDto)
    {
        var finalArticleEntity = _mapper.Map<ArticleEntity>(articleForCreationDto);

        _magazineDbContext.Articles.Add(finalArticleEntity);
        await _magazineDbContext.SaveChangesAsync();

        return CreatedAtRoute(nameof(GetArticle), new { id = finalArticleEntity.Id },
            finalArticleEntity);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = Constants.Admin)]
    public async Task<IActionResult> PutArticle([FromRoute] Guid id,
        [FromBody] ArticleForUpdateDto articleForUpdateDto)
    {
        var articleFromDb = await _magazineDbContext.Articles.FindAsync(id);

        if (articleFromDb == null) return NotFound();

        //The following commented code is working! but it's complicated for this situation
        //_magazineDbContext.Articles.Update(_mapper.Map(articleForUpdateDto, articleFromDb));
        //await _magazineDbContext.SaveChangesAsync();

        articleFromDb.Title = articleForUpdateDto.Title;
        articleFromDb.Summary = articleForUpdateDto.Summary;
        articleFromDb.Contents = articleForUpdateDto.Contents;

        await _magazineDbContext.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Constants.Admin)]
    public async Task<IActionResult> DeleteArticle([FromRoute] Guid id)
    {
        var articleFromDb = await _magazineDbContext.Articles.FindAsync(id);

        if (articleFromDb == null) return NotFound();

        _magazineDbContext.Articles.Remove(articleFromDb);
        await _magazineDbContext.SaveChangesAsync();

        return NoContent();
    }

}

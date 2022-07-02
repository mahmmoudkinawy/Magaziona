namespace API.Data;
public class MagazineDbContext : DbContext
{
    public MagazineDbContext(DbContextOptions<MagazineDbContext> options) : base(options)
    { }

    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<ImageEntity> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ArticleEntity>().HasData(
            new ArticleEntity
            {
                Id = Guid.NewGuid(),
                Contents = "This is content for article 1",
                Summary = "This is summary for article 1",
                Title = "Testing bla bla 1"
            },
            new ArticleEntity
            {
                Id = Guid.NewGuid(),
                Contents = "This is content for article 2",
                Summary = "This is summary for article 2",
                Title = "Testing bla bla 2"
            },
            new ArticleEntity
            {
                Id = Guid.NewGuid(),
                Contents = "This is content for article 3",
                Summary = "This is summary for article 3",
                Title = "Testing bla bla 3"
            });

    }

}

namespace API.Data;
public class MagazineDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public MagazineDbContext(DbContextOptions<MagazineDbContext> options) : base(options)
    { }

    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
}

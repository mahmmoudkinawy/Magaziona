namespace API.DbInitializer;
public class DbInitializer : IDbInitializer
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly MagazineDbContext _context;

    public DbInitializer(UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        MagazineDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task InitializeAsync()
    {
        if (_context.Database.GetPendingMigrations().Any())
        {
            await _context.Database.MigrateAsync();
        }

        if (!await _roleManager.RoleExistsAsync(Constants.Admin))
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole(Constants.Admin),
                new IdentityRole(Constants.User)
            };

            foreach (var role in roles)
                await _roleManager.CreateAsync(role);

            await _userManager.CreateAsync(new IdentityUser
            {
                UserName = "bob@test.com",
                Email = "bob@test.com",
            }, "Pa$$w0rd");

            await _userManager.CreateAsync(new IdentityUser
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
            }, "Pa$$w0rd");

            var adminFromDb = await _userManager.FindByEmailAsync("admin@test.com");
            var userFromDb = await _userManager.FindByEmailAsync("bob@test.com");

            await _userManager.AddToRoleAsync(userFromDb, Constants.User);
            await _userManager.AddToRolesAsync(adminFromDb, new[] { Constants.Admin, Constants.User });
        }


        if (!await _context.Articles.AnyAsync())
        {
            var articles = new List<ArticleEntity>
            {
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
                }
            };

            foreach (var article in articles)
            {
                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
            }
        }

        return;
    }
}

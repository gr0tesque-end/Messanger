using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Server.Data;
using Server.Data.Models;

static async Task Initialize(ServerDbContext context, UserManager<ApplicationUser> userManager)
{
    if (!userManager.Users.Any())
    {
        var users = new List<ApplicationUser>
        {
            new ApplicationUser { 
                UserName = "Admin",
                Email = "admin@gmail.com",
                DisplayName = "End",
                
            },
        };

        foreach (var user in users)
        {
            await userManager.CreateAsync(user, "Password123!");
        }

        await context.SaveChangesAsync();
    }
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ServerDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
});


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ServerDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        await Initialize(context, userManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}*/

app.Run();

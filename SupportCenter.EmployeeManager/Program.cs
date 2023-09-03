

using Microsoft.EntityFrameworkCore;
using SupportCenter.EmployeeManager.Data;
using SupportCenter.EmployeeManager.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<EmployeeManagerDbContext>(
    opt => opt.UseSqlServer(
      //reads connection string from appsettions.json and passed to UseSqlServer method 
      builder.Configuration.GetConnectionString("EmployeeManagerDb")));
//contans the page you where on when you you clicked edit to use in navigation back to
builder.Services.AddScoped<StateContainer>();

var app = builder.Build();
// Don't use this in production just useful for development. With this approach you can not roll back the changes 
await EnsureDatabaseIsMigrated(app.Services);
async Task EnsureDatabaseIsMigrated(IServiceProvider services)
{
    using var scope = services.CreateScope();
    using var ctx = scope.ServiceProvider.GetService<EmployeeManagerDbContext>();
    if (ctx is not null)
    {
        await ctx.Database.MigrateAsync();
    }

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

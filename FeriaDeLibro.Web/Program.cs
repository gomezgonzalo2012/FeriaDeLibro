using FeriaDeLibro.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
//contexto de la base de datos
builder.Services.AddDbContext<FeriaDeLibroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeriaDeLibroConnection"))
);

var app = builder.Build();
// creacion de la base de datos al ejecutar 
using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<FeriaDeLibroContext>();
    context.Database.Migrate(); 
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using FeriaDeLibro.Data;
using FeriaDeLibro.Data.Implements;
using FeriaDeLibro.Data.Interfaces;
using FeriaDeLibro.Service.Auth;
using FeriaDeLibro.Service.Implements;
using FeriaDeLibro.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSession();
//contexto de la base de datos
builder.Services.AddDbContext<FeriaDeLibroContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeriaDeLibroConnection"))
);
builder.Services.AddScoped<IEventRepository,EventRepository>();
builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddScoped<IImageUploadService,ImageUploadService>();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30); // limite de session
//    // You might want to only set the application cookies over a secure connection:
//    //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    //options.Cookie.SameSite = SameSiteMode.Strict;
//    //options.Cookie.HttpOnly = true;
//    // Make the session cookie essential
//    //options.Cookie.IsEssential = true;
//    options.Cookie.Name = ".FeriaDeLibro.Web.Session"; // <--- Add line
//    options.Cookie.IsEssential = true;
//    //options.Cookie.HttpOnly = true;
//    //options.Cookie.IsEssential = true;
//});

builder.Services.AddHttpContextAccessor(); // permite acceder al context de sesion desde los controladores

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

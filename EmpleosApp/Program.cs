using EmpleosApp.DB;
using EmpleosApp.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using EmpleosApp.Helpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IVacanteRepositorio, VacanteRepository>();
builder.Services.AddTransient<ICategoriaRepositorio, CategoriaRepository>();
builder.Services.AddTransient<ISolicitudRepositorio, SolicitudRepository>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepository>();
builder.Services.AddScoped<IAuthRepositorio, AuthRepository>();
builder.Services.AddScoped<IMailService, MailService>();

// Add services to the container.
builder.Services.AddDbContext<DbEntities>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<MailService>();


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/auth/Login";

    });




var app = builder.Build();




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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

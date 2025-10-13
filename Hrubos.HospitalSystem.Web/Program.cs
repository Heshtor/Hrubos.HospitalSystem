using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Application.Implementation;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.43");
builder.Services.AddDbContext<HospitalSystemDbContext>(options => options.UseMySql(connectionString, serverVersion));

//registrace služeb aplikaèní vrstvy
builder.Services.AddScoped<ISpecializationAppService, SpecializationAppService>();
builder.Services.AddScoped<IExaminationTypeAppService, ExaminationTypeAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

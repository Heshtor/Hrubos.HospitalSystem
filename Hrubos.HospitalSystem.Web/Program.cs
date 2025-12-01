using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Application.Implementation;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Nastavení Serilogu - naètení konfigurace z appsettings.json
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.43");
builder.Services.AddDbContext<HospitalSystemDbContext>(options => options.UseMySql(connectionString, serverVersion));

//Configuration for Identity
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<HospitalSystemDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 1;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = "/Security/Account/Login";
    options.LogoutPath = "/Security/Account/Logout";
    options.SlidingExpiration = true;
});

// configuration of session
builder.Services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    // Make the session cookie essential
    options.Cookie.IsEssential = true;
});

// registrace služeb aplikaèní vrstvy
builder.Services.AddScoped<IFileUploadService, FileUploadService>(serviceProvider => new FileUploadService(serviceProvider.GetService<IWebHostEnvironment>().WebRootPath));
builder.Services.AddScoped<ISpecializationAppService, SpecializationAppService>();
builder.Services.AddScoped<IExaminationTypeAppService, ExaminationTypeAppService>();
builder.Services.AddScoped<IExaminationResultAppService, ExaminationResultAppService>();
builder.Services.AddScoped<IExaminationAppService, ExaminationAppService>();
builder.Services.AddScoped<ISystemSettingsAppService, SystemSettingsAppService>();
builder.Services.AddScoped<IVaccinationAppService, VaccinationAppService>();
builder.Services.AddScoped<IVaccineTypeAppService, VaccineTypeAppService>();
builder.Services.AddScoped<IDoctorPatientAppService, DoctorPatientAppService>();
builder.Services.AddScoped<IAccountIdentityService, AccountIdentityService>();
builder.Services.AddScoped<ISecurityIdentityService, SecurityIdentityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// activation of session
app.UseSession();

app.UseRouting();

app.UseAuthentication();
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

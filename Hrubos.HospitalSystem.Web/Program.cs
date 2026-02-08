using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Application.Implementation;
using Hrubos.HospitalSystem.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Serilog;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;


var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    // Naèítá statické webové prostøedky (CSS/JS/obrázky) pro produkèní prostøedí bìhem vývoje, i když není aplikace publikována.
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
}

// Nastavení Serilogu - naètení konfigurace z appsettings.json
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext());

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.43");
builder.Services.AddDbContext<HospitalSystemDbContext>(options => options.UseMySql(connectionString, serverVersion));

// Configuration for Identity
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
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;

    options.Events.OnRedirectToAccessDenied = context =>
    {
        // vytvoøení nové URI s pøidaným parametrem authorize=false
        var uriBuilder = new UriBuilder(context.RedirectUri);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
        query["authorize"] = "false";
        uriBuilder.Query = query.ToString();
        context.RedirectUri = uriBuilder.ToString();
        context.Response.Redirect(context.RedirectUri);
        return Task.CompletedTask;
    };
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
builder.Services.AddScoped<ISystemSettingAppService, SystemSettingAppService>();
builder.Services.AddScoped<IVaccinationAppService, VaccinationAppService>();
builder.Services.AddScoped<IVaccineTypeAppService, VaccineTypeAppService>();
builder.Services.AddScoped<IDoctorPatientAppService, DoctorPatientAppService>();
builder.Services.AddScoped<IAccountIdentityService, AccountIdentityService>();
builder.Services.AddScoped<ISecurityIdentityService, SecurityIdentityService>();

var app = builder.Build();


// Automatická migrace databáze pøi spuštìní aplikace
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<HospitalSystemDbContext>();
        // Pokud tabulky neexistují, vytvoøí je. Pokud existují, aplikuje zmìny.
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        // Pokud se to nepovede (napø. špatné heslo k DB), zapíše to do logu
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

app.UseHttpsRedirection();

// activation of session
app.UseSession();

app.UseRouting();

// Omezení logování pouze na chyby
app.UseSerilogRequestLogging(configure =>
{
    configure.GetLevel = (httpContext, elapsed, ex) =>
    {
        // Pokud nastala chyba (výjimka nebo kód 500+), loguji to jako ERROR
        if (ex != null || httpContext.Response.StatusCode > 499)
        {
            return Serilog.Events.LogEventLevel.Error;
        }

        // Všechno ostatní (2xx, 3xx, 4xx, obrázky) se logovat nebude
        return Serilog.Events.LogEventLevel.Verbose;
    };
});

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

// routes pro area Account stránky
app.MapAreaControllerRoute(
    name: "AccountArea",
    areaName: "Account",
    pattern: "account/{action=Index}/{id?}",
    defaults: new { controller = "Home" }
);

// routes pro ostatní area stránky
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// routes pro stránky bez area
app.MapControllerRoute(
    name: "default",
    pattern: "{action=Index}/{id?}",
    defaults: new { controller = "Home" })
    .WithStaticAssets();


app.Run();

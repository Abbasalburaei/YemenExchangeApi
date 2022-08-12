using Microsoft.EntityFrameworkCore;
using System.Globalization;
using YemenExchangeApi.Services;
using YemenExchangeApi.Utils;

const string CONNECTION_NAME = "DefaultConnection";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = int.MaxValue;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddLocalization((option) => option.ResourcesPath = "Resources");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExchangeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(CONNECTION_NAME));
});
builder.Services.AddScoped<Localizer>();
builder.Services.AddScoped<CityRepository>();
builder.Services.AddScoped<AreaRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<TransformRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization((options) =>
{
    var supportedLangs = new List<CultureInfo>()
    {
        new CultureInfo("en-US"),
        new CultureInfo("ar")
    };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ar");
    options.SupportedCultures = supportedLangs;
    options.SupportedUICultures = supportedLangs;
    options.ApplyCurrentCultureToResponseHeaders = true;
    options.FallBackToParentCultures = true;
    options.FallBackToParentUICultures = true;
});
app.UseStaticFiles();
app.UseRouting();
app.UseCors((options) =>
{
    options.WithOrigins( "http://localhost:3000" );
    options.AllowAnyHeader();
    options.AllowCredentials();
    options.AllowAnyMethod();
}).Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

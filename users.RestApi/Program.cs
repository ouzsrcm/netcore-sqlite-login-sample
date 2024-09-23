using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;
using Microsoft.OpenApi.Models;
using users.RestApi.Repositories.Customer;
using users.RestApi.Repositories.Tour;

var builder = WebApplication.CreateBuilder(args);

// Add this line to use a different port
builder.WebHost.UseUrls("http://localhost:5256");

// Add services to the container.
builder.Services.AddControllers();

// Configure SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
 
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
});


// ... diğer servisler ve middleware'ler ...
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
builder.Services.AddScoped<ISaasRepository, SaasRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Veritabanını oluştur
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // AppDbContext oluştur
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}




app.Run();

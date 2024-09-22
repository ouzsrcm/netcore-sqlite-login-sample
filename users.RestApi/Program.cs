using Microsoft.EntityFrameworkCore;
using users.DataAccess.DataContexts;
using users.DataAccess.DataStore.UnitOfWorks.Abstract;
using users.DataAccess.DataStore.UnitOfWorks.Concrete;
using users.RestApi.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add this line to use a different port
builder.WebHost.UseUrls("http://localhost:5256");

// Add services to the container.
builder.Services.AddControllers();

// Configure SQLite
builder.Services.AddDbContext<users.RestApi.Data.UserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
});

// ... diğer servisler ve middleware'ler ...

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
    var context = services.GetRequiredService<users.RestApi.Data.UserContext>();
    context.Database.EnsureCreated();
}

app.Run();

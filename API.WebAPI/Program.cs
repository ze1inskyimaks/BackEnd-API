using API.BLL;
using API.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Налаштовуємо DI (ін'єкцію залежностей)
builder.Services.AddScoped<IItemRepository, ItemRepository>(); // Заміна Singleton на Scoped

// Додаємо сервіс (Scoped)
builder.Services.AddScoped<IItemService, ItemService>();

// Отримуємо рядок підключення
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Додаємо контекст бази даних
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("API.DAL"))); // Вказуємо асемблер для міграцій


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
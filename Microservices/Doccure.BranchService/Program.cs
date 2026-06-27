using Doccure.BranchService.Settings;
using Microsoft.Extensions.Options;
using Doccure.BranchService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBranchService, BranchService>();//IBranchservice görünce branchservice'i çağıracak ve onunla çalışacak. (Dependency Injection)
builder.Services.AddAutoMapper(typeof(Program));

// Bu iki satır şunu yapar:
// 1) appsettings.json'daki "DatabaseSettings" bölümünü DatabaseSettings sınıfına bağlar
// 2) IDatabaseSettings istendiğinde DatabaseSettings'in dolu halini singleton olarak verir

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

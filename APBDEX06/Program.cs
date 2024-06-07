using APBDEX06.Context;
using APBDEX06.Repos;
using APBDEX06.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<PrescriptionService>();
builder.Services.AddScoped<PatientRepo>();
builder.Services.AddDbContext<ApbdContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=localhost:1433;Initial Catalog=apbd;User Id=sa;Password=Testowe123;Encrypt=False"));
});


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

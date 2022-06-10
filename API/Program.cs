using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var config = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
  options.UseSqlite(config ?? "");
});
builder.Services.AddCors(options =>
{
  options.AddPolicy("WebAPI", builder =>
  {
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
  });

});
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
app.UseCors("WebAPI");
app.MapControllers();
app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ApiAsistencia.Controllers;

var builder = WebApplication.CreateBuilder(args);

 builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

 builder.Services.AddControllers();

 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Asistencia", Version = "v1" });
});

var app = builder.Build();

 app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Asistencia v1");
        c.RoutePrefix = string.Empty;  
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using demo_filters;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<MySampleResultFilterAttribute>();

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add(new MySampleActionFilter("Global"));
        options.Filters.Add(new MySampleAsyncActionFilter("Global"));
        options.Filters.Add(new MySampleResourceFilterAttribute("Global"));
        options.Filters.AddService<MySampleResultFilterAttribute>();
    }
    );
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

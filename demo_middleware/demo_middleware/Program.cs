using demo_middleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("1nd middleware");
//    await next();
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("2nd middleware");
//    await next();
//});

//app.Run(async (context) =>
//{
//    Console.WriteLine("Run Middleware");
//});


//app.Use(async (context, next) =>
//{
//    console.writeline("use middleware");
//    await next();
//});

 app.UseMiddleware1();


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

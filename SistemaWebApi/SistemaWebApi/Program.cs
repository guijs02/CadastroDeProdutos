using SistemaWeb.Api.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.AddDataContext();
builder.AddServices();
builder.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
Console.WriteLine($"The connection string is: {connectionString}");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Demo.Repositories.IBookRepository, Demo.Repositories.BookRepository>();
builder.Services.AddScoped<Demo.Repositories.IAuthorRepository, Demo.Repositories.AuthorRepository>();
// configure validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();

builder.Services.Configure<ApiBehaviorOptions>(options => {
    options.InvalidModelStateResponseFactory = context => {
        var problemDetails = new ValidationProblemDetails(context.ModelState) {
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more  validation errors occurred.",
            Type = "https://tools.ietf.org/html/rfc7807#section-3.1",
            Detail = "See the 'error' property for details.",
            Instance = context.HttpContext.Request.Path
        };
        return new BadRequestObjectResult(problemDetails) {
            ContentTypes = {
                "application/problem+json",
                "application/json",
            }
        };
    };
});

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
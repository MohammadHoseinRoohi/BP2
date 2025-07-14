var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/books/list", () =>
{
    return "Book list";
});
app.MapPost("api/v1/books/creat", () =>
{
    return "Books Created!";
});
app.MapPut("api/v1/books/update", () =>
{
    return "Books Update!";
});
app.MapDelete("api/v1/books/remove", () =>
{
    return "Books Remove!";
});

app.Run();
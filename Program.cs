using Practice2.DbContextes;
using Practice2.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<LibraryDB>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/books/list", (LibraryDB db) =>
{
    return db.Books.ToList();
});
app.MapPost("api/v1/books/creat", (LibraryDB db , Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
    return "Books Created!";
});
app.MapPut("api/v1/books/update/{id}", (LibraryDB db , int id , Book book) =>
{
    var b = db.Books.Find(id);
    if (b == null)
    {
        return "Not Found!";
    }
    b.Writer = book.Writer;
    b.Translator = book.Translator;
    b.Title = book.Title;
    b.Publisher = book.Publisher;
    b.Price = book.Price;
    b.Genre = book.Genre;
    db.SaveChanges();
    return "Books Update!";
});
app.MapDelete("api/v1/books/remove/{id}", (int id , LibraryDB db) =>
{
    var book = db.Books.Find(id);
    if (book == null)
    {
        return "Not Found!";
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return "Books Remove!";
});

app.Run();
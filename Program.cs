using Microsoft.AspNetCore.Mvc;
using Practice2.DbContextes;
using Practice2.DTOs.Books;
using Practice2.DTOs.Common;
using Practice2.DTOs.Members;
using Practice2.Entities;
using Practice2.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<LibraryDB>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("api/v2/books/list", ([FromServices] LibraryDB db) =>
{
    return db.Books.Select(b => new BookListDto
    {
        Id = b.Guid,
        Writer = b.Writer,
        Title = b.Title,
        Translator = b.Translator,
        Publisher = b.Publisher,
        Genre = b.Genre,
        Price = b.Price
    }).ToList();
});
app.MapPost("api/v2/books/creat", (
    [FromServices] LibraryDB db,
    [FromBody] BookAddDto bookAddDto) =>
{
    var book = new Book
    {
        Writer =bookAddDto.Writer,
        Title = bookAddDto.Title,
        Translator = bookAddDto.Translator,
        Publisher = !string.IsNullOrEmpty(bookAddDto.Publisher)?bookAddDto.Publisher : "بی عنوان",
        Genre = bookAddDto.Genre,
        Price = bookAddDto.Price
    };
    db.Books.Add(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Book Created"
    };
});
app.MapPut("api/v2/books/update/{guid}", (
    [FromServices] LibraryDB db,
    [FromRoute] string guid,
    [FromBody] BookUpdateDto bookUpdateDto) =>
{
    var b = db.Books.FirstOrDefault(m=>m.Guid == guid);
    if (b == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!"
        };
    }
    b.Writer = !string.IsNullOrEmpty(bookUpdateDto.Writer) ? bookUpdateDto.Writer : b.Writer; //question(Line 42)**
    b.Publisher = !string.IsNullOrEmpty(bookUpdateDto.Publisher)?bookUpdateDto.Publisher : b.Publisher;  //question(Line 42)**
    b.Translator = bookUpdateDto.Translator;
    b.Title = !string.IsNullOrEmpty(bookUpdateDto.Title)?bookUpdateDto.Title : b.Title;  //question(Line 42)**
    b.Price = bookUpdateDto.Price;
    b.Genre = bookUpdateDto.Genre;
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Books Update!"
    };
});
app.MapDelete("api/v2/books/remove/{guid}", (
    [FromRoute] string guid,
    [FromServices] LibraryDB db) =>
{
    var book = db.Books.FirstOrDefault(m => m.Guid == guid);
    if (book == null)
    {
        return new CommandResultDto
        {
            Successfull = false,
            Message = "Not Found!"
        };
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successfull = true,
        Message = "Books Remove!"
    };
});
app.MapGet("api/v2/members/list", ([FromServices] LibraryDB db) =>
{
    return db.Members.Select(m => new MemberListDto
    {
        Firstname = m.Firstname,
        Lastname = m.Lastname,
        Gender = m.Gender

    }).ToList();
});
app.MapPost("api/v2/members/creat", (
    [FromServices] LibraryDB db,
    [FromBody] MemberAddDto memberAddDto) =>
{
    var member = new Member
    {
        Firstname = memberAddDto.Firstname,
        Lastname = memberAddDto.Lastname,
        Username = !string.IsNullOrEmpty(memberAddDto .Username)?memberAddDto.Username : "بی عنوان",
        // Gender = !string.IsNullOrEmpty((memberAddDto.Gender = Gender.None).ToString()) ? memberAddDto.Gender : Gender.Male
        PhoneNumber = memberAddDto.PhoneNumber,
        Password = memberAddDto.Password
    };
    db.Members.Add(member);
    db.SaveChanges();
    return "Members Created!";
});
app.MapPut("api/v2/members/update/{guid}", (
    [FromRoute] string guid,
    [FromServices] LibraryDB db,
    [FromBody] MemberUpdateDto memberUpdateDto) =>
{
    var m = db.Members.FirstOrDefault(m=>m.Guid == guid);
    if (m == null)
    {
        return "Not Found!";
    }
    m.Email = memberUpdateDto.Email;
    m.Firstname = memberUpdateDto.Firstname;
    m.Gender = memberUpdateDto.Gender;
    m.Lastname = memberUpdateDto.Lastname;
    m.Password = memberUpdateDto.Password;
    m.PhoneNumber = memberUpdateDto.PhoneNumber;
    m.Username = !string.IsNullOrEmpty(memberUpdateDto.Username)?memberUpdateDto.Username : m.Username;
    db.SaveChanges();
    return "Members Updated";
});
app.MapDelete("api/v2/members/remove/{guid}", (
    [FromRoute] string guid,
    [FromServices] LibraryDB db) =>
{
    var member = db.Members.FirstOrDefault(m=> m.Guid == guid);
    if (member == null)
    {
        return "Not Found!";
    }
    db.Members.Remove(member);
    db.SaveChanges();
    return "Member Removed!";
});

app.Run();
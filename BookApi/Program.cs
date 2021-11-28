using BookApi.Data;
using BookApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("ConnectionStrings")["BookApi_Db"].ToString();

SqlCrud sql = new SqlCrud(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!!!");

app.MapGet("/api/GetAllBooks", () => sql.GetAllBooks());

app.MapGet("/api/GetBookById/{id}", (int id) => sql.GetBookById(id));

app.MapPost("/api/InsertBook", (BookModel book) => sql.PostNewBook(book));

app.Run();

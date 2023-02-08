using ForumMinimalAPI.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<ForumContext>(
    option => option
    .UseSqlServer(builder.Configuration.GetConnectionString("ForumConnectionString"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


app.MapPost("create", async (ForumContext db) =>
{
    //var user1 = new User
    //{
    //    FirstName = "Damian",
    //    LastName = "Zachara",
    //    Address = new Address()
    //    {
    //        City = "Tarnów",
    //        Country = "Poland",
    //        Street = "Reymonta",
    //        FlatNumber = "40",
    //        ZipCode = "33-100",
    //    }
    //};

    //var user2 = new User
    //{
    //    FirstName = "Kamil",
    //    LastName = "Testowy",
    //    Address = new Address()
    //    {
    //        City = "Kraków",
    //        Country = "Poland",
    //        Street = "Wielicka",
    //        FlatNumber = "40",
    //        ZipCode = "44-144",
    //    }
    //};

    //await db.Users.AddRangeAsync(user1, user2);
    //db.SaveChanges();
    //return new { user1, user2 };

    //var tags = new List<Tag>()
    //{
    //    new Tag() { Value = "Web" },
    //    new Tag() { Value = "It" },
    //    new Tag() { Value = "Net" },
    //    new Tag() { Value = "Desktop" },
    //    new Tag() { Value = "Mobile" },
    //};
    //await db.Tags.AddRangeAsync(tags);
    //db.SaveChanges();
    //return tags;

    var question = new Question()
    {
        UserId = Guid.Parse("A59CE1D6-7894-4369-CDD6-08DB09D76215"),
        Date = DateTime.Now,
        Description = "What is going on here?",
    };
    //stworzyæ tabelê QuestionTag aby dodawaæ tagi
});
app.Run();

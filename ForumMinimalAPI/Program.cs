using ForumMinimalAPI.Entities;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
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
app.MapGet("data", async (ForumContext db) =>
{
    var question = db.Questions.Include(c => c.Comments).FirstOrDefault(q => q.Id == 1);

    var ratings = db.Ratings.Where(r => r.CommentId == question.Id).ToList();
    
    var positiveRatings = ratings.Where(pr => pr.Value == true ).Count();
    var negativeRatings = ratings.Where(nr => nr.Value == false).Count();

    var rating = positiveRatings - negativeRatings;

    return new { question, rating};

});

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

    //var user3 = new User
    //{
    //    FirstName = "Tomasz",
    //    LastName = "Kowalski",
    //    Address = new Address()
    //    {
    //        City = "Tarnów",
    //        Country = "Poland",
    //        Street = "Krakowska",
    //        FlatNumber = "35",
    //        ZipCode = "33-100",
    //    }
    //};

    //var user4 = new User
    //{
    //    FirstName = "Anna",
    //    LastName = "Tarkowska",
    //    Address = new Address()
    //    {
    //        City = "Kraków",
    //        Country = "Poland",
    //        Street = "Warszawaska",
    //        FlatNumber = "105",
    //        ZipCode = "44-144",
    //    }
    //};

    //await db.Users.AddRangeAsync(user3, user4);
    //db.SaveChanges();
    //return new { user3, user4 };

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

    //var tags = db.Tags.Where(t => t.Id == 1 && t.Id == 2 && t.Id == 3).ToList();

    //var question = new Question()
    //{
    //    UserId = Guid.Parse("A59CE1D6-7894-4369-CDD6-08DB09D76215"),
    //    Date = DateTime.Now,
    //    Description = "What is going on here?",
    //    Tags = tags,
    //};

    //var updateQuestion = db.Questions.FirstOrDefault(q => q.Id == 1);

    //updateQuestion.Tags = tags;

    //await db.Questions.AddAsync(question);
    //db.SaveChanges();

    //var comment = new Comment()
    //{
    //    UserId = Guid.Parse("71775F49-CA83-42A5-CDD7-08DB09D76215"),
    //    Date= DateTime.Now,
    //    Description = "The answer is simple...",
    //};
    //await db.Comments.AddAsync(comment);
    //await db.SaveChangesAsync();
    //return comment;
});

app.MapPost("update", async (ForumContext db) =>
{
    //var tags = db.Tags.Take(3);
    //var updateQuestion = db.Questions.FirstOrDefault(q => q.Id == 1);
    //var questionTags = new List<QuestionTag>();

    //foreach (var item in tags)
    //{
    //    var questionTag = new QuestionTag()
    //    {
    //        TagId = item.Id,
    //        QuestionId = updateQuestion.Id
    //    };
    //    questionTags.Add(questionTag);
    //}

    //db.QuestionTag.AddRange(questionTags.AsQueryable());
    //db.SaveChanges();
    //return questionTags;

    //var tags = db.Tags.Take(3).ToList();
    //var updateQuestion = db.Questions.Include(q => q.Tags).FirstOrDefault(q => q.Id == 1);
    //updateQuestion.Tags = tags;
    //db.SaveChanges();
    //return updateQuestion;

    //Rating rating1 = new Rating()
    //{
    //    UserId = Guid.Parse("A59CE1D6-7894-4369-CDD6-08DB09D76215"),
    //    CommentId = 1,
    //    Value = true
    //};

    //Rating rating2 = new Rating()
    //{
    //    UserId = Guid.Parse("D94922DC-4799-4487-AC1A-08DB0A9C1539"),
    //    CommentId = 1,
    //    Value = true
    //};

    //Rating rating3 = new Rating()
    //{
    //    UserId = Guid.Parse("0F600912-07EC-4D48-AC1B-08DB0A9C1539"),
    //    CommentId = 1,
    //    Value = false
    //};

    //await db.Ratings.AddRangeAsync(rating1, rating2, rating3);
    //await db.SaveChangesAsync();
    //return new {rating1, rating2, rating3};
});

app.Run();

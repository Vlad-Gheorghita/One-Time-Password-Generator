using Microsoft.EntityFrameworkCore;
using One_Time_Password_Generator.Data;
using One_Time_Password_Generator.Repositories;
using One_Time_Password_Generator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DataContext

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite("Data source=otp.db");
});

//Add Services
builder.Services.AddScoped<OTPService>();

//Add Repos
builder.Services.AddScoped<UserRepository>();

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

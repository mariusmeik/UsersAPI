using APICallsService;
using Core.Contracts;
using UsersAPI.MappingProfiles;
using UsersAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpClient("UsersClient", c =>
{
    c.BaseAddress = new Uri($"https://jsonplaceholder.typicode.com/users");
});

builder.Services.AddTransient<IExternalUsersClient, UsersClient>();
builder.Services.AddTransient<IUsersService, UsersService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

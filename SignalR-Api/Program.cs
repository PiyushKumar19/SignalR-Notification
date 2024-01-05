using Microsoft.AspNetCore.SignalR;
using SignalR_Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddHostedService<ServerTimeNotifier>();
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapPost("notifications/all", async (
    string content,
    IHubContext<NotificationsHub, INotificationClient> context) =>
{
    await context.Clients.All.RecievedNotification(content);
    return Results.NoContent();
});

//app.MapPost("notifications/user", async (
//    string userId,
//    string content,
//    IHubContext<NotificationsHub, INotificationsClient> context) =>
//{
//    await context.Clients.User(userId).ReceiveNotification(content);

//    return Results.NoContent();
//});

app.MapHub<NotificationsHub>("notifications");

app.Run();

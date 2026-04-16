using Hangfire;
using Hangfire.MemoryStorage;
using EmailSchedulerHangfire.Services;
using EmailSchedulerHangfire.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Hangfire setup
builder.Services.AddHangfire(config =>
    config.UseMemoryStorage());

builder.Services.AddHangfireServer();

// Register Email Service
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
// Hangfire Dashboard
app.UseHangfireDashboard("/hangfire");

app.MapControllers();

// Schedule jobs on startup
using (var scope = app.Services.CreateScope())
{
    JobScheduler.ScheduleJobs();
}

//app.Run();
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
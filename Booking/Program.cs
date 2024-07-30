using Booking.DataAccess.Models;
using Booking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BookingCodeProvider>();
builder.Services.AddScoped<ResourceProvider>();
builder.Services.AddScoped<RoomProvider>();
builder.Services.AddScoped<LocationProvider>();
builder.Services.AddScoped<UserProvider>();
builder.Services.AddScoped<RoleProvider>();
builder.Services.AddScoped<GlobalSetupProvider>();
builder.Services.AddScoped<ResourceCodeProvider>();
builder.Services.AddScoped<BookingContext>();

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

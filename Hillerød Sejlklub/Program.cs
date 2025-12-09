using Hillerød_Sejlklub.MockData;
using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository;
using Hillerød_Sejlklub.Repository.BoatFile;
using Hillerød_Sejlklub.Repository.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IRepositoryUser, MockUsers>();
builder.Services.AddSingleton<IRepositoryBoat, MockFleet>();
builder.Services.AddSingleton<IRepositoryBookings, Bookings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

User user1 = new User("John Doe", "simon@bade.dk", 26444849);
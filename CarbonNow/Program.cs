using CarbonNow.Routes;
using CarbonNow.Data;
using CarbonNow.Model;
using CarbonNow.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<CarbonNowDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Add dependencies to the app
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DAL<User>>();
builder.Services.AddScoped<DAL<Transport>>();
builder.Services.AddScoped<DAL<ElectricalItem>>();
builder.Services.AddScoped<DAL<TransportType>>();
builder.Services.AddScoped<DAL<ElectricalItemType>>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:7204") // URL do Blazor
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UserRoutes();
app.TransportRoutes();
app.TransportTypeRoutes();
app.ElectricalItemRoutes();
app.ElectricalItemTypeRoutes();
app.UseCors("AllowBlazorClient");


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

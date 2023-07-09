using EventApi.Data.Repository;
using Service.Services.Abstraction;
using Service.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IPriceBySeatService, PriceBySeatService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var context = new AppDbContext())
{
    context.Database.EnsureCreated();
}

app.Run();

using ConutBackend.Database;
using Microsoft.EntityFrameworkCore;
using ConutBackend.Migrations;
using ConutBackend.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"), opt =>
    {
        opt.MigrationsAssembly(typeof(MigrationsAssembly).Assembly.FullName);
    });
});
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblyContaining(typeof(BaseAssembly));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<DatabaseContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

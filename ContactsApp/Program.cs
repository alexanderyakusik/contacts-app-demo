using ContactsApp.DAL.Interfaces;
using ContactsApp.Domain.Services;
using ContactsApp.DAL.JSONFile;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ContactsService>();

builder.Services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("Database"));


builder.Services.AddControllers();

var app = builder.Build();


app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

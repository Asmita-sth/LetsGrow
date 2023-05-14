using Letsgrow.Data;
using Letsgrow.Data.Repository;
using Letsgrow.Data.Repository.User;
using Letsgrow.Service;
using Letsgrow.Service.Gallery;
using Letsgrow.Webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// configure DI for application services
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IGalleryService, GalleryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();

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

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
   
});


app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();

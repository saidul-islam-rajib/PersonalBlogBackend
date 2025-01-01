using Sober.Api;
using Sober.Application;
using Sober.Infrastructure;
using Sober.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);


    // Add CORS policy
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Rajib", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
    });
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Rajib");

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
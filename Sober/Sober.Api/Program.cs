using Sober.Application.Services.Implementations;
using Sober.Application.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
    builder.Services.AddControllers();
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
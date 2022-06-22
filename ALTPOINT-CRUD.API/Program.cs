using Microsoft.AspNetCore.Mvc;

using ALTPOINT_CRUD.API.Middlewares;
using ALTPOINT_CRUD.Application.Contracts;
using ALTPOINT_CRUD.Application.Dtos.Responses;
using ALTPOINT_CRUD.Application.Services;
using ALTPOINT_CRUD.Domain.Contracts;
using ALTPOINT_CRUD.Infrastructure.AutoMapper.Mappers;
using ALTPOINT_CRUD.Infrastructure.EntityFramework.Contexts;
using ALTPOINT_CRUD.Infrastructure.EntityFramework.Repositories;
using ALTPOINT_CRUD.Infrastructure.Paginator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientMapper, ClientMapper>();
builder.Services.AddScoped<IPaginationService<ClientDto>, ClientPaginationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();

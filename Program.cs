using EntityFramework.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("cnTask"));

var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TasksContext DBContext) =>{
    DBContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + DBContext.Database.IsInMemory());
});

app.Run();

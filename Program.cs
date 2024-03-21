using EntityFramework.DBContext;
using EntityFramework.Models;
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

app.MapGet("/api/task", async ([FromServices] TasksContext DBContext) =>{
    return Results.Ok(DBContext.Tasks.Include(c => c.Category));
    /*var tasks = await DBContext.Tasks.Include(p => p.Category).ToListAsync();
	return Results.Ok(tasks);*/
});

app.MapPost("/api/task", async ([FromServices] TasksContext DBContext, [FromBody] EntityFramework.Models.Task task) =>{
    
    task.TaskId = Guid.NewGuid();
    task.DateCreation = DateTime.Now;
    await DBContext.AddAsync(task);

    return Results.Ok();
});

app.MapPut("/api/task/{id}", async ([FromServices] TasksContext DBContext, [FromBody] EntityFramework.Models.Task task, [FromRoute] Guid id) =>{
    
    var CurrentTask = DBContext.Tasks.Find(id);

    if(CurrentTask != null){
        CurrentTask.CategoryId = task.CategoryId;
        CurrentTask.Title = task.Title;
        CurrentTask.TaskPriority = task.TaskPriority;
        CurrentTask.Descripcion = task.Descripcion;

        await DBContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();

    
});

app.MapDelete("/api/task/{id}", async ([FromServices] TasksContext DBContext, [FromBody] EntityFramework.Models.Task task, [FromRoute] Guid id) =>{
    
    var CurrentTask = DBContext.Tasks.Find(id);

    if(CurrentTask != null){

        DBContext.Remove(CurrentTask);
        await DBContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});


app.Run();

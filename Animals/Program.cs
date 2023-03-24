using Animals.Model;
using Animals.Model.Entity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    var responceData = new {Time = DateTime.Now, Message = "Server is running.... Hello!"};
    await context.Response.WriteAsJsonAsync(responceData);
});
app.MapGet("/ping", async (context) =>
{
    await context.Response.WriteAsync(DateTime.Now + " pong");
});

app.MapGet("/info", async (context) =>
{
    var environmentData = new { Username = Environment.UserName, Machine = Environment.MachineName, ProccesorCount = Environment.ProcessorCount };
    await context.Response.WriteAsJsonAsync(environmentData);
});
app.MapGet("/animal/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.AnimalsExamples.ToListAsync();
});

app.MapPost("/animal/add", async (HttpContext context, ApplicationDbContext db) =>
{
    AnimalsTable? animalsTable = await context.Request.ReadFromJsonAsync<AnimalsTable>();
    if(animalsTable != null)
    {
        db.AnimalsExamples.Add(animalsTable);
        db.SaveChanges();
    }
    return animalsTable;
});

app.MapPost("/animal/delete/{id}", async ( int id, HttpContext context, ApplicationDbContext db) =>
{
    var animal = await db.AnimalsExamples.FindAsync(id);

    if (animal == null)
    {
        context.Response.StatusCode = 404;
        return;
    }
    db.AnimalsExamples.Remove(animal);
    await db.SaveChangesAsync();
    context.Response.StatusCode = 200;
});

app.MapGet("/animal/get", async (HttpContext context, ApplicationDbContext db, int id) =>
{
    return await db.AnimalsExamples.FirstOrDefaultAsync(entity => entity.Id == id);
});

app.MapPost("/animal/update", async ( HttpContext context, ApplicationDbContext db) =>
{
    //AnimalsExamples                                                 //AnimalsExample
    AnimalsTable? animalsExamples = await context.Request.ReadFromJsonAsync<AnimalsTable>();
    if (animalsExamples != null) 
    {
        db.AnimalsExamples.Update(animalsExamples);
        db.SaveChanges();
    }
    //return animalsTable;
});




app.MapGet("/feeding/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Feedings.ToListAsync();
});

app.MapPost("/feeding/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Feeding? feeding = await context.Request.ReadFromJsonAsync<Feeding>();
    if (feeding != null)
    {
        db.Feedings.Add(feeding);
        db.SaveChanges();
    }
    return feeding;
});

app.MapPost("/feeding/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var feeding = await db.Feedings.FindAsync(id);

    if (feeding == null)
    {
        context.Response.StatusCode = 404;
        return;
    }
    db.Feedings.Remove(feeding);
    await db.SaveChangesAsync();
    context.Response.StatusCode = 200;
});

app.MapGet("/feeding/get", async (HttpContext context, ApplicationDbContext db, int id) =>
{
    return await db.Feedings.FirstOrDefaultAsync(entity => entity.Id == id);
});

app.MapPost("/feeding/update/{id}", async (int id, Feeding update, HttpContext context, ApplicationDbContext db) =>
{
    var feeding = await db.Feedings.FindAsync(id);
    if (feeding == null)
    {
        context.Response.StatusCode = 404;
        return;
    }
    feeding.Time = update.Time;
    feeding.Quantity = update.Quantity;
    feeding.Type = update.Type;

    await db.SaveChangesAsync();
    context.Response.StatusCode = 200;
});



app.MapGet("/cell/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Cells.ToListAsync();
});

app.MapPost("/cell/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Cell? cell = await context.Request.ReadFromJsonAsync<Cell>();
    if (cell != null)
    {
        db.Cells.Add(cell);
        db.SaveChanges();
    }
    return cell;
});

app.MapPost("/cell/delete/{id}", async (int id, HttpContext context, ApplicationDbContext db) =>
{
    var cell = await db.Cells.FindAsync(id);

    if (cell == null)
    {
        context.Response.StatusCode = 404;
        return;
    }
    db.Cells.Remove(cell);
    await db.SaveChangesAsync();
    context.Response.StatusCode = 200;
});

app.MapGet("/cell/get", async (HttpContext context, ApplicationDbContext db, int id) =>
{
    return await db.AnimalsExamples.FirstOrDefaultAsync(entity => entity.Id == id);
});

app.MapPost("/cell/update/{id}", async (int id, Cell update, HttpContext context, ApplicationDbContext db) =>
{
    var cell = await db.Cells.FindAsync(id);
    if (cell == null)
    {
        context.Response.StatusCode = 404;
        return;
    }
    cell.Type = update.Type;
    cell.Place = update.Place;

    await db.SaveChangesAsync();
    context.Response.StatusCode = 200;
});

app.Run();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();


app.MapGet("/health", async context =>
{
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync("{\"status\":\"healthy\"}");
});

app.Run();

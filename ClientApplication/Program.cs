var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("FastFoodAPI", client =>
{
    client.BaseAddress = new Uri("http://fastfoodapi:8000/api/");
});


var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();


// Serve index.html for SPA routes
async static Task ServeIndexHtml(HttpContext context)
{
    var filePath = Path.Combine("wwwroot", "index.html");
    if (File.Exists(filePath))
    {
        context.Response.ContentType = "text/html";
        //context.Response.Headers.ContentSecurityPolicy = "default-src 'none'; script-src-elem 'self'; style-src-elem 'self'; img-src 'self'; connect-src *;";
        context.Response.Headers.ContentLanguage = "en-US";
        context.Response.Headers.Append("Permissions-Policy", "camera=(), microphone=(), geolocation=(), bluetooth=(), payment=(), idle-detection=(), accelerometer=(),");
        await context.Response.SendFileAsync(filePath);
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("File not found");
    }
}


app.MapGet("/health", async context =>
{
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync("{\"status\":\"healthy\"}");
});


// Map SPA routes to index.html
app.MapGet("/", async context => await ServeIndexHtml(context));
app.MapGet("/login", async context => await ServeIndexHtml(context));
app.MapGet("/logout", async context => await ServeIndexHtml(context));
app.MapGet("/employees", async context => await ServeIndexHtml(context));
app.MapGet("/employees/details", async context => await ServeIndexHtml(context));
app.MapGet("/employees/list", async context => await ServeIndexHtml(context));
app.MapGet("/employees/manage", async context => await ServeIndexHtml(context));
app.MapGet("/employees/hire", async context => await ServeIndexHtml(context));
app.MapGet("/manage", async context => await ServeIndexHtml(context));
app.MapGet("/hire", async context => await ServeIndexHtml(context));


// Map controller routes
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
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


app.MapGet("/health", async context =>
{
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync("{\"status\":\"healthy\"}");
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
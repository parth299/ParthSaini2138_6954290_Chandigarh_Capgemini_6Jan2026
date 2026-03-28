var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("ProductApi", client =>
{
   client.BaseAddress = new Uri("http://localhost:5298/api/");
});
 
var app = builder.Build();
 
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();
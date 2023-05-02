using Barberries.Database;
using Barberries.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddTransient<ICreateProductService, CreateProductService>();

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

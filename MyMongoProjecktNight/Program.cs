using Microsoft.Extensions.Options;
using MyMongoProjecktNight.Services;
using MyMongoProjecktNight.Services.DepartmentServices;
using MyMongoProjecktNight.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ICustomerService arayüzünü implement eden CustomerService sýnýfýný scoped olarak kaydeder.
builder.Services.AddScoped<ICustomerService, CustomerService>();
// IDepartmentService arayüzünü implement eden DepartmentService sýnýfýný scoped olarak kaydeder.
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
// AutoMapper'ý uygulamaya ekler ve otomatik çalýþmasýný saðlar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// DatabaseSettings ayarlarýný "DatabaseSettingsKey" baþlýðý altýndaki yapýlandýrmalardan çeker.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
// IDatabaseSettings için baðýmlýlýk enjeksiyonu saðlar.
// IOptions<DatabaseSettings> kullanýlarak yapýlandýrmadan çekilen ayarlarýn bir örneði alýnýr.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    // IOptions<DatabaseSettings>'den ayarlarý alýp IDatabaseSettings olarak döner.
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;

});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

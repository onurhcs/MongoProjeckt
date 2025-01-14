using Microsoft.Extensions.Options;
using MyMongoProjecktNight.Services;
using MyMongoProjecktNight.Services.DepartmentServices;
using MyMongoProjecktNight.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ICustomerService aray�z�n� implement eden CustomerService s�n�f�n� scoped olarak kaydeder.
builder.Services.AddScoped<ICustomerService, CustomerService>();
// IDepartmentService aray�z�n� implement eden DepartmentService s�n�f�n� scoped olarak kaydeder.
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
// AutoMapper'� uygulamaya ekler ve otomatik �al��mas�n� sa�lar.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// DatabaseSettings ayarlar�n� "DatabaseSettingsKey" ba�l��� alt�ndaki yap�land�rmalardan �eker.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
// IDatabaseSettings i�in ba��ml�l�k enjeksiyonu sa�lar.
// IOptions<DatabaseSettings> kullan�larak yap�land�rmadan �ekilen ayarlar�n bir �rne�i al�n�r.
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    // IOptions<DatabaseSettings>'den ayarlar� al�p IDatabaseSettings olarak d�ner.
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

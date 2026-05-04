using Microsoft.EntityFrameworkCore;
using OkulSistemi;

// 1. builder nesnesini oluştur
var builder = WebApplication.CreateBuilder(args);

// 2. Veritabanı Servisini ve "Yeniden Deneme" (Retry) Ayarını Ekle
builder.Services.AddDbContext<OkulContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("OkulBaglantisi"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Somee bağlantısı koparsa hemen pes etme, 5 kez daha dene
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        }));

// Diğer servisleri ekle
builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP istek boru hattını yapılandır
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
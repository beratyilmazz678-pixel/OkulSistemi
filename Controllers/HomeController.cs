using Microsoft.AspNetCore.Mvc;
using OkulSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace OkulSistemi.Controllers;

public class HomeController : Controller
{
    private readonly OkulContext _db;

    public HomeController(OkulContext db)
    {
        _db = db;
    }

    // 1. ANA SAYFA (localhost:5002 yazınca açılacak yer)
    public IActionResult Index()
    {
        return View();
    }

    // 2. KAYIT OLMA SAYFASI (Giriş Formu)
    public IActionResult Kayit()
    {
        return View();
    }

    // 3. KAYIT OLMA İŞLEMİ (POST)
    [HttpPost]
    public IActionResult Kayit(Kullanici yeniKullanici)
    {
        if (ModelState.IsValid)
        {
            try 
            {
                _db.Kullanicilar.Add(yeniKullanici);
                _db.SaveChanges();
                return RedirectToAction("Basarili");
            }
            catch (Exception ex)
            {
                // Veritabanı hatası alırsan ne olduğunu ekranda görmek için:
                return Content("Hata oluştu: " + ex.Message);
            }
        }
        return View(yeniKullanici);
    }

    public IActionResult Basarili() => Content("Kayıt başarıyla tamamlandı!");

    // 4. YÖNETİCİ PANELİ (Öğrenci Görevleri 3 & 4 burada çalışıyor)
    public IActionResult YoneticiPaneli()
    {
        var liste = _db.Kullanicilar.ToList();
        return View(liste);
    }
}
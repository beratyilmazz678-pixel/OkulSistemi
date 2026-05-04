using System.ComponentModel.DataAnnotations;

namespace OkulSistemi.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string AdSoyad { get; set; } = "";

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter olmalıdır.")] // GÖREV 2
        [DataType(DataType.Password)]
        public string Sifre { get; set; } = "";

        [Required(ErrorMessage = "Lütfen bir rol seçiniz.")]
        public string Rol { get; set; } = ""; 
    }
}
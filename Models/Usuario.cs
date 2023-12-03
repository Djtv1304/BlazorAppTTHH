using System.ComponentModel.DataAnnotations;

namespace BlazorAppPrub.Models
{
    public class Usuario
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El usuario es requerido!")]
        public string _username { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "La contraseña es requerida!")]
        public string _password { get; set; }

        public bool isAuthenticated { get; set; }

    }
}

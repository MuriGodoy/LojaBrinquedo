using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

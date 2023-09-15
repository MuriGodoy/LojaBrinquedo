using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(250)]
    public string Nome { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$")]
    [Required]
    public string Email { get; set; }
    [Required]
    public string CPF { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string PasswordConfirmation { get; set; }
    public string CEP { get; set; }
    public int Numero { get; set; }
    public string Complemento { get; set; }
    public string? UF { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Localidade { get; set; }
}

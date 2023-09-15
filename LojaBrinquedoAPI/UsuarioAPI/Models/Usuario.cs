using Microsoft.AspNetCore.Identity;

namespace UsuarioAPI.Models;

public class Usuario : IdentityUser
{

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
    public string CEP { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public int Numero { get; set; }
    public string Complemento { get; set; }
    public string UF { get; set; }
    public bool Status { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    public Usuario() : base() { }
}

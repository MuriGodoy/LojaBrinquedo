using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LojaBrinquedoAPI.Models;

public class Produto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome do produto é obrigatório!")]
    [StringLength(128, ErrorMessage = "O tamanho do nome excede 128 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9'-'' '\s]{1,40}$", ErrorMessage = "Caracteres especiais não são permitidos no nome.")]
    public string? Nome { get; set; }
    public bool? Status { get; set; } = true;
    public string? Descricao { get; set; }
    public double? Peso { get; set; }
    public double? Altura { get; set; }
    public double? Largura { get; set; }
    public double? Comprimento { get; set; }
    public double? Valor { get; set; }
    public int? Estoque { get; set; }
    public DateTime? HoraDeCriacao { get; set; } = DateTime.Now;
    public DateTime? HoraDeModificacao { get; set; }
    public int? CarrinhoId { get; set; }
}

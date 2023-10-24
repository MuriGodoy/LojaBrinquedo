using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UsuarioAPI.Data;
using UsuarioAPI.Data.Dtos;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services;

public class UsuarioService
{
    private readonly IMapper _mapper;
    private readonly UserManager<Usuario> _userManager;
    private readonly SignInManager<Usuario> _signInManager;
    private readonly TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService, UsuarioDbContext context)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Cadastra(CreateUsuarioDto usuarioDto)
    {
        var endereco = await BuscarEnderecoPorCep(usuarioDto.CEP);
        usuarioDto.Logradouro = endereco.Logradouro;
        usuarioDto.Bairro = endereco.Bairro;
        usuarioDto.Localidade = endereco.Localidade;
        usuarioDto.UF = endereco.UF;

        bool cpfValido = VerificaCPF(usuarioDto.CPF);
        bool dataNascimentoValida = DataDeNascimentoValida(usuarioDto.DataNascimento);

        if (dataNascimentoValida != true)
        {
            throw new ApplicationException("Data de nascimento inválida, tente novamente!");
        }
        if(cpfValido != true)
        {
            throw new ApplicationException("CPF inválido, tente novamente!");
        }

        Usuario usuario = _mapper.Map<Usuario>(usuarioDto);

        IdentityResult resultado = await _userManager.CreateAsync(usuario, usuarioDto.Password);
        var role = await _userManager.AddToRoleAsync(usuario, "Cliente");
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário");
        }
    }

    public async Task<string> Login(LoginUsuarioDto usuarioDto)
    {
        var username = _userManager.FindByEmailAsync(usuarioDto.Email);
        var resultado = await _signInManager.PasswordSignInAsync(username.Result.UserName, usuarioDto.Password, false, false);

        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado!");
        }

        var usuario = _signInManager.UserManager
            .Users.FirstOrDefault(user => user.NormalizedUserName == username.Result.UserName.ToUpper());
        var token = _tokenService.GenerateToken
            (usuario, _signInManager.UserManager.GetRolesAsync(usuario)
            .Result.ToList());
        return token;
    }

    public async Task<CreateUsuarioDto> BuscarEnderecoPorCep(string cep)
    {
        HttpClient client = new HttpClient();

        var resultado = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        var informacoes = await resultado.Content.ReadAsStringAsync();

        var endereco = JsonConvert.DeserializeObject<CreateUsuarioDto>(informacoes);

        return endereco;
    }

    public bool DataDeNascimentoValida(DateTime dataNascimento)
    {
        if (dataNascimento < DateTime.Today)
        {
            return true;
        }
        return false;
    }

    public static bool VerificaCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }
}

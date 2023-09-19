using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario, List<string> roles)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim("username", usuario.UserName),
            new Claim("id", usuario.Id),
            new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString()),
            new Claim("loginTimeStamp", DateTime.UtcNow.ToString())
        };
        foreach(var role in roles)
        {
            claims.Add(new Claim("role", role.ToString()));
        }

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DSAOUGDAS08DAS921B124512ASDVBASkgjsdlfa"));

        var signinCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signinCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
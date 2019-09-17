using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginRepository loginRepository = new LoginRepository();

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario loginBuscado = loginRepository.BuscarPorEmailESenha(login);
                if (loginBuscado == null)
                    return NotFound(new { mensagem = "Email ou Senha Inválidos." });
                // informacoes referentes ao usuario
                var claims = new[]
               {
                    // chave customizada
                    new Claim("adffff", "0123456789"),
                    new Claim("dhgdfcnhjfcg", "AgoraFoi"),
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, loginBuscado.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, loginBuscado.Idusuario.ToString()),
                    // permissao
                    new Claim(ClaimTypes.Role, loginBuscado.IdperfilNavigation.Perfil1),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufos-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLock.WebApi",
                    audience: "InLock.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = "bah" + ex.Message });
            }
        }
    }
}
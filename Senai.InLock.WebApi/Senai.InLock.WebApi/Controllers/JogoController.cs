using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    public class JogoController : ControllerBase
    {
        JogoRepository JogoRepository = new JogoRepository();
        [Authorize]
        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(JogoRepository.Listar());
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public IActionResult Cadastrar(Jogo jogo)
        {
            try
            {
                JogoRepository.Cadastrar(jogo);
                return Ok();

            }

            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Mohhh!!!" + ex.Message });

            }
        }
        [Authorize(Roles = "ADMIN")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Jogo jogo = JogoRepository.BuscarPorId(id);
            if (jogo == null)
                return NotFound();
            return Ok(jogo);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            JogoRepository.Deletar(id);
            return Ok();
        }
        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        public IActionResult Atualizar(Jogo jogo)
        {
            try
            {
                Jogo jogoBuscado = JogoRepository.BuscarPorId(jogo.Idjogo);
                if (jogoBuscado == null)
                    return NotFound();

                JogoRepository.Atualizar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "bbbeeehh" });
            }
        }
    }

}

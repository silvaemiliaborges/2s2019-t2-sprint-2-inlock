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
    public class EstudioController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();

        [HttpGet]
        // IEnumerable<Categorias>
        public IActionResult Listar()
        {
            return Ok(estudioRepository.Listar());
        }


        [HttpPost]
        public IActionResult Cadastrar(Estudio estudio)
        {
            try
            {
                estudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "mo??? " + ex.Message });
            }
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estudio estudio = estudioRepository.BuscarPorId(id);
            if (estudio == null)
                return NotFound();
            return Ok(estudio);
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estudioRepository.Deletar(id);
            return Ok();
        }


        [HttpPut]
        public IActionResult Atualizar(Estudio estudio)
        {
            try
            {
                // pesquisar uma categoria
                Estudio EstudioBuscado = estudioRepository.BuscarPorId(estudio.Idestudio);
                // caso nao encontre, not found
                if (EstudioBuscado == null)
                    return NotFound();
                // caso contrario, se ela for encontrada, eu atualizo pq quero
                estudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "meeeeeeh" });
            }
        }

    }
}

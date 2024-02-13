using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Santi.Models;
using Santi.Services;

namespace Santi.Controllers
{
    [Route("[controller]")]
    public class VisitanteContext : Controller
    {
        private readonly VisitantesServices _services;

        public VisitanteContext(VisitantesServices services)
        {
            _services = services;
        }

        [HttpGet("Visitantes")]
        public async Task<ActionResult<List<Visitante>>> TdosVisitante()
        {
            try
            {
                var todosVisitantes = await _services.TdosVisitante();
                return Ok(todosVisitantes);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao buscar {ex.Message}");
            }
        }

        [HttpGet("VisitantePorCPF")]
        public async Task<IActionResult> BuscaPorCPF(string cpf)
        {
            try
            {
                var visitante = await _services.BuscarPorCpf(cpf);
                if (visitante == null)
                {
                    return NotFound("Visitante não encontrado");
                }
                return Ok(visitante);
            }

            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar {ex.Message}");
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<IActionResult> NovoVisitante([FromBody] Visitante visitante)
        {
            try
            {
                await _services.NovoVisitante(visitante);
                return Ok("Visitante cadastrado");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar {ex.Message}");
            }
        }

        [HttpPut("{cpf}")]
        public async Task<IActionResult> AtualizarVisitante(string cpf, [FromBody] Visitante visitante)
        {
            try
            {
                await _services.AtualizarVisitante(cpf, visitante);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cpf}")]
        public async Task<IActionResult> RemoverVisitante(string cpf)
        {
            try
            {
                await _services.RemoverVisitante(cpf);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
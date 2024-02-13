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

                return BadRequest(ex.Message);
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioSoftPlan.Api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSoftPlan.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JurosController : ControllerBase
    {
        public IJurosService _service { get; set; }

        public JurosController(IJurosService service)
        {
            _service = service;
        }

        [HttpGet("calculajuros")]
        public IActionResult CalculaJuros(decimal valorInicial, int meses)
        {
            try
            {
                var result = _service.CalcularJurosComposto(valorInicial, meses);
                return Ok(new
                {
                    resultado = result
                });
            }
            catch (Exception e)
            {
                return BadRequest(new { CalculoErro = e.Message });
            }
        }
    }
}
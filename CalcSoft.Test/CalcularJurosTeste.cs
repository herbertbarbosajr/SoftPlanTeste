using CalcSoft.Api.Interfaces;
using CalcSoft.Api.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalcSoft.Test
{
    public class CalcularJurosTeste
    {
        public IJurosService _service { get; set; }

        public CalcularJurosTeste()
        {
            _service = new JurosService();
        }

        [Fact(DisplayName = "Juros Composto Verdadeiro")]
        public void CalcularJuros_TesteVerdadeiro()
        {
            var resultado = _service.CalcularJurosComposto(100m, 5);
            Assert.Equal(105.1m , resultado);
        }

        [Fact(DisplayName = "Juros Composto Falso")]
        public void CalcularJuros_TesteFalso()
        {
            var resultado = _service.CalcularJurosComposto(100m, 5);
            Assert.NotEqual(105.0m, resultado);
        }
    }
}

using DesafioSoftPlan.Api.Helpers;
using DesafioSoftPlan.Api.Interfaces;
using System;

namespace DesafioSoftPlan.Api.Services
{
    public class JurosService : IJurosService
    {
        public decimal CalcularJurosComposto(decimal valorInicial, int meses)
        {
            var juros = 0.01m;

            var calculo = (decimal) Math.Pow((double)(1 + juros), meses);
            calculo = valorInicial * calculo;
           
            return calculo.TruncatePlaces(2);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioSoftPlan.Api.Helpers
{
    public static class DecimalExtension
    {
        /// <summary>
        /// Trunca o valor decimal na quantidade de casas informada
        /// </summary>
        /// <param name="val">Valor</param>
        /// <param name="places">Casas</param>
        /// <returns></returns>
        public static decimal TruncatePlaces(this decimal val, int places)
        {
            decimal step = (decimal)Math.Pow(10, places);
            decimal tmp = Math.Truncate(step * val);
            return tmp / step;
        }
    }
}

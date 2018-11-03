
namespace CalcSoft.Api.Interfaces
{
    public interface IJurosService
    {
        decimal CalcularJurosComposto(
            decimal valorInicial, int meses);
    }
}

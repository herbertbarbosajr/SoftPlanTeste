
namespace DesafioSoftPlan.Api.Interfaces
{
    public interface IJurosService
    {
        decimal CalcularJurosComposto(
            decimal valorInicial, int meses);
    }
}

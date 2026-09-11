// H3 · CON ADAPTER.
// Traduce el contrato interno (IProcesadorPagos) a la API del sistema legado, que no
// podemos tocar. El resto del sistema de Créditos sigue hablando en sus propios términos
// (Credito, Cuota); solo el Adaptador conoce que por detrás hay un sistema externo.

namespace Creditos.ConAdapter;

public class AdaptadorPagosLegado : IProcesadorPagos
{
    private readonly SistemaPagosLegado _sistemaLegado;

    public AdaptadorPagosLegado(SistemaPagosLegado sistemaLegado)
    {
        _sistemaLegado = sistemaLegado;
    }

    public bool ProcesarPago(Credito credito, int numeroCuota)
    {
        var cuota = credito.Cuotas.FirstOrDefault(c => c.Numero == numeroCuota);
        if (cuota is null) return false;

        var resultado = _sistemaLegado.ProcesarTransaccion(
            clienteId: credito.Cliente.CI,
            referenciaCuota: $"CRED-{credito.Id}-CUOTA-{cuota.Numero}",
            monto: (double)cuota.Monto);

        if (resultado == "OK")
        {
            cuota.MarcarComoPagada();
            return true;
        }
        return false;
    }
}

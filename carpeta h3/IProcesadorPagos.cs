// H3 · CON ADAPTER.
// Este es el contrato que el resto del sistema de Créditos espera para procesar un pago.

namespace Creditos.ConAdapter;

public interface IProcesadorPagos
{
    bool ProcesarPago(Credito credito, int numeroCuota);
}

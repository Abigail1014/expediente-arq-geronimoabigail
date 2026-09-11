// H3 · CON ADAPTER.
// Simula un sistema de pagos EXTERNO ya existente (de un banco o pasarela). No lo podemos
// modificar: tiene su propia forma de trabajar, distinta a la de nuestro dominio de Créditos
// (trabaja con strings y double, no con nuestras clases Credito/Cuota).

namespace Creditos.ConAdapter;

public class SistemaPagosLegado
{
    public string ProcesarTransaccion(string clienteId, string referenciaCuota, double monto)
    {
        Console.WriteLine($"[SISTEMA LEGADO] Transacción por {monto:0.00} de cliente {clienteId}, ref {referenciaCuota}");
        return "OK";
    }
}

// H3 · BASE — sin patrones. Servicio simple que registra el pago de una cuota.

namespace Creditos.Base;

public static class Pago
{
    public static void RegistrarPago(Credito credito, int numeroCuota)
    {
        var cuota = credito.Cuotas.FirstOrDefault(c => c.Numero == numeroCuota);
        if (cuota is null)
        {
            Console.WriteLine($"No existe la cuota #{numeroCuota} en el crédito #{credito.Id}");
            return;
        }

        cuota.MarcarComoPagada();
        Console.WriteLine($"[PAGO] Crédito #{credito.Id} — Cuota #{cuota.Numero} de {credito.Cliente.Nombre}: pagada ({cuota.Monto:0.00} Bs)");
    }
}

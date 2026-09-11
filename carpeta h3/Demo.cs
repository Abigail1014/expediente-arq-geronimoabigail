// H3 · BASE — sin patrones. Punto de partida: el crédito se arma "a mano" con new + asignaciones.

namespace Creditos.Base;

public static class Demo
{
    public static void Correr()
    {
        var cliente = new Cliente(1, "Rosa Mamani", "5678901", "70011223");

        // Todo el armado del crédito queda expuesto aquí: tasa, plazo, cuotas... nada está encapsulado.
        var credito = new Credito(id: 101, cliente: cliente, montoTotal: 3000, tasaInteres: 0.15m, plazoMeses: 6);

        Console.WriteLine($"-- Crédito #{credito.Id} de {credito.Cliente} --");
        foreach (var cuota in credito.Cuotas)
        {
            Console.WriteLine($"Cuota #{cuota.Numero}: {cuota.Monto:0.00} Bs — vence {cuota.FechaVencimiento:d}");
        }

        Pago.RegistrarPago(credito, 1);
    }
}

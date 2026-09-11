// H3 · CON BUILDER.

namespace Creditos.ConBuilder;

public static class Demo
{
    public static void Correr()
    {
        var cliente = new Cliente(1, "Rosa Mamani", "5678901", "70011223");

        // Crédito simple: solo lo esencial.
        var creditoSimple = new CreditoBuilder()
            .ConId(101)
            .ParaCliente(cliente)
            .ConMonto(3000)
            .ConTasa(0.15m)
            .ConPlazoMeses(6)
            .Construir();

        // Crédito con seguro y período de gracia: mismo Builder, distinta configuración,
        // sin un segundo constructor ni parámetros opcionales sueltos.
        var creditoConGracia = new CreditoBuilder()
            .ConId(102)
            .ParaCliente(cliente)
            .ConMonto(10000)
            .ConTasa(0.12m)
            .ConPlazoMeses(12)
            .ConSeguroDesgravamen()
            .ConPeriodoGracia(2)
            .Construir();

        Console.WriteLine($"-- Crédito #{creditoSimple.Id}: primera cuota {creditoSimple.Cuotas[0].Monto:0.00} Bs --");
        Console.WriteLine($"-- Crédito #{creditoConGracia.Id}: primera cuota {creditoConGracia.Cuotas[0].Monto:0.00} Bs, vence {creditoConGracia.Cuotas[0].FechaVencimiento:d} (con gracia y seguro) --");

        Pago.RegistrarPago(creditoSimple, 1);
    }
}

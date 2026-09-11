// H3 · CON FACTORY METHOD.

namespace Creditos.ConFactory;

public static class Demo
{
    public static void Correr()
    {
        var cliente = new Cliente(1, "Rosa Mamani", "5678901", "70011223");

        // El cliente pide un TIPO, no una clase concreta. La fábrica decide qué instanciar.
        var creditoConsumo = CreditoFactory.CrearCredito(TipoCredito.Consumo, 101, cliente, 3000, 6);
        var creditoHipotecario = CreditoFactory.CrearCredito(TipoCredito.Hipotecario, 102, cliente, 50000, 24);

        foreach (var credito in new[] { creditoConsumo, creditoHipotecario })
        {
            Console.WriteLine($"-- Crédito #{credito.Id} ({credito.GetType().Name}) de {credito.Cliente} --");
            Console.WriteLine($"Primera cuota: {credito.Cuotas[0].Monto:0.00} Bs");
        }

        Pago.RegistrarPago(creditoConsumo, 1);
    }
}

// H3 · CON ADAPTER.

namespace Creditos.ConAdapter;

public static class Demo
{
    public static void Correr()
    {
        var cliente = new Cliente(1, "Rosa Mamani", "5678901", "70011223");
        var credito = new Credito(101, cliente, 3000, 0.15m, 6);

        // El código de Créditos programa contra IProcesadorPagos, no contra SistemaPagosLegado.
        // Podríamos cambiar de pasarela mañana sin tocar esta línea, solo el Adaptador.
        IProcesadorPagos procesador = new AdaptadorPagosLegado(new SistemaPagosLegado());

        Console.WriteLine($"-- Crédito #{credito.Id} de {credito.Cliente} --");
        var exito = procesador.ProcesarPago(credito, 1);
        Console.WriteLine(exito
            ? $"Cuota #1 pagada a través del sistema legado."
            : "No se pudo procesar el pago.");
    }
}

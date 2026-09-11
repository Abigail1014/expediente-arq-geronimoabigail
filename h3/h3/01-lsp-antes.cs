// CLASE 5 · LSP, Liskov Substitution (el hijo cumple el contrato del padre) — EL ANTES
// Adaptado al diagrama de Créditos: la Cuota que PROMETE (hereda el contrato) y NO CUMPLE.

namespace Lsp.Antes;

public abstract class Cuota
{
    public int Numero { get; }
    public decimal Monto { get; }
    public DateTime FechaVencimiento { get; }

    protected Cuota(int numero, decimal monto, DateTime fechaVencimiento)
    {
        Numero = numero;
        Monto = monto;
        FechaVencimiento = fechaVencimiento;
    }

    public abstract decimal CalcularMora();   // ← la promesa: TODA cuota sabe calcular su mora
}

public class CuotaNormal : Cuota
{
    public CuotaNormal(int numero, decimal monto, DateTime fechaVencimiento)
        : base(numero, monto, fechaVencimiento) { }

    public override decimal CalcularMora()
    {
        var diasVencida = (DateTime.Today - FechaVencimiento).Days;
        return diasVencida > 0 ? Monto * 0.02m * diasVencida : 0m;
    }
}

public class CuotaCondonada : Cuota
{
    public CuotaCondonada(int numero, decimal monto, DateTime fechaVencimiento)
        : base(numero, monto, fechaVencimiento) { }

    // Esta cuota fue perdonada por el banco: NO debería generar mora.
    // El hijo hereda la promesa del padre... y la rompe.
    public override decimal CalcularMora()
        => throw new NotSupportedException("Una cuota condonada no calcula mora.");
}

public static class Demo
{
    public static void Correr()
    {
        // Este código genérico confía en el contrato del PADRE. Y funciona... hasta que llega la condonada.
        var cuotas = new List<Cuota>
        {
            new CuotaNormal(1, 500, DateTime.Today.AddDays(-10)),
            new CuotaNormal(2, 500, DateTime.Today.AddDays(-5)),
            new CuotaCondonada(3, 500, DateTime.Today.AddDays(-20)),
        };

        Console.WriteLine("-- fin de mes: se calcula la mora de TODAS las cuotas vencidas --");
        foreach (var cuota in cuotas)
        {
            try
            {
                var mora = cuota.CalcularMora();
                Console.WriteLine($"Cuota #{cuota.Numero}: mora = {mora:0.00} Bs");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine($"💥 EXPLOTÓ en cuota #{cuota.Numero}: {ex.Message}");
            }
        }
        Console.WriteLine("El tipo dijo 'soy una Cuota' pero no se comporta como tal: LSP roto.");
    }
}

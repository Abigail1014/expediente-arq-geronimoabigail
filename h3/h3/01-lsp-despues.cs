// CLASE 5 · LSP, Liskov Substitution (el hijo cumple el contrato del padre) — EL DESPUÉS
// Contrato honesto: el padre solo promete lo que TODAS las cuotas pueden cumplir.
// Lo extra (calcular mora) vive en un contrato aparte, solo para quienes SÍ pueden generar mora.

namespace Lsp.Despues;

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

    public bool EstaVencida() => DateTime.Today > FechaVencimiento;   // ← lo ÚNICO que todas cumplen
}

public interface IConMora
{
    decimal CalcularMora();          // ← contrato aparte, solo para cuotas que generan mora
}

public class CuotaNormal : Cuota, IConMora
{
    public CuotaNormal(int numero, decimal monto, DateTime fechaVencimiento)
        : base(numero, monto, fechaVencimiento) { }

    public decimal CalcularMora()
    {
        if (!EstaVencida()) return 0m;
        var diasVencida = (DateTime.Today - FechaVencimiento).Days;
        return Monto * 0.02m * diasVencida;
    }
}

public class CuotaCondonada : Cuota
{
    public CuotaCondonada(int numero, decimal monto, DateTime fechaVencimiento)
        : base(numero, monto, fechaVencimiento) { }
    // No firma IConMora: no promete lo que no puede cumplir. Honestidad de tipos.
}

public static class Demo
{
    public static void Correr()
    {
        var cuotas = new List<Cuota>
        {
            new CuotaNormal(1, 500, DateTime.Today.AddDays(-10)),
            new CuotaNormal(2, 500, DateTime.Today.AddDays(-5)),
            new CuotaCondonada(3, 500, DateTime.Today.AddDays(-20)),
        };

        Console.WriteLine("-- fin de mes: se calcula la mora solo donde APLICA --");
        foreach (var cuota in cuotas)
        {
            if (cuota is IConMora conMora)
            {
                Console.WriteLine($"Cuota #{cuota.Numero}: mora = {conMora.CalcularMora():0.00} Bs");
            }
            else
            {
                Console.WriteLine($"Cuota #{cuota.Numero}: condonada, no genera mora");
            }
        }
        Console.WriteLine("Cero explosiones: cada tipo promete SOLO lo que cumple.");
    }
}

// H3 · BASE — sin patrones.

namespace Creditos.Base;

public class Cuota
{
    public int Numero { get; }
    public decimal Monto { get; }
    public DateTime FechaVencimiento { get; }
    public bool Pagada { get; private set; }

    public Cuota(int numero, decimal monto, DateTime fechaVencimiento)
    {
        Numero = numero;
        Monto = monto;
        FechaVencimiento = fechaVencimiento;
        Pagada = false;
    }

    public void MarcarComoPagada() => Pagada = true;

    public bool EstaVencida() => !Pagada && DateTime.Today > FechaVencimiento;
}

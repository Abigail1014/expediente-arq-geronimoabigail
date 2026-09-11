// H3 · BASE — sin patrones. El Crédito se arma "a mano", con new y asignaciones directas.

namespace Creditos.Base;

public class Credito
{
    public int Id { get; }
    public Cliente Cliente { get; }
    public decimal MontoTotal { get; }
    public decimal TasaInteres { get; }
    public int PlazoMeses { get; }
    public List<Cuota> Cuotas { get; } = new();
    public string Estado { get; private set; } = "Activo";

    public Credito(int id, Cliente cliente, decimal montoTotal, decimal tasaInteres, int plazoMeses)
    {
        Id = id;
        Cliente = cliente;
        MontoTotal = montoTotal;
        TasaInteres = tasaInteres;
        PlazoMeses = plazoMeses;

        // Generación manual del plan de pagos: cuotas iguales, un mes de diferencia entre cada una.
        var montoPorCuota = (montoTotal * (1 + tasaInteres)) / plazoMeses;
        for (int i = 1; i <= plazoMeses; i++)
        {
            Cuotas.Add(new Cuota(i, montoPorCuota, DateTime.Today.AddMonths(i)));
        }
    }

    public void Cerrar() => Estado = "Cerrado";
}

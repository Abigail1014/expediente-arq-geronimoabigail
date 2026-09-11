// H3 · CON BUILDER.
// Antes (base/): un solo constructor con todos los parámetros obligatorios de una.
// Ahora: el Crédito tiene más configuración opcional (seguro, período de gracia, cuota
// inicial) y eso ya no cabe bien en un constructor de una línea sin que se vuelva ilegible.
// CreditoBuilder.cs arma el objeto paso a paso, solo con lo que aplica en cada caso.

namespace Creditos.ConBuilder;

public class Credito
{
    public int Id { get; }
    public Cliente Cliente { get; }
    public decimal MontoTotal { get; }
    public decimal TasaInteres { get; }
    public int PlazoMeses { get; }
    public bool SeguroDesgravamen { get; }
    public int PeriodoGraciaMeses { get; }
    public List<Cuota> Cuotas { get; } = new();
    public string Estado { get; private set; } = "Activo";

    // Constructor interno: solo el Builder arma un Credito completo y consistente.
    internal Credito(int id, Cliente cliente, decimal montoTotal, decimal tasaInteres,
        int plazoMeses, bool seguroDesgravamen, int periodoGraciaMeses)
    {
        Id = id;
        Cliente = cliente;
        MontoTotal = montoTotal;
        TasaInteres = tasaInteres;
        PlazoMeses = plazoMeses;
        SeguroDesgravamen = seguroDesgravamen;
        PeriodoGraciaMeses = periodoGraciaMeses;

        var tasaEfectiva = tasaInteres + (seguroDesgravamen ? 0.005m : 0m);
        var montoPorCuota = (montoTotal * (1 + tasaEfectiva)) / plazoMeses;
        for (int i = 1; i <= plazoMeses; i++)
        {
            var vencimiento = DateTime.Today.AddMonths(periodoGraciaMeses + i);
            Cuotas.Add(new Cuota(i, montoPorCuota, vencimiento));
        }
    }

    public void Cerrar() => Estado = "Cerrado";
}

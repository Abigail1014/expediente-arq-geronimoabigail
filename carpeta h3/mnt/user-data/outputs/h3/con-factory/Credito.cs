// H3 · CON FACTORY METHOD.
// Antes (base/): quien creaba el crédito tenía que saber a mano qué tasa y qué reglas le tocaban.
// Ahora: Credito es la clase abstracta del contrato; cada subtipo sabe su propia tasa.
// CreditoFactory.cs concentra la decisión de "qué clase instanciar" en un solo lugar.

namespace Creditos.ConFactory;

public abstract class Credito
{
    public int Id { get; }
    public Cliente Cliente { get; }
    public decimal MontoTotal { get; }
    public int PlazoMeses { get; }
    public List<Cuota> Cuotas { get; } = new();
    public string Estado { get; private set; } = "Activo";

    protected Credito(int id, Cliente cliente, decimal montoTotal, int plazoMeses)
    {
        Id = id;
        Cliente = cliente;
        MontoTotal = montoTotal;
        PlazoMeses = plazoMeses;

        var montoPorCuota = (montoTotal * (1 + ObtenerTasaInteres())) / plazoMeses;
        for (int i = 1; i <= plazoMeses; i++)
        {
            Cuotas.Add(new Cuota(i, montoPorCuota, DateTime.Today.AddMonths(i)));
        }
    }

    protected abstract decimal ObtenerTasaInteres();   // ← cada subtipo conoce su propia regla

    public void Cerrar() => Estado = "Cerrado";
}

public class CreditoConsumo : Credito
{
    public CreditoConsumo(int id, Cliente cliente, decimal montoTotal, int plazoMeses)
        : base(id, cliente, montoTotal, plazoMeses) { }

    protected override decimal ObtenerTasaInteres() => 0.15m;
}

public class CreditoHipotecario : Credito
{
    public CreditoHipotecario(int id, Cliente cliente, decimal montoTotal, int plazoMeses)
        : base(id, cliente, montoTotal, plazoMeses) { }

    protected override decimal ObtenerTasaInteres() => 0.08m;
}

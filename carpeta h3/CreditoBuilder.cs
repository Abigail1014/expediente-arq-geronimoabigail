// H3 · CON BUILDER.
// Arma el Crédito paso a paso: solo se configura lo que aplica a cada caso, y el
// orden de las llamadas no importa. Construir() es el único lugar que sabe ensamblar
// el objeto final.

namespace Creditos.ConBuilder;

public class CreditoBuilder
{
    private int _id;
    private Cliente? _cliente;
    private decimal _montoTotal;
    private decimal _tasaInteres;
    private int _plazoMeses;
    private bool _seguroDesgravamen;
    private int _periodoGraciaMeses;

    public CreditoBuilder ConId(int id) { _id = id; return this; }
    public CreditoBuilder ParaCliente(Cliente cliente) { _cliente = cliente; return this; }
    public CreditoBuilder ConMonto(decimal monto) { _montoTotal = monto; return this; }
    public CreditoBuilder ConTasa(decimal tasa) { _tasaInteres = tasa; return this; }
    public CreditoBuilder ConPlazoMeses(int meses) { _plazoMeses = meses; return this; }
    public CreditoBuilder ConSeguroDesgravamen() { _seguroDesgravamen = true; return this; }
    public CreditoBuilder ConPeriodoGracia(int meses) { _periodoGraciaMeses = meses; return this; }

    public Credito Construir()
    {
        if (_cliente is null)
            throw new InvalidOperationException("Un crédito necesita un cliente.");
        if (_plazoMeses <= 0)
            throw new InvalidOperationException("El plazo debe ser mayor a cero.");

        return new Credito(_id, _cliente, _montoTotal, _tasaInteres, _plazoMeses,
            _seguroDesgravamen, _periodoGraciaMeses);
    }
}

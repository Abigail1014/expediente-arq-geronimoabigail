// H3 · CON FACTORY METHOD.
// El código cliente (Demo) ya no elige "new CreditoConsumo(...)" a mano: pide un tipo, y la
// fábrica decide qué clase concreta instanciar. Si mañana aparece CreditoVehicular, se agrega
// aquí y el cliente no cambia una sola línea.

namespace Creditos.ConFactory;

public enum TipoCredito
{
    Consumo,
    Hipotecario
}

public static class CreditoFactory
{
    public static Credito CrearCredito(TipoCredito tipo, int id, Cliente cliente, decimal montoTotal, int plazoMeses)
    {
        return tipo switch
        {
            TipoCredito.Consumo => new CreditoConsumo(id, cliente, montoTotal, plazoMeses),
            TipoCredito.Hipotecario => new CreditoHipotecario(id, cliente, montoTotal, plazoMeses),
            _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Tipo de crédito no soportado")
        };
    }
}

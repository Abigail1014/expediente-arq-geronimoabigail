// H3 · BASE — sin patrones. Transcripción simple del diagrama del H2.

namespace Creditos.Base;

public class Cliente
{
    public int Id { get; }
    public string Nombre { get; }
    public string CI { get; }
    public string Telefono { get; }

    public Cliente(int id, string nombre, string ci, string telefono)
    {
        Id = id;
        Nombre = nombre;
        CI = ci;
        Telefono = telefono;
    }

    public override string ToString() => $"{Nombre} (CI {CI})";
}

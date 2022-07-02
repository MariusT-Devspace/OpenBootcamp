
Cliente cliente1 = new Cliente("Juan", "628776574", "36729 Passeig Verduzco, 50", "juanjo654345@live.com", true);
Console.WriteLine(cliente1);

public struct Cliente
{
    public Cliente(string nombre, string telefono, string direccion, 
        string email, bool esNuevoCliente)
    {
        Nombre = nombre;
        Telefono = telefono;
        Direccion = direccion; 
        Email = email;
        EsNuevoCliente = esNuevoCliente;
    }

    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public bool EsNuevoCliente { get; set; }

    public override string ToString() => 
        $"Nombre: {Nombre}\n" +
        $"Teléfono: {Telefono}\n" +
        $"Dirección: {Direccion}\n" +
        $"Email: {Email}\n" +
        $"Es nuevo cliente: {EsNuevoCliente}\n";

}

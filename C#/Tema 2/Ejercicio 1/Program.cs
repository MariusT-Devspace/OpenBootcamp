
Console.WriteLine("Introduce tus datos:");
Console.WriteLine();

Console.WriteLine("Nombre:");
string nombre = Console.ReadLine();


Console.WriteLine("Edad:");
int edad = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Email:");
string email = Console.ReadLine();

Console.WriteLine("Número de teléfono");
string phone = Console.ReadLine();

string mensaje = ("Gracias por inscribirte, " + nombre + "!");
Console.WriteLine();
Console.WriteLine(mensaje);
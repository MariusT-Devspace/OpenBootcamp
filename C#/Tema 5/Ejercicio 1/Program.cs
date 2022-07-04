
// Pide datos
Console.WriteLine("Tu nombre:");
string nombre = Console.ReadLine();

Console.WriteLine("Email:");
string email = Console.ReadLine();

string cupon1 = "CUPPRIME30";
string cupon2 = "CUPSTARTER5";

Console.WriteLine("Cupón:");

string cuponInput = Console.ReadLine();

double precio = 59.99d;

// Valida el cupón y calcula el descuento
double desc = 0.00;
if(cuponInput == cupon1)
{
    desc = Math.Round(precio * .30d, 2) - 0.01;  // Resta 0.01 para que el redondeo resulte en x.99
    Console.WriteLine("Cupón válido");
} else if(cuponInput == cupon2)
{
    desc = Math.Round(precio * .05d, 2) - 0.01;
    Console.WriteLine("Cupón válido");
}
else
{
    Console.WriteLine("Cupón inválido");
}

// Imprime el precio
Console.WriteLine();
Console.WriteLine($"Precio original: {precio}");
Console.WriteLine($"Descuento: {desc}");

double? precioDesc = null;
if (desc != 0)
{
    precioDesc = Math.Round(precio - desc, 2) - 0.01;
}

Console.Write("Precio final: ");
if(precioDesc != null)
{
    Console.WriteLine(precioDesc);
}
else
{
    Console.WriteLine(precio);
}



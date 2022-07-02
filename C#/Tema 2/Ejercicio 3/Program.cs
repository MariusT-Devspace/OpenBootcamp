
int a = 21;
bool esMayorOIgual = a >= 18;
if (esMayorOIgual)
{
    Console.WriteLine($"{a} es mayor o igual que 18");
}
else
{
    Console.WriteLine($"{a} es menor que 18");
}


char c = 'f';
bool isA = c == 'a';
Console.WriteLine();
if (isA)
{
    Console.WriteLine($"'{c}' es igual a 'a'");
}
else
{
    Console.WriteLine($"'{c}' no es igual a 'a'");
}


Console.WriteLine();
if (esMayorOIgual && isA)
{
    Console.WriteLine("Se cumplen las condiciones!");
}
else if(esMayorOIgual || isA)
{
    Console.WriteLine("Se cumple sólo una condición");
}
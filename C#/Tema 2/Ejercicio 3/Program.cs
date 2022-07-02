
int a = 21;
bool es_mayor_o_igual = a >= 18;
if (es_mayor_o_igual)
{
    Console.WriteLine($"{a} es mayor o igual que 18");
}
else
{
    Console.WriteLine($"{a} es menor que 18");
}


char c = 'f';
bool es_a = c == 'a';
Console.WriteLine();
if (es_a)
{
    Console.WriteLine($"'{c}' es igual a 'a'");
}
else
{
    Console.WriteLine($"'{c}' no es igual a 'a'");
}


Console.WriteLine();
if (es_mayor_o_igual && es_a)
{
    Console.WriteLine("Se cumplen las condiciones!");
}
else if(es_mayor_o_igual || es_a)
{
    Console.WriteLine("Se cumple sólo una condición");
}

Console.WriteLine("Escribe un número:");
int num = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
for(int i = 1; i <= 10; i++)
{
    Console.WriteLine($"{num} x {i} = {num * i}");
}

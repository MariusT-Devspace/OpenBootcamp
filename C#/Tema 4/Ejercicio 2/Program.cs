Console.WriteLine("Introduce un número positivo o negativo (0 para salir del prorgama.)");

int num, contPos = 0, contNeg = 0;
do
{

    if (contPos > 0 || contNeg > 0)
        {
            Console.WriteLine("Prueba otro número");
        }

    num = Convert.ToInt32(Console.ReadLine());
    if (num != 0)
    {
        if (num > 0)
        {
            Console.WriteLine($"Es positivo");
            contPos++;
        }
        else
        {
            Console.WriteLine($"Es negativo");
            contNeg++;
        }
        Console.WriteLine();
        Console.WriteLine($"Positivos: {contPos}    Negativos: {contNeg}");
        Console.WriteLine();
    }
    else
    {
        break;
    }
    
} while (true);


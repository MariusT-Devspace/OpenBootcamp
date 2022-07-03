
// Pide datos
Console.WriteLine("Ancho:");
int ancho = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Alto:");
int alto = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Relleno [Sí (s) / No (n)]:");
char rellenoChar;
bool rellenoParse = Char.TryParse(Console.ReadLine(), out rellenoChar);


while (rellenoParse == false || (rellenoChar != 's' && rellenoChar != 'n'))

{
    Console.WriteLine("Elige una opción válida: (s / n)");
    rellenoParse = Char.TryParse(Console.ReadLine(), out rellenoChar);
}

bool relleno;
if(rellenoChar == 's')
{
    relleno = true;
}
else
{
    relleno = false;
}

Console.WriteLine("Número de figuras para dibujar");
int numFiguras = Convert.ToInt32(Console.ReadLine());

// Dibuja rectángulos
for (int i = 0; i < numFiguras; i++)
{
    if (relleno == true)
    {
        Console.WriteLine();
        for (int j = 0; j < alto; j++)
        {
            for (int k = 0; k < ancho; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine();
        for (int j = 0; j < alto; j++)
        {
            for (int k = 0; k < ancho; k++)
            {
                if (j == 0 || j == alto - 1 || k == 0 || k == ancho - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }

            }
            Console.WriteLine();
        }
    }
}



// Pide datos
Console.WriteLine("Ancho:");
int ancho;
bool anchoParse = int.TryParse(Console.ReadLine(), out ancho);
while (anchoParse == false)
{
    Console.WriteLine("Por favor, escribe un número:");
    anchoParse = int.TryParse(Console.ReadLine(), out ancho);
}

Console.WriteLine("Alto:");
int alto;
bool altoParse = int.TryParse(Console.ReadLine(), out alto);
while (altoParse == false)
{
    Console.WriteLine("Por favor, escribe un número");
    altoParse = int.TryParse(Console.ReadLine(), out alto);
}

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

// Dibuja figuras
int numEspacioEntreFiguras = 6;

if (relleno == true)
{
    Console.WriteLine();
    for (int i = 0; i < alto; i++)
    {
        for(int j = 0; j < numFiguras; j++)
        {
            for (int k = 0; k < ancho; k++)
            {
                Console.Write("*");
            }
            for(int l = 0; l < numEspacioEntreFiguras; l++)
                Console.Write(" ");
        }
        
        Console.WriteLine();
    }
}
else
{
    Console.WriteLine();
    for (int i = 0; i < alto; i++)
    {
        for(int j = 0; j < numFiguras; j++)
        {
            for (int k = 0; k < ancho; k++)
            {
                if (i == 0 || i == alto - 1 || k == 0 || k == ancho - 1)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            for (int l = 0; l < numEspacioEntreFiguras; l++)
                Console.Write(" ");
        }
        
        Console.WriteLine();
    }
}



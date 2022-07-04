
// Muestra los lenguajes de programación a elegir
Console.WriteLine("Selecciona el lenguaje de programación:");
Console.WriteLine();

string[] lenguajesProgramacion = { "Java", "Python", "C", "Javascript", "C#", "Go", "Kotlin", "Dart" };

for (int i = 0; i < lenguajesProgramacion.Length; i++)
    Console.WriteLine($"{i+1}. {lenguajesProgramacion[i]}");
Console.WriteLine();

// Maneja la elección del usuario
int seleccionUsuario;
bool seleccionUsuarioBool = int.TryParse(Console.ReadLine(), out seleccionUsuario);

bool isSelectionInRange = seleccionUsuario > 0 && seleccionUsuario <= lenguajesProgramacion.Length;
bool isOptionInvalid = seleccionUsuarioBool == false || !isSelectionInRange;

while(isOptionInvalid)
{
    Console.WriteLine("Elige una opción válida:");
    seleccionUsuarioBool = int.TryParse(Console.ReadLine(), out seleccionUsuario);

    isSelectionInRange = seleccionUsuario > 0 && seleccionUsuario <= lenguajesProgramacion.Length;
    isOptionInvalid = seleccionUsuarioBool == false || !isSelectionInRange;

}

// Imprime el resultado
Console.WriteLine();
switch (seleccionUsuario)
{
    case 1: 
        Console.WriteLine($"Lenguaje de programación: Java");
        break;
    case 2: 
        Console.WriteLine($"Lenguaje de programación: Python");
        break;
    case 3:
        Console.WriteLine($"Lenguaje de programación: C");
        break;
    case 4:
        Console.WriteLine($"Lenguaje de programación: Javascript");
        break;
    case 5:
        Console.WriteLine($"Lenguaje de programación: C#");
        Console.WriteLine($"Hola, mundo");
        break;
    case 6:
        Console.WriteLine($"Lenguaje de programación: Go");
        break;
    case 7:
        Console.WriteLine($"Lenguaje de programación: Kotlin");
        break;
    case 8:
        Console.WriteLine($"Lenguaje de programación: Dart");
        break;
}

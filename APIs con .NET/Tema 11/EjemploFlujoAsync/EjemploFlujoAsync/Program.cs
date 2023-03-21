using EjemploFlujoAsync;
using System;
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

// Calculadora de Hipotecas Síncrona

stopwatch.Start();

Console.WriteLine("\n*************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Síncrona");
Console.WriteLine("\n*************************************************");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"\nAños de Vida Laboral obtenidos: {aniosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoIndefinido();
Console.WriteLine($"\nEs tipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto}");

var gastosMensuales = CalculadoraHipotecaSync.ObtenerGastosMensuales();
Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensuales}");

var hipotecaConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(
        aniosVidaLaboral,
        esTipoContratoIndefinido,
        sueldoNeto,
        gastosMensuales,
        cantidadSolicitada: 50000,
        aniosPagar: 30
    );

var resultado = hipotecaConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis finalizado. Su solicitud de hipoteca ha sido: {resultado}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación ha durado: {stopwatch.Elapsed}");


// Calculadora de Hipotecas Asíncrona

// Reiniciar el contador de tiempo
stopwatch.Restart();

Console.WriteLine("\n");
Console.WriteLine("\n**************************************************");
Console.WriteLine("\nBienvenido a la Calculadora de Hipotecas Asíncrona");
Console.WriteLine("\n**************************************************");

Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboralAsync();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoIndefinidoAsync();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNetoAsync();
Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObtenerGastosMensualesAsync();

var analisisHipotecaTasks = new List<Task>
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask
};

while (analisisHipotecaTasks.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks);

    if(tareaFinalizada == aniosVidaLaboralTask)
    {
        Console.WriteLine($"\nAños de Vida Laboral obtenidos: {aniosVidaLaboralTask.Result}");
    }
    else if(tareaFinalizada == esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nEs tipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if(tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result}");
    }
    else if(tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos mensuales obtenidos: {gastosMensualesTask.Result}");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada);
}

var hipotecaConcedidaAsync = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(
        aniosVidaLaboralTask.Result,
        esTipoContratoIndefinidoTask.Result,
        sueldoNetoTask.Result,
        gastosMensualesTask.Result,
        cantidadSolicitada: 50000,
        aniosPagar: 30
    );

var resultadoAsync = hipotecaConcedidaAsync ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación ha durado: {stopwatch.Elapsed}");

Console.Read();




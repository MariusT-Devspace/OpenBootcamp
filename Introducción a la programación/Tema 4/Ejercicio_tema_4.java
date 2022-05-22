/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Project/Maven2/JavaApp/src/main/java/${packagePath}/${mainClassName}.java to edit this template
 */

package com.mycompany.ejercicio_tema_4;

import javax.print.attribute.standard.OutputDeviceAssigned;

/**
 *
 * @author windo
 */
public class Ejercicio_tema_4 {

    public static void main(String[] args) {
        int numeroIf = 4;
        if(numeroIf > 0){
            System.out.println("numeroIf es positivo");
        }else if(numeroIf < 0){
            System.out.println("numeroIf es negativo");
        }else{
            System.out.println("numeroIf es 0");
        }
        
        int numeroWhile = 1;
        while(numeroWhile < 3){
            System.out.println("numeroWhile es: " + numeroWhile);
            numeroWhile++;
        }
        
        int numeroDoWhile = 4;
        do{
            System.out.println("numeroDoWhile es: " + numeroDoWhile);
            numeroDoWhile++;
            break;
        }while(numeroDoWhile < 3);
        
        int numeroFor = 0;
        for(int i = 0; numeroFor <= 3; i++){
            System.out.println("numeroFor es: " + numeroFor);
            numeroFor++;
        }
        
        String estacion = "Verano";
        switch(estacion){
            case "Primavera": 
                System.out.println("Estamos en: " + estacion);
                break;
            case "Verano": 
                System.out.println("Estamos en: " + estacion);
                break;
            case "Otoño": 
                System.out.println("Estamos en: " + estacion);
                break;
            case "Invierno": 
                System.out.println("Estamos en: " + estacion);
                break;
            default:
                System.out.println("Introduzca una estación!");
        }
    }
}

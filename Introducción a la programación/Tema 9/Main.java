/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Project/Maven2/JavaApp/src/main/java/${packagePath}/${mainClassName}.java to edit this template
 */

package com.mycompany.tema_9;

/**
 *
 * @author windo
 */
public class Main {

    public static void main(String[] args) {
        Cliente cliente1 = new Cliente("Carlos Santana", "674885075", 26, 20000);
        System.out.println("Cliente:");
        System.out.println("Nombre: " + cliente1.nombre + "  Teléfono: " 
                + cliente1.telefono + "  Edad: " + cliente1.edad + "  Crédito: " + cliente1.credito);
        
        System.out.println("");
        System.out.println("Trabajador:");
        Trabajador trabajador1 = new Trabajador("Ana Rodriguez", "633555632", 38,28000);
        System.out.println("Teléfono: " + trabajador1.nombre + "  Teléfono: " 
                + trabajador1.telefono + "  Edad: " + trabajador1.edad + "  Salario: " + trabajador1.salario);
    }
}

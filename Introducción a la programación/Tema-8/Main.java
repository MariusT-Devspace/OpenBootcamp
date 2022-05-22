/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Project/Maven2/JavaApp/src/main/java/${packagePath}/${mainClassName}.java to edit this template
 */

package com.mycompany.tema_8;

/**
 *
 * @author windo
 */
public class Main {

    public static void main(String[] args) {
        Persona persona1 = new Persona();
        persona1.setNombre("Juan Ramón");
        persona1.setTelefono("634756996");
        persona1.setEdad(34);
        
        System.out.println("Nombre: " + persona1.getNombre());
        System.out.println("Teléfono: " + persona1.getTelefono());
        System.out.println("Edad: " + persona1.getEdad());
    }
}

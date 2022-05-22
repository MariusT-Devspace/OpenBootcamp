/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Project/Maven2/JavaApp/src/main/java/${packagePath}/${mainClassName}.java to edit this template
 */

package com.mycompany.e1;

/**
 *
 * @author windo
 */
public class E1 {

    public static void main(String[] args) {
        int n1 = 3, n2 = 9, n3 = 6;
        int suma = suma(n1, n2, n3);
        System.out.print("Suma: " + suma);
    }
    
    public static int suma(int n1, int n2, int n3){
        int suma = n1 + n2 + n3;
        return suma;
    }
}

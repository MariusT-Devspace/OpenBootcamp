package com.example;

public class Ejercicio1 {

    public static void main(String[] args){
        System.out.println();
        String texto = "Hola, mundo";
        System.out.println("Text:");
        System.out.println(texto);
        String reverseString = reverse(texto);
        System.out.println();
        System.out.println("Reverse:");
        System.out.println(reverseString);
    }

    public static String reverse(String texto){
        String reverseString = "";
        char[] charArray = texto.toCharArray();
        for(int i = charArray.length - 1; i >= 0; i--){
            reverseString = reverseString.concat(String.valueOf(charArray[i]));
        }
        return reverseString;
    }
}

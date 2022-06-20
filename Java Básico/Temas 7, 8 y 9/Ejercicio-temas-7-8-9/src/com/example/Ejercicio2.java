package com.example;

public class Ejercicio2 {

    public static void main(String[] args){
        System.out.println();
        System.out.println("String array:");
        String[] stringArray = {"JAVA", "Python", "GO", "R"};
        printArray(stringArray);
    }

    public static void printArray(String[] array){
        for(String s : array){
            System.out.print(s);
            if(s != array[array.length - 1]){
                System.out.print(", ");
            }
        }
        System.out.println();
    }
}

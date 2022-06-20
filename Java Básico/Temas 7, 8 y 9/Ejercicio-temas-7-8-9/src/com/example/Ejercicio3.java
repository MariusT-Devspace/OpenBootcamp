package com.example;

public class Ejercicio3 {

    public static void main(String[] args){
        int[][] integerArray = {{13, 5}, {32, 11}, {24, 55}, {27, 18}};
        System.out.println();
        System.out.println("Two dimensional array:");
        print2dArray(integerArray);
    }

    public static void print2dArray(int[][] array){
        for(int i = 0; i < array.length; i++){
            for(int j = 0; j < 2; j++){
                System.out.print("Posición: [" + i + "][" + j + "]  ");
                System.out.print("Elemento: " + array[i][j]);
                System.out.println();
            }
        }
    }
}

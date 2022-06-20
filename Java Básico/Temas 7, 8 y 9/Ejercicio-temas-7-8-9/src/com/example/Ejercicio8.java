package com.example;

public class Ejercicio8 {

    public static void main(String[] args){
        System.out.println();
        try{
            int a = 4;
            int b = 0;
            float divisionAB = dividePorCero(a, b);
            System.out.println("División: " + divisionAB);
        }catch(ArithmeticException e){
            System.out.println("Esto no puede hacerse");
        }finally{
            System.out.println("Demo de código");
        }
    }

    public static float dividePorCero(int a, int b) throws ArithmeticException{
        if(b == 0){
            throw new ArithmeticException();
        }
        return (float)a / b;
    }
}

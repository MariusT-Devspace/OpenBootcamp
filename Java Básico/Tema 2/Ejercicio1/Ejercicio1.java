package com.example;

public class Ejercicio1 {
    static final float IVA = 0.21f;

    static double sumaIva(double precio){
        return precio + precio * IVA;
    }

    public static void main(String[] args){
        double precioBase = 499.99;
        double precioIva = sumaIva(precioBase);

        System.out.println("Precio base: " + precioBase);
        System.out.println("Precio mas iva: " + String.format("%.2f",precioIva));
    }
}

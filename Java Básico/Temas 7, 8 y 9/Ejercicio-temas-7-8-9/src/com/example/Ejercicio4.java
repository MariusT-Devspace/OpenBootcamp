package com.example;

import java.util.Vector;

public class Ejercicio4 {

    public static void main(String[] args){
        System.out.println();
        Vector<Short> vector = new Vector();
        vector.add((short)45);
        vector.add((short)33);
        vector.add((short)19);
        vector.add((short)66);
        vector.add((short)78);
        System.out.println("Initial vector: ");
        System.out.println(vector);
        System.out.println();
        vector.removeElementAt(1);
        vector.removeElementAt(1);
        System.out.println("Modified vector: ");
        System.out.println(vector);
    }
}

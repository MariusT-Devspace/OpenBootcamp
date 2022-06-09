package com.example;

public class Main {

    public static void main(String[] args){
        String[] listaTexto = {"Hola,", "este", "es", "un", "ejemplo", "de", "concatenación", "de", "cadenas"};
        String concatenatedString = "";

        for(String item : listaTexto){
            concatenatedString += " " + item;
        }
        System.out.println(concatenatedString);
    }
}

package com.example;

import java.io.*;

public class Ejercicio9 {

    public static void main(String[] args){
        System.out.println();
        try{
            InputStream fileIn = new FileInputStream("fileIn.txt");
            BufferedInputStream fileInBuffered = new BufferedInputStream(fileIn);
            PrintStream fileOut = new PrintStream("fileOut.txt");
            copyFile(fileInBuffered, fileOut);
            System.out.println("Archivo copiado con éxito!");
            fileInBuffered.close();
        }catch(FileNotFoundException e){
            System.out.println("File not found!");
        }catch(NullPointerException e){
            System.out.println("Null pointer exception");
        } catch (IOException e) {
            System.out.println("IO exception");
        }
        System.out.println();
    }

    public static void copyFile(BufferedInputStream fileIn, PrintStream fileOut) throws IOException {
        if(fileIn == null){
            throw new IOException();
        }
        int dato = fileIn.read();
        while(dato != -1){
            fileOut.write(dato);
            dato = fileIn.read();
        }

    }
}

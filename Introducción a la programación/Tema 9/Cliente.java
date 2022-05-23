/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.tema_9;

/**
 *
 * @author windo
 */
public class Cliente extends Persona{
    public int credito;

    public Cliente(String nombre, String telefono, int edad, int credito) {
        super(nombre, telefono, edad);
        this.credito = credito;
    }
    
    
    
    
}

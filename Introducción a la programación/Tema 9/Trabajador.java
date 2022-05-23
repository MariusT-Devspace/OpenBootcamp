/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.tema_9;

/**
 *
 * @author windo
 */
public class Trabajador extends Persona{
    public int salario;

    public Trabajador(String nombre, String telefono, int edad, int salario) {
        super(nombre, telefono, edad);
        this.salario = salario;
    }
    
}

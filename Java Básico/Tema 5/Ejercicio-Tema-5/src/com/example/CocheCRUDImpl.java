package com.example;

public class CocheCRUDImpl implements CocheCRUD{

    @Override
    public void save() {
        System.out.println("Método save()");
    }

    @Override
    public void findAll() {
        System.out.println("Método findAll()");
    }

    @Override
    public void delete() {
        System.out.println("Método delete()");
    }
}

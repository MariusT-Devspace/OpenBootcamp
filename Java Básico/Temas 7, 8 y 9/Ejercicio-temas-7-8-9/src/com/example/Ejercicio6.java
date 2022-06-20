package com.example;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class Ejercicio6 {

    public static void main(String[] args){
        System.out.println();
        ArrayList<String> arrayList = new ArrayList<String>();
        arrayList.add("MacOS");
        arrayList.add("Linux");
        arrayList.add("Windows");
        arrayList.add("Chrome OS");
        LinkedList<String> linkedList = new LinkedList<>(arrayList);

        System.out.println("ArrayList:");
        printList(arrayList);

        System.out.println();
        System.out.println("LinkedList:");
        printList(linkedList);
    }

    public static void printList(List list){
        for(Object element : list.toArray()){
            System.out.print(element.toString());
            if(element != list.get(list.size()-1)){
                System.out.print(", ");
            }
        }
        System.out.println();
    }
}

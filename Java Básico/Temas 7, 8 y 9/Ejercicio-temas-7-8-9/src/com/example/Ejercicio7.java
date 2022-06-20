package com.example;

import java.util.ArrayList;
import java.util.List;

public class Ejercicio7 {

    public static void main(String[] args){
        System.out.println();
        ArrayList<Integer> integerArrayList =new ArrayList<>();
        for (int i = 0; i < 10; i++){
            integerArrayList.add(i+1);
        }
        System.out.println("Integer ArrayList:");
        printList(integerArrayList);
        ArrayList<Integer> removedEvenArrayList = removeEvenNumbers(integerArrayList);
        System.out.println();
        System.out.println("ArrayList sin números pares:");
        printList(removedEvenArrayList);
    }

    public static void printList(ArrayList list){
        for(Object element : list){
            System.out.print(element.toString());
            if(element != list.get(list.size()-1)){
                System.out.print(", ");
            }
        }
        System.out.println();
    }

    public static ArrayList<Integer> removeEvenNumbers(ArrayList<Integer> list){
        for(int i = 0; i < list.size();i++){
            if(list.get(i) % 2 == 0){
                list.remove(i);
            }
        }
        return list;
    }
}

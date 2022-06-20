package com.example.ejercicio10;

import java.io.*;
import java.util.*;


/**
 * Esta es una app CRUD de ejemplo que nos permite leer, insertar, editar y borrar contactos desde un fichero CSV
 */

public class Main {
    public static String contactsCSV = "contacts.csv";
    public static ArrayList<Contact> contacts;

    public static void main(String[] args){
        try{
            // Load and sort contacts
            InputStream in = new FileInputStream(contactsCSV);
            BufferedInputStream buffIn = new BufferedInputStream(in);
            ContactsCrudCSV contactsCrud = new ContactsCrudCSV();
            contacts = contactsCrud.loadContacts(buffIn);
            contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));
            System.out.println();
            System.out.println("Your contacts:");
            for(Contact c : contacts){
                System.out.println(c.toString());
            }


            // Create contact
            // Contact to insert
            Map<String, String> newContactName = new HashMap<>();
            newContactName.put("First Name", "John");
            newContactName.put("Last Name", "Petrucci");
            Map<String, String> newContactAddress = new HashMap<>();
            newContactAddress.put("Address", "3092 Fulton Street");
            newContactAddress.put("City", "Arbovale");
            newContactAddress.put("County", "Pocahontas");
            newContactAddress.put("State", "WV");
            newContactAddress.put("ZIP", "24915");
            String newContactPhone1 = "304-456-6012";
            String newContactPhone2 = "304-838-7516";
            String newContactEmail = "johnptcc@gmail.com";
            Contact newContact = new Contact(newContactName, newContactAddress, newContactPhone1, newContactPhone2, newContactEmail);
            // Insert contact
            System.out.println();
            contactsCrud.createContact(newContact);
            // Check contact is inserted successfully
            int contactCreated = contactsCrud.searchContact(newContactName);
            if (contactCreated >= 0) {
                System.out.println(contacts.get(contactCreated).toString());
            }else{
                System.out.println("Contact not found!");
            }

            // Search contact
            Map<String, String> nameToSearch = new HashMap<>();
            nameToSearch.put("First Name", "Simona");
            nameToSearch.put("Last Name", "Morasca");
            int searchContact = contactsCrud.searchContact(nameToSearch);
            System.out.println();
            if (searchContact >= 0) {
                System.out.println("Search " + nameToSearch.get("First Name") + " " + nameToSearch.get("Last Name") + ":");
                System.out.println(searchContact);
            }else{
                System.out.println("Contact not found!");
            }


            // Edit contact
            Map<String, String> nameToEdit = new HashMap<>();
            nameToEdit.put("First Name", "John");
            nameToEdit.put("Last Name", "Petrucci");
            int idToEdit = contactsCrud.searchContact(nameToEdit);
            System.out.println();
            if (idToEdit >= 0) {
                System.out.println("Contact to edit:");
                System.out.println(contacts.get(idToEdit));
                String[] fieldsToEdit = {"Last Name", "phone2"};
                String[] newValues = {"Pet.", "304-422-4586"};
                int editedId = contactsCrud.editContact(idToEdit, fieldsToEdit, newValues);
                System.out.println(contacts.get(editedId).toString());
            }else{
                System.out.println("Contact not found!");
            }


            // Delete contact
            Map<String, String> nameToDelete = new HashMap<>();
            nameToDelete.put("First Name", "Simona");
            nameToDelete.put("Last Name", "Morasca");
            int idToDelete = contactsCrud.searchContact(nameToDelete);
            System.out.println();
            if (idToDelete >= 0) {
                System.out.println("Contact to delete:");
                System.out.println(contacts.get(idToDelete));
                System.out.println();
                contactsCrud.deleteContact(idToDelete);
            }else{
                System.out.println("Contact not found!");
            }
        }catch(FileNotFoundException fnfe){
            System.out.println("Error: File not found!");
        }catch(IOException ioe){
            ioe.printStackTrace();
        }catch(Exception e){
            e.printStackTrace();
        }
    }

}

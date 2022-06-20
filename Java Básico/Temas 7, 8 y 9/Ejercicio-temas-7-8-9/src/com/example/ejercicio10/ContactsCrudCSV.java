package com.example.ejercicio10;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.io.PrintStream;
import java.util.*;

import static com.example.ejercicio10.Main.contacts;
import static com.example.ejercicio10.Main.contactsCSV;

public class ContactsCrudCSV implements ContactsCRUD {
    /**
     * This method loads the CSV file into an ArrayList.
     * @param buffIn Buffer containing the CSV file data
     * @return ArrayList loaded with contacts
     * @throws IOException
     */
    @Override
    public ArrayList<Contact> loadContacts(BufferedInputStream buffIn) throws IOException {
        ArrayList<Contact> contacts= new ArrayList<>();
        ArrayList<String> fieldNames = new ArrayList<>();
        ArrayList<String> values = new ArrayList<>();
        int data = buffIn.read();
        String s = "";
        int numLine = 1;

        while(data != -1){
            if(data == (int)'\r' || data == (int)'\n'){
                // Load field names
                if(numLine == 1){
                    fieldNames.add(s);
                    s = "";
                }else{
                    // Load values
                    values.add(s);
                    Map<String, String> name = new HashMap<>();
                    name.put("First Name", values.get(0));
                    name.put("Last Name", values.get(1));
                    Map<String, String> address = new HashMap<>();
                    address.put("Address", values.get(2));
                    address.put("City", values.get(3));
                    address.put("County", values.get(4));
                    address.put("State", values.get(5));
                    address.put("ZIP", values.get(6));
                    String phone1 = values.get(7);
                    String phone2 = values.get(8);
                    String email = values.get(9);
                    contacts.add(new Contact(name, address, phone1, phone2, email));
                    values.clear();
                    s = "";
                }
                numLine++;
                data = buffIn.read();
                data = buffIn.read();
            }else{
                if(data == (int)','){
                    if(numLine == 1){
                        fieldNames.add(s);
                    }else{
                        values.add(s);
                    }
                    s = "";
                    data = buffIn.read();
                    continue;
                }
                s = s.concat(Character.toString((char)data));
                data = buffIn.read();
            }
        }
        return contacts;
    }

    /**
     * This method inserts the contact provided via the parameter.
     * Adds the contact to the contacts ArrayList, sorts it, then updates the CSV file.
     * @param contact
     * @throws IOException
     */
    @Override
    public void createContact(Contact contact) throws IOException{
        contacts.add(contact);
        contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));

        try {
            PrintStream fileOut = new PrintStream(contactsCSV);
            updateContacts(contacts, fileOut);
            System.out.println("Contact created.");
        }catch(IOException e){
            System.out.println("Failed to create contact!");
            // Remove contact from arraylist
            Map<String, String> name = new HashMap<String, String>();
            name.put("First Name", contact.getFirstName());
            name.put("Last Name", contact.getLastName());
            contacts.remove(searchContact(name));
            contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));

            e.printStackTrace();
        }

    }

    /**
     * This method searches for a contact by name.
     * @param name  HashMap containing first and last name, used to search the contact
     * @return contact index if found, otherwise will return < 0
     */
    @Override
    public int searchContact(Map<String, String> name) {
        return Collections.binarySearch(contacts, new Contact(name, null, null, null, null),
                Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));
    }


    /**
     * This method edits the contact at the provided index.
     * Updates the fields provided in the fieldsToEdit array,
     * to the values provided in the newValues array.
     * Both arrays must match in length in order to do the updating.
     * @param idToEdit  Id of the contact to be updated
     * @param fieldsToEdit  String array containing the contact fields to be updated
     * @param newValues  String array containing the new values
     * @return the index of the updated contact. (The contacts list will be
     * sorted after updating, hence its index may be different)
     */
    @Override
    public int editContact(int idToEdit, String[] fieldsToEdit, String[] newValues) {
        Map<String, String> name = null;
        if (fieldsToEdit.length != newValues.length) {
            System.out.println("Internal error! Failed to edit contact.");
        } else {
            Contact contactToEdit = contacts.get(idToEdit);
            for (int i = 0; i < fieldsToEdit.length; i++) {
                switch (fieldsToEdit[i]) {
                    case "First Name":
                        contacts.get(idToEdit).setFirstName(newValues[i]);
                        break;
                    case "Last Name":
                        contacts.get(idToEdit).setLastName(newValues[i]);
                        break;
                    case "Address":
                        contacts.get(idToEdit).setAddress(newValues[i]);
                        break;
                    case "City":
                        contacts.get(idToEdit).setCity(newValues[i]);
                        break;
                    case "County":
                        contacts.get(idToEdit).setCounty(newValues[i]);
                        break;
                    case "State":
                        contacts.get(idToEdit).setState(newValues[i]);
                        break;
                    case "Zip":
                        contacts.get(idToEdit).setZip(newValues[i]);
                        break;
                    case "phone1":
                        contacts.get(idToEdit).setPhone1(newValues[i]);
                        break;
                    case "phone2":
                        contacts.get(idToEdit).setPhone2(newValues[i]);
                        break;
                    case "email":
                        contacts.get(idToEdit).setEmail(newValues[i]);
                        break;
                    default:
                        System.out.println("Internal error! Failed to edit contact.");
                        return -1;
                }
            }

            // Save contact name to search for later, in order to restore the unedited contact in case of update failure
            name = new HashMap<>();
            name.put("First Name", contacts.get(idToEdit).getFirstName());
            name.put("Last Name", contacts.get(idToEdit).getLastName());

            contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));

            try {
                PrintStream fileOut = new PrintStream(contactsCSV);
                updateContacts(contacts, fileOut);
                System.out.println("Contact updated successfully.");
            } catch (IOException e) {
                System.out.println("Failed to update contact!");
                // Restore unedited contact
                contacts.remove(searchContact(name));
                contacts.add(contactToEdit);
                contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));
                e.printStackTrace();
            }
        }
        return searchContact(name);
    }


    /**
     * This method deletes the contact at the provided index.
     * @param idToDelete Index of the contact to be deleted
     */
    @Override
    public void deleteContact(int idToDelete) {
        // Save the contact in case of need for restoring
       Contact contactToDelete = contacts.get(idToDelete);
        contacts.remove(idToDelete);
        contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));
        try {
            PrintStream fileOut = new PrintStream(contactsCSV);
            updateContacts(contacts, fileOut);
            System.out.println("Contact deleted successfully.");
        }catch(IOException e){
            System.out.println("Failed to delete contact!");
            // Restore contact
            contacts.add(contactToDelete);
            contacts.sort(Comparator.comparing(Contact::getFirstName).thenComparing(Contact::getLastName));

            e.printStackTrace();
        }
    }


    /**
     * This method updates the CSV file.
     * @param contacts  List of contacts to be written into the CSV file.
     * @param fileOut  PrintStream for the CSV file
     * @throws IOException
     */
    //@Override
    public void updateContacts(ArrayList<Contact> contacts, PrintStream fileOut) throws IOException {
        for(Contact c : contacts){
            fileOut.writeBytes(c.getFirstName().getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getLastName().getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getAddress().get("Address").getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getAddress().get("City").getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getAddress().get("County").getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getAddress().get("State").getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getAddress().get("ZIP").getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getPhone1().getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getPhone2().getBytes());
            fileOut.write(",".getBytes());
            fileOut.writeBytes(c.getEmail().getBytes());
            fileOut.writeBytes("\r\n".getBytes());
        }
    }

}

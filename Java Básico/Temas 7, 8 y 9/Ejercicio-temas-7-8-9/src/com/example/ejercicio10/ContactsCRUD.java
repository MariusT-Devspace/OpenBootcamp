package com.example.ejercicio10;

import java.io.BufferedInputStream;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Map;

public interface ContactsCRUD {

    void createContact(Contact contact) throws IOException;
    int searchContact(Map<String, String> name);
    int editContact(int idToEdit, String[] fieldsToEdit, String[] newValues);
    void deleteContact(int idToDelete);

    //void updateContacts(ArrayList<Contact> contacts, PrintStream fileOut) throws IOException;

}

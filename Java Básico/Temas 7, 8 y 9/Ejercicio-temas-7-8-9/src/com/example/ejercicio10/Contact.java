package com.example.ejercicio10;

import java.util.Map;

public class Contact {

    private Map<String, String> name;
    private Map<String, String> address;
    private String phone1;
    private String phone2;
    private String email;

    Contact(Map<String, String> name, Map<String, String> address, String phone1, String phone2, String email){
        this.name = name;
        this.address = address;
        this.phone1 = phone1;
        this.phone2 = phone2;
        this.email = email;
    }

    // Setters
    public void setFirstName(String firstName){
        this.name.put("First Name", firstName);
    }

    public void setLastName(String lastName){
        this.name.put("Last Name", lastName);
    }

    public void setAddress(String address){
        this.address.put("Address", address);
    }

    public void setCity(String city){
        this.address.put("City", city);
    }

    public void setCounty(String county){
        this.address.put("County", county);
    }

    public void setState(String state){
        this.address.put("State", state);
    }

    public void setZip(String zip){
        this.address.put("Zip", zip);
    }

    public void setPhone1(String phone1){
        this.phone1 = phone1;
    }

    public void setPhone2(String phone2){
        this.phone2 = phone2;
    }

    public void setEmail(String email){
        this.email = email;
    }

    // Getters
    public String getFirstName() {
        return this.name.get("First Name");
    }

    public String getLastName() {
        return this.name.get("Last Name");
    }

    public Map<String, String> getAddress(){
        return this.address;
    }


    public String getPhone1(){
        return this.phone1;
    }

    public String getPhone2(){
        return this.phone2;
    }

    public String getEmail(){
        return this.email;
    }

    @Override
    public String toString() {
        return "Contact{" +
                "name=" + name + ", " +
                "address=" + address + ", " +
                "phones={" + phone1 + ", " + phone2 + "}" + ", " +
                "email='" + email + '\'' +
                "}";
    }
}

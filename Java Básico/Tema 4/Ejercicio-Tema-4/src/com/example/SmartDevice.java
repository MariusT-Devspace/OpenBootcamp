package com.example;

import device_components.*;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class SmartDevice {
    private String brand;
    private String model;
    private Launch launch;
    private Body body;

    private Memory memory;

    private Map<String, String> comms = new HashMap<>();
    private String[] sensors;

    SmartDevice(){}

    @Override
    public String toString() {
        return "brand='" + brand + '\'' + ",\n" +
                "model='" + model + '\'' + ",\n" +
                "launch=" + launch + ",\n" +
                "body=" + body + ",\n" +
                "memory=" + memory + ",\n" +
                "comms=" + comms + ",\n" +
                "sensors=" + Arrays.toString(sensors);
    }

    SmartDevice(String brand, String model, Launch launch, Body body, Memory memory,
                Map<String, String> comms, String[] sensors){
        this.brand = brand;
        this.model = model;
        this.launch = launch;
        this.body = body;
        this.memory = memory;
        this.comms = comms;
        this.sensors = sensors;


    }

    public class SmartPhone extends SmartDevice{
        private Network network;
        private Display display;
        private String os;
        private String cpu;
        private String gpu;
        private Battery battery;
        private MainCamera mainCamera;
        private SelfieCamera selfieCamera;
        private String[] colors;

        SmartPhone(){}

        SmartPhone(String brand, String model, Network network, Launch launch, Body body, Display display, String os, Memory memory, String cpu,
                   String gpu, Battery battery, Map<String, String> comms, String[] sensors, MainCamera mainCamera, SelfieCamera selfieCamera, String[] colors){
            super(brand, model, launch, body, memory, comms, sensors);
            this.network = network;
            this.display = display;
            this.os = os;
            this.cpu = cpu;
            this.gpu = gpu;
            this.battery = battery;
            this.mainCamera = mainCamera;
            this.selfieCamera = selfieCamera;
            this.colors = colors;
        }

        @Override
        public String toString() {
            return "SmartPhone:\n" + "\n" +
                    super.toString() + ",\n" +
                    "network=" + network + ",\n" +
                    "display=" + display + ",\n" +
                    "os='" + os + '\'' + ",\n" +
                    "cpu='" + cpu + '\'' + ",\n" +
                    "gpu='" + gpu + '\'' + ",\n" +
                    "battery=" + battery + ",\n" +
                    "mainCamera=" + mainCamera + ",\n" +
                    "selfieCamera=" + selfieCamera + ",\n" +
                    "colors=" + Arrays.toString(colors);
        }
    }

    class SmartWatch extends SmartDevice{
        private Network network;
        private Display display;
        private String os;
        private String cpu;
        private WatchCase watchCase;
        private WatchStrap watchStrap;
        private String[] wristSizes;
        private boolean supportsSpeaker;
        private boolean supportsMicrophone;
        private Battery battery;

        SmartWatch(){}

        SmartWatch(String brand, String model, Launch launch, Body body, Display display, String os, Memory memory, String cpu,
                   Battery battery, Map<String, String> comms, String[] sensors, WatchCase watchCase, WatchStrap watchStrap, String[] wristSizes,
                   boolean supportsSpeaker, boolean supportsMicrophone){
            super(brand, model, launch, body, memory, comms, sensors);
            this.display = display;
            this.os = os;
            this.cpu = cpu;
            this.watchCase = watchCase;
            this.watchStrap = watchStrap;
            this.wristSizes = wristSizes;
            this.supportsSpeaker = supportsSpeaker;
            this.supportsMicrophone = supportsMicrophone;
            this.battery = battery;
        }

        SmartWatch(String brand, String model, Launch launch, Network network, Body body, Display display, String os, Memory memory, String cpu,
                   Battery battery, Map<String, String> comms, String[] sensors, WatchCase watchCase, WatchStrap watchStrap, String[] wristSizes,
                   boolean supportsSpeaker, boolean supportsMicrophone){
            super(brand, model, launch, body, memory, comms, sensors);
            this.network = network;
            this.display = display;
            this.os = os;
            this.cpu = cpu;
            this.watchCase = watchCase;
            this.watchStrap = watchStrap;
            this.wristSizes = wristSizes;
            this.supportsSpeaker = supportsSpeaker;
            this.supportsMicrophone = supportsMicrophone;
            this.battery = battery;
        }

        @Override
        public String toString() {
            return "SmartWatch:\n" + "\n" +
                    super.toString() + ",\n" +
                    "network=" + network + ",\n" +
                    "display=" + display + ",\n" +
                    "os='" + os + '\'' + ",\n" +
                    "cpu='" + cpu + '\'' + ",\n" +
                    "watchCase=" + watchCase + ",\n" +
                    "watchStrap=" + watchStrap + ",\n" +
                    "wristSizes=" + Arrays.toString(wristSizes) + ",\n" +
                    "supportsSpeaker=" + supportsSpeaker + ",\n" +
                    "supportsMicrophone=" + supportsMicrophone + ",\n" +
                    "battery=" + battery;
        }
    }
}

package com.example;

import device_components.*;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.Month;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class Main {
    static SmartDevice smartDevice = new SmartDevice();

    public static void main(String[] args) {
        SmartDevice.SmartPhone smartPhone1 = instantiateSmartPhone1();
        System.out.println("");
        System.out.println(smartPhone1.toString());

        SmartDevice.SmartWatch smartWatch1 = instantiateSmartWatch1();
        System.out.println("");
        System.out.println("");
        System.out.println(smartWatch1.toString());
    }

    public static SmartDevice.SmartPhone instantiateSmartPhone1() {
        // Instantiating Xiami Mi 11 Lite

        String brand = "Xiaomi";
        String model = "Mi 11 Lite";
        Network network = new Network("GSM/ HSPA / LTE", "Hybrid Dual SIM (Nano-SIM, dual stand-by)");

        Launch launch = new Launch(LocalDate.of(2021, Month.MARCH ,29),
                true, LocalDate.of(2021, Month.APRIL, 16));

        // Body
        float[] dimensions = {160.5f, 75.7f, 6.8f};
        Body body = new Body(dimensions, (short)157);

        // Display
        short[] resolution = {1080, 2400};
        Display display = new Display("AMOLED", 6.55f, resolution, (short)402, "Corning Gorilla Glass 5");
        String os = "Android 11, MIUI 12";

        // Memory
        ArrayList<HashMap<String, Short>> storageRam = new ArrayList<HashMap<String, Short>>();
        storageRam.add(new HashMap<String, Short>(){{
            put("Storage", (short)64);
            put("RAM", (short)4);
        }});
        storageRam.add(new HashMap<String, Short>(){{
            put("Storage", (short)64);
            put("RAM", (short)6);
        }});
        storageRam.add(new HashMap<String, Short>(){{
            put("Storage", (short)128);
            put("RAM", (short)6);
        }});
        storageRam.add(new HashMap<String, Short>(){{
            put("Storage", (short)128);
            put("RAM", (short)8);
        }});
        Memory memory = new Memory(storageRam, "microSDXC (uses shared SIM slot)");

        // CPU / GPU
        String cpu = "Qualcomm SM7150 Snapdragon 732G";
        String gpu = "Adreno 618";

        Battery battery = new Battery("Li-Po",(short)4250, false,  (short)33, false);

        // Camera
        Camera[] mainCameras = {new Camera(
                (short)64, 1.8f, "26mm (wide)", "1/1.97"
        ), new Camera(
                (short)8, 2.2f, "119˚ (ultrawide)", "1/4.0"
        ), new Camera((short)5, 2.4f, "(macro)")};

        String[] mainCameraFeatures = {"Dual-LED dual-tone flash", "HDR", "panorama"};
        String[] mainCameraVideoFeatures = {"4K@30fps", "1080p@30/60/120fps", "gyro-EIS"};
        MainCamera mainCamera = new MainCamera((short)3, mainCameras,
                mainCameraFeatures, mainCameraVideoFeatures);
        Camera[] selfieCameras = {new Camera(
                (short) 16, 2.5f, "(wide)", "1/3.06"
        )};
        String[] selfieCameraFeatures = {"HDR", "panorama"};
        String[] selfieCameraVideoFeatures = {"1080p@30fps", "720p@120fps"};
        SelfieCamera selfieCamera = new SelfieCamera((short)1, selfieCameras,
                selfieCameraFeatures, selfieCameraVideoFeatures);

        // Comms
        Map<String, String> comms = new HashMap<>();
        comms.put("WLAN", "Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot");
        comms.put("Bluetooth", "5.1, A2DP, LE");
        comms.put("GPS", "A-GPS, GLONASS, BDS, GALILEO");
        comms.put("NFC", "Yes");
        comms.put("Infrared port", "Yes");
        comms.put("Infrared port", "Yes");
        comms.put("USB", "USB Type-C 2.0, USB On-The-Go");
        String[] sensors = {"Fingerprint (side-mounted)", "accelerometer", "gyro", "compass", "\tVirtual proximity sensing"};
        String[] colors = {"Boba Black (Vinyl Black)", "Peach Pink (Tuscany Coral)", "Bubblegum Blue (Jazz Blue)"};

        return smartDevice.new SmartPhone(brand, model, network, launch, body, display,
                os, memory, cpu, gpu, battery, comms, sensors, mainCamera, selfieCamera, colors);
    }

    public static SmartDevice.SmartWatch instantiateSmartWatch1(){
        // Initializing Huawei Watch GT 3

        String brand = "Huawei";
        String model = "Watch GT 3";
        Launch launch = new Launch(LocalDate.of(2021, Month.OCTOBER, 21), true, LocalDate.of(2021, Month.NOVEMBER, 11));

        // Body
        float[] dimensions = {45.9f, 45.9f, 11};
        HashMap<String, Float> weights = new HashMap<String, Float>();
        weights.put("42mm", 35f);
        weights.put("46mm", 42.6f);
        Body body = new Body(dimensions, weights);

        // Display
        float[] displaySizes = {1.32f, 1.43f};
        short[] displayResolution = {466, 466};
        Display display = new Display("AMOLED", displaySizes, displayResolution, (short)326, "None");

        String os = "HarmonyOS 2.0";

        // Memory
        ArrayList<HashMap<String, Short>> storageRam = new ArrayList<HashMap<String, Short>>();
        storageRam.add(new HashMap<String, Short>(){{
            put("Storage", (short)4);
            put("RAM", (short)32);
        }});
        Memory memory = new Memory(storageRam);

        String cpu = "Unkown";
        Battery battery = new Battery("Li-Po", (short)455, false, true);

        // Comms
        Map<String, String> comms = new HashMap<String, String>();
        comms.put("Bluetooth", "5.1, LE, EDR");
        comms.put("GPS", "Yes, with dual-band A-GPS, GLONASS, BDS, GALILEO, QZSS");
        comms.put("GPS", "Yes, with dual-band A-GPS, GLONASS, BDS, GALILEO, QZSS");

        // Sensors
        String[] sensors = {"Accelerometer", "gyro", " heart rate", "barometer", "compass",
                "SpO2", "thermometer (body temperature)"};

        String[] caseColors = {"Black", "Steel"};

        // Materials
        Map<String, String> materials = new HashMap<>();
        materials.put("Front case", "Stainless steel");
        materials.put("Rear case", "Plastic");

        // Case
        short[] sizes = {42, 46};
        WatchCase watchCase = new WatchCase(caseColors, materials, sizes);

        // Straps
        String[] strapColors = {"Black", "Brown", "Steel", "White", "Gold"};
        String[] strapMaterials = {"Fluoroelastomer", "leather", "Stainless steel"};
        WatchStrap watchStrap = new WatchStrap(strapColors, strapMaterials);

        // Wrist
        String[] wristSizes = {"130-190", "140-210 mm"};

        boolean supportsSpeaker = true;
        boolean supportsMicrophone = true;

        return smartDevice.new SmartWatch(brand, model, launch, body, display, os, memory, cpu,
                battery, comms, sensors, watchCase, watchStrap, wristSizes,
                supportsSpeaker, supportsMicrophone);
    }
}

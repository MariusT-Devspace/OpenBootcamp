package device_components;

import java.util.ArrayList;
import java.util.HashMap;

public class Memory {
    private ArrayList<HashMap<String, Short>> storageRam;
    private String sdCard = "";

    public Memory(ArrayList<HashMap<String, Short>> storage_ram) {
        this.storageRam = storage_ram;

    }

    public Memory(ArrayList<HashMap<String, Short>> storage_ram, String sdCard) {
        this.storageRam = storage_ram;
        this.sdCard = sdCard;
    }

    @Override
    public String toString() {
        return "Memory{" +
                "storageRam=" + storageRam +
                ", sdCard='" + sdCard + '\'' +
                '}';
    }
}

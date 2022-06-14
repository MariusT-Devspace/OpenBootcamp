package device_components;

public class Battery {
    private String type;
    private boolean removable;
    private short capacity;
    private short chargingW = 0;
    private boolean wirelessCharging;

    public Battery(String type, short capacity, boolean removable, boolean wirelessCharging){
        this.type = type;
        this.capacity = capacity;
        this.removable = removable;
        this.wirelessCharging = wirelessCharging;
    }

    public Battery(String type, short capacity, boolean removable,  short chargingW, boolean wirelessCharging){
        this.type = type;
        this.capacity = capacity;
        this.removable = removable;
        this.chargingW = chargingW;
        this.wirelessCharging = wirelessCharging;
    }

    @Override
    public String toString() {
        return "Battery{" +
                "type='" + type + '\'' +
                ", removable=" + removable +
                ", capacity=" + capacity +
                ", chargingW=" + chargingW +
                ", wirelessCharging=" + wirelessCharging +
                '}';
    }
}

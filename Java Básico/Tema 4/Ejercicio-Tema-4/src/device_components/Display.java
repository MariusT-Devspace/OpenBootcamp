package device_components;

import java.util.Arrays;

public class Display {
    private String displayType;
    private float displaySize;
    private float[] displaySizes;
    private short[] displayResolution = new short[2];
    private short ppi;
    private String displayProtection;

    public Display(String displayType, float displaySize, short[] displayResolution, short ppi, String displayProtection) {
        this.displayType = displayType;
        this.displaySize = displaySize;
        this.displayResolution = displayResolution;
        this.displayProtection = displayProtection;
    }

    public Display(String displayType, float[] displaySizes, short[] displayResolution, short ppi, String displayProtection) {
        this.displayType = displayType;
        this.displaySizes = displaySizes;
        this.displayResolution = displayResolution;
        this.ppi = ppi;
        this.displayProtection = displayProtection;
    }

    @Override
    public String toString() {
        return "Display{" +
                "displayType='" + displayType + '\'' +
                ", displaySize=" + displaySize +
                ", displayResolution=" + Arrays.toString(displayResolution) +
                ", ppi=" + ppi +
                ", displayProtection='" + displayProtection + '\'' +
                '}';
    }
}

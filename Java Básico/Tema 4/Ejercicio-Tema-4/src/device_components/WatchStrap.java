package device_components;

import java.util.Arrays;

public class WatchStrap {
    private String[] colors;
    private String[] materials;

    public WatchStrap(String[] colors, String[] materials) {
        this.colors = colors;
        this.materials = materials;
    }

    @Override
    public String toString() {
        return "WatchStrap{" +
                "colors=" + Arrays.toString(colors) +
                ", materials='" + materials + '\'' +
                '}';
    }
}

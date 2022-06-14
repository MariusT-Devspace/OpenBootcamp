package device_components;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class WatchCase {
    private String[] colors;
    private Map<String, String> materials;
    private short[] sizes;

    public WatchCase(String[] colors, Map<String, String> materials, short[] sizes) {
        this.colors = colors;
        this.materials = materials;
        this.sizes = sizes;
    }

    @Override
    public String toString() {
        return "WatchCase{" +
                "colors=" + Arrays.toString(colors) +
                ", materials='" + materials + '\'' +
                ", sizes=" + sizes +
                '}';
    }
}

package device_components;

import java.util.Arrays;
import java.util.HashMap;

public class Body {
    private float[] dimensions;
    private float weight;
    private HashMap<String, Float> weights;

    public Body(float[] dimensions, float weight) {
        this.dimensions = dimensions;
        this.weight = weight;
    }

    public Body(float[] dimensions, HashMap<String, Float> weights) {
        this.dimensions = dimensions;
        this.weights = weights;
    }

    @Override
    public String toString() {
        return "Body{" +
                "dimensions=" + Arrays.toString(dimensions) +
                ", weight=" + weight +
                ", weights=" + weights +
                '}';
    }
}

package device_components;

public class Network {
    private String technology;
    private String sim;

    public Network(String technology, String sim) {
        this.technology = technology;
        this.sim = sim;
    }

    @Override
    public String toString() {
        return "Network{" +
                "technology='" + technology + '\'' +
                ", sim='" + sim + '\'' +
                '}';
    }
}

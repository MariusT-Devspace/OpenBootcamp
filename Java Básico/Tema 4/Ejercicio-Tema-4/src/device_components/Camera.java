package device_components;

public class Camera {
    private short mp;
    private float aperture;
    private String focalLength;
    private String sensorSize;

    public Camera(short mp, float aperture, String focalLength){
        this.mp = mp;
        this.aperture = aperture;
        this.focalLength = focalLength;
    }
    public Camera(short mp, float aperture, String focalLength, String sensorSize){
        this.mp = mp;
        this.aperture = aperture;
        this.focalLength = focalLength;
        this.sensorSize = sensorSize;
    }

    @Override
    public String toString() {
        return "Camera{" +
                "mp=" + mp +
                ", aperture=" + aperture +
                ", focalLength='" + focalLength + '\'' +
                ", sensorSize='" + sensorSize + '\'' +
                '}';
    }
}

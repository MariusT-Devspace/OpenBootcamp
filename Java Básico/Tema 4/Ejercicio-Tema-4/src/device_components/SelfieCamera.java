package device_components;

import java.util.ArrayList;
import java.util.Arrays;

public class SelfieCamera {
    private short numCameras;
    private Camera[] cameras = new Camera[numCameras];
    private String[] features;
    private String[] videoFeatures;

    public SelfieCamera(short numCameras, Camera[] cameras, String[] features, String[] videoFeatures) {
        this.numCameras = numCameras;
        this.cameras = cameras;
        this.features = features;
        this.videoFeatures = videoFeatures;
    }

    @Override
    public String toString() {
        return "SelfieCamera{" +
                "numCameras=" + numCameras +
                ", cameras=" + Arrays.toString(cameras) +
                ", features=" + Arrays.toString(features) +
                ", videoFeatures=" + Arrays.toString(videoFeatures) +
                '}';
    }
}

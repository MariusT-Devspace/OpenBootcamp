package device_components;

import java.time.LocalDate;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

public class Launch {
    private LocalDate announced;
    private boolean available;
    private LocalDate released;

    public Launch(LocalDate announced, boolean available, LocalDate released){
        this.announced = announced;
        this.available = available;
        this.released = released;
    }

    @Override
    public String toString() {
        return "Launch{" +
                "announced=" + announced +
                ", available=" + available +
                ", released=" + released +
                '}';
    }
}

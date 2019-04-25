package pizzeria;

/**
 * Created by While on 05-Jan-18.
 */
public class CustomerInfo {
    private String methodOfPPayment;
    private String address;
    private String note;

    public CustomerInfo(String methodOfPPayment, String address, String note) {
        this.methodOfPPayment = methodOfPPayment;
        this.address = address;
        this.note = note;
    }

    @Override
    public String toString() {
        return "Nacin placanja: " + methodOfPPayment + "~Adresa: " + address + "~Napomena: " + note + "~";
    }
}
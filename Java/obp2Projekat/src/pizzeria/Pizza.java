package pizzeria;

import java.util.ArrayList;

/**
 * Created by While on 05-Jan-18.
 */
public class Pizza {
    private String pizzaType;
    private String pizzaSize;
    private ArrayList<String> pizzaAccessories;

    public Pizza(String pizzaSize, String pizzaType, ArrayList<String> pizzaAccessories) {
        this.pizzaSize = pizzaSize;
        this.pizzaType = pizzaType;
        this.pizzaAccessories = pizzaAccessories;
    }

    @Override
    public String toString() {
        String pizza = "Pica: " + pizzaType + "~Velicina: " + pizzaSize + "~Dodaci: ";
        for (String string : pizzaAccessories) {
            pizza += string + " ";
        }
        pizza += "~";
        return pizza;
    }
}

package graphics;

import client.Client;
import javafx.geometry.*;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import message_box.AlertBox;
import message_box.ConfirmBox;
import pizzeria.CustomerInfo;
import pizzeria.Pizza;

import java.util.ArrayList;

public class ClientWindow {
    private static Pizza pizza;
    private static CustomerInfo customerInfo;
    private static Client client = new Client();

    public static void createFirstWindow(Stage window) {
        window.setTitle("Narudzbina");

        window.setOnCloseRequest(event -> {
            event.consume();
            closeProgram(window);
        });

        Label pizzaSize = new Label("Velicina pice: ");

        ToggleGroup group = new ToggleGroup();

        RadioButton radioButton1 = new RadioButton("25 cm");
        RadioButton radioButton2 = new RadioButton("32 cm");
        RadioButton radioButton3 = new RadioButton("50 cm");
        radioButton1.setSelected(true);

        radioButton1.setUserData("25 cm");
        radioButton2.setUserData("32 cm");
        radioButton3.setUserData("50 cm");

        radioButton1.setToggleGroup(group);
        radioButton2.setToggleGroup(group);
        radioButton3.setToggleGroup(group);

        HBox hBox = new HBox(10);
        hBox.setPadding(new Insets(20,20,20,20));
        hBox.setAlignment(Pos.TOP_CENTER);
        hBox.getChildren().addAll(radioButton1,radioButton2,radioButton3);

        Label pizzaType = new Label("Vrsta pice: ");
        ChoiceBox<String> choiceBox = new ChoiceBox<>();
        choiceBox.getItems().addAll("Margarita", "Funghi", "Quatro Stagione", "Vegeteriana", "Jimmy Specijal");
        choiceBox.setValue("Margarita");

        Label pizzaAccessories = new Label("Dodaci:");
        CheckBox checkBox1 = new CheckBox("Kecap");
        CheckBox checkBox2 = new CheckBox("Majonez");
        CheckBox checkBox3 = new CheckBox("Origano");
        CheckBox checkBox4 = new CheckBox("Pecurke");
        CheckBox[] checkBoxes = {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4
        };

        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10,10,10,10));
        grid.setVgap(8);
        grid.setHgap(10);

        GridPane.setConstraints(checkBox1, 0, 0);
        GridPane.setConstraints(checkBox2, 4, 0);
        GridPane.setConstraints(checkBox3, 0,1);
        GridPane.setConstraints(checkBox4, 4,1);

        grid.getChildren().addAll(checkBox1,checkBox2,checkBox3,checkBox4);
        grid.setAlignment(Pos.TOP_CENTER);

        Button button = new Button("Dalje");
        button.setOnAction(event -> {
            pizza = createPizza(group, choiceBox, checkBoxes);
            createSecondWindow(window);
        });

        VBox vBox = new VBox(25);
        vBox.setPadding(new Insets(20,20,20,20));
        vBox.setAlignment(Pos.TOP_CENTER);
        vBox.getChildren().addAll(pizzaSize, hBox, pizzaType, choiceBox, pizzaAccessories, grid, button);

        Scene scene1 = new Scene(vBox, 300, 420);
        window.setScene(scene1);

        window.setX(500);
        window.setY(300);

        window.show();
    }

    private static Pizza createPizza(ToggleGroup group, ChoiceBox<String> choiceBox, CheckBox[] checkBoxes) {
        String pizzaSize = group.getSelectedToggle().getUserData().toString();
        String pizzaType = choiceBox.getValue();
        ArrayList<String> pizzaAccessories = new ArrayList<>();
        for (CheckBox box : checkBoxes) {
            if(box.isSelected()) {
                pizzaAccessories.add(box.getText());
            }
        }
        return new Pizza(pizzaSize, pizzaType, pizzaAccessories);
    }

    private static void closeProgram(Stage window) {
        boolean answer = ConfirmBox.display("Gasenje", "Da li ste sigurni da zelite da ugasite aplikaciju?");
        if (answer)
            window.close();
    }

    private static void createSecondWindow(Stage window) {

        Label methodOfPPayment = new Label("Nacin placanja: ");

        ToggleGroup group = new ToggleGroup();

        RadioButton radioButton1 = new RadioButton("Pouzecem");
        RadioButton radioButton2 = new RadioButton("Kartica");
        RadioButton radioButton3 = new RadioButton("BitCoin");
        radioButton1.setSelected(true);

        radioButton1.setUserData("Pouzecem");
        radioButton2.setUserData("Kartica");
        radioButton3.setUserData("BitCoin");

        radioButton1.setToggleGroup(group);
        radioButton2.setToggleGroup(group);
        radioButton3.setToggleGroup(group);

        HBox hBox1 = new HBox(10);
        hBox1.setPadding(new Insets(20,20,20,20));
        hBox1.setAlignment(Pos.TOP_CENTER);
        hBox1.getChildren().addAll(radioButton1,radioButton2,radioButton3);

        Label addressLabel = new Label("Adresa: ");
        TextField addressTextField = new TextField();
        addressTextField.setMinWidth(250);

        Label noteLabel = new Label("Napomena: ");
        TextArea noteTextArea = new TextArea();
        noteTextArea.setMinSize(250, 60);

        Button back = new Button("Nazad");
        back.setOnAction(event -> createFirstWindow(window));

        Button order = new Button("Poruci");
        order.setOnAction(event -> {
            if(confirmOrder()) {
                if(addressTextField.getText().equals("")){
                    AlertBox.displayError("Greska", "Morate uneti adresu");
                } else {
                    customerInfo = createInfo(group, addressTextField, noteTextArea);
                    client.setParameters(pizza, customerInfo);
                    window.close();
                }
            }
        });

        HBox hBox2 = new HBox(25);
        hBox2.setPadding(new Insets(20,20,20,20));
        hBox2.setAlignment(Pos.TOP_CENTER);
        hBox2.getChildren().addAll(back, order);

        VBox vBox = new VBox(20);
        vBox.setPadding(new Insets(20,20,20,20));
        vBox.setAlignment(Pos.TOP_CENTER);
        vBox.getChildren().addAll(methodOfPPayment, hBox1, addressLabel, addressTextField, noteLabel, noteTextArea, hBox2);

        Scene scene2 = new Scene(vBox, 300, 420);
        window.setScene(scene2);
    }

    private static CustomerInfo createInfo(ToggleGroup group, TextField textField, TextArea textArea) {
        String methodOfPPayment = group.getSelectedToggle().getUserData().toString();
        String address = textField.getText();
        String note = textArea.getText();
        return new CustomerInfo(methodOfPPayment, address, note);
    }

    private static boolean confirmOrder() {
        return ConfirmBox.display("Naruci", "Da li ste sigurni u vas izbor?");
    }
}

package server;

import javafx.application.Platform;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;

import java.io.*;
import java.net.Socket;
import java.util.Random;

/**
 * Created by While on 05-Jan-18.
 */
public class ServerSocketThread extends Thread {
    private Socket socket;
    private Label deliveredPizzasLabel;
    private VBox vBox;
    private BufferedReader in;
    private PrintWriter out;
    private static int counter = 0;
    private int numberOfOrder;
    private Label ordersLabel;
    private int timeForDeliver;

    public ServerSocketThread(Socket socket, Label deliveredPizzasLabel, VBox vBox) {
        this.socket = socket;
        this.deliveredPizzasLabel = deliveredPizzasLabel;
        this.ordersLabel = new Label();
        this.vBox = vBox;
        this.numberOfOrder = ++counter;
        setStreams();
        timeForDeliver = createRandomNumber();
    }

    private void setStreams() {
        try {
            in = new BufferedReader(
                    new InputStreamReader(
                            socket.getInputStream()));
            out = new PrintWriter(
                    new BufferedWriter(
                            new OutputStreamWriter(
                                    socket.getOutputStream())), true);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private int createRandomNumber() {
        Random random = new Random();
        return random.nextInt(40) + 10;
    }

    @Override
    public void run() {
        try {
            String message = processMessage();
            out.println(timeForDeliver);
            closeStreams();
            setTextInLabelForOrders(message);
            while (timeForDeliver > -1) {
                try {
                    if(timeForDeliver == 0) {
                        setTextInLabelForDeliveredPizzas();
                        changeDeliveryTimeInLabelForOrders("Dostavljeno");
                        changeColorOfStringInLabelForOrders();
                    } else {
                        changeDeliveryTimeInLabelForOrders("Preostalo vreme do isporuke: " + (timeForDeliver - 1) + " min");
                    }
                    Thread.sleep(1000);
                    timeForDeliver--;
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
        } catch (IOException e) {
            System.out.println("Otkazana porudzbina");
        }
    }

    private String processMessage() throws IOException {
        String originalMessage = in.readLine();
        String processedMessage = "";
        String[] parts = originalMessage.split("~");
        for (String string : parts) {
            processedMessage += string + "\n";
        }
        return processedMessage;
    }

    private void closeStreams() {
        try {
            in.close();
            out.close();
            socket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void setTextInLabelForOrders(String message) {
        //mora da se promeni stanje labele preko Platform.runLater inace ce baciti exception(Not on FX application thread)
        Platform.runLater(() -> {
            ordersLabel.setText("Porudzbina broj " + numberOfOrder + "\n" + message + "Preostalo vreme do isporuke: " + timeForDeliver + " min");
            vBox.getChildren().addAll(ordersLabel);
        });
    }


    private void setTextInLabelForDeliveredPizzas() {
        Platform.runLater(() -> {
            deliveredPizzasLabel.setText(deliveredPizzasLabel.getText() + "Porudzbina broj " + numberOfOrder + " uspesno dostavljena\n");
        });
    }

    private void changeDeliveryTimeInLabelForOrders(String replaceWith) {
        Platform.runLater(() -> {
            String text = ordersLabel.getText();
            String replace = text.replaceAll("Preostalo vreme do isporuke: " + timeForDeliver + " min", replaceWith);
            ordersLabel.setText(replace);
        });
    }

    private void changeColorOfStringInLabelForOrders() {
        Platform.runLater(() -> {
            ordersLabel.setStyle("-fx-text-fill: green");
        });
    }
}

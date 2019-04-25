package client;

import message_box.AlertBox;
import pizzeria.CustomerInfo;
import pizzeria.Pizza;

import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;

/**
 * Created by While on 05-Jan-18.
 */
public class Client {
    private Pizza pizza;
    private CustomerInfo customerInfo;
    private BufferedReader in;
    private PrintWriter out;
    private Socket socket;

    public Client() {
        try {
            socket = new Socket("localhost", 9000);
            setStreams();
        } catch (UnknownHostException e) {
            AlertBox.displayError("Greska", "Greska pri konekciji sa serverom");
            System.exit(1);
        } catch (IOException e) {
            AlertBox.displayError("Greska", "Greska pri konekciji sa serverom");
            System.exit(1);
        }
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
            AlertBox.displayError("Greska", "Greska pri konekciji sa serverom");
            System.exit(1);
        }
    }

    public void setParameters(Pizza pizza, CustomerInfo customerInfo) {
        this.pizza = pizza;
        this.customerInfo = customerInfo;
        sendDataToServer();
        receiveDataFromServer();
    }

    private void sendDataToServer() {
        out.println(pizza + "" + customerInfo + "\n");
    }

    private void receiveDataFromServer() {
        try {
            String timeForDeliver = in.readLine();
            AlertBox.displayTime("Poruceno", "Uspesno ste porucili picu", timeForDeliver);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

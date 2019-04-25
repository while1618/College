package server;

import javafx.scene.control.Label;
import javafx.scene.layout.VBox;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;

/**
 * Created by While on 05-Jan-18.
 */
public class Server extends Thread{
    private Label label;
    private VBox vBox;
    private static boolean working;
    private static ServerSocket serverSocket;

    public Server(Label label, VBox vBox) {
        working = true;
        this.label = label;
        this.vBox = vBox;
    }

    public static void turnOffServer() {
        working = false;
        try {
            serverSocket.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void run() {
        try {
            serverSocket = new ServerSocket(9000);
            System.out.println("Server radi...");
            while (working) {
                try {
                    Socket socket = serverSocket.accept();
                    new ServerSocketThread(socket, label, vBox).start();
                } catch (SocketException e) {
                    System.out.println("Server ugasen");
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

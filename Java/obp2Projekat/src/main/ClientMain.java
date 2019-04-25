package main;

import graphics.ClientWindow;
import javafx.application.Application;
import javafx.stage.Stage;
/**
 * Created by While on 06-Jan-18.
 */
public class ClientMain extends Application{
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        ClientWindow.createFirstWindow(primaryStage);
    }
}

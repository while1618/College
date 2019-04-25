package main;

import graphics.ServerWindow;
import javafx.application.Application;
import javafx.stage.Stage;
/**
 * Created by While on 05-Jan-18.
 */
public class ServerMain extends Application{
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception {
        ServerWindow.createServerWindow(primaryStage);
    }
}

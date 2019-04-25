package graphics;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import message_box.ConfirmBox;
import server.Server;

/**
 * Created by While on 05-Jan-18.
 */
public class ServerWindow {
    public static void createServerWindow(Stage window) {
        window.setTitle("Server");

        window.setOnCloseRequest(event -> {
            event.consume();
            closeProgram(window);
        });

        Label text1 = new Label("Dostavljene: ");

        Label label1 = new Label("");
        label1.setMinSize(240, 640);
        label1.setStyle("-fx-border-color: black");
        label1.setAlignment(Pos.TOP_LEFT);

        VBox vBox1 = new VBox(10);
        vBox1.setPadding(new Insets(10,10,10,10));
        vBox1.getChildren().addAll(text1, label1);

        Label text2 = new Label("Cekaju na dostavu: ");

        VBox vBox2 = new VBox(10);
        vBox2.setPadding(new Insets(10,10,10,10));
        vBox2.setMinSize(240, 640);
        vBox2.setStyle("-fx-border-color: black");

        VBox vBox3 = new VBox(10);
        vBox3.setPadding(new Insets(10,10,10,10));
        vBox3.getChildren().addAll(text2, vBox2);

        HBox hBox = new HBox(10);
        hBox.setPadding(new Insets(10,10,10,10));
        hBox.getChildren().addAll(vBox1, vBox3);

        Scene scene = new Scene(hBox, 550, 700);
        window.setScene(scene);

        window.setX(1000);
        window.setY(150);

        window.show();

        new Server(label1, vBox2).start();
    }

    private static void closeProgram(Stage window) {
        boolean answer = ConfirmBox.display("Gasenje", "Da li ste sigurni da zelite da ugasite server?");
        if (answer) {
            window.close();
            Server.turnOffServer();
        }
    }
}

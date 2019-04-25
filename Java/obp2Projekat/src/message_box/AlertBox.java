package message_box;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.VBox;
import javafx.stage.Modality;
import javafx.stage.Stage;

/**
 * Created by While on 05-Jan-18.
 */
public class AlertBox {
    private static VBox vBox;
    private static Stage window;

    public static void displayError(String title, String message) {
        graphic(title);

        Label label = new Label();
        label.setText(message);

        Button button = new Button("Ok");
        button.setOnAction(event -> window.close());

        vBox.getChildren().addAll(label, button);

        window.showAndWait();
    }

    public static void displayTime(String title, String message, String time) {
        graphic(title);

        Label label1 = new Label();
        label1.setText(message);

        Label label2 = new Label();
        label2.setText("Pica ce biti dostavljena za: " + time + " minuta");

        Button button = new Button("Ok");
        button.setOnAction(event -> window.close());

        vBox.getChildren().addAll(label1, label2, button);

        window.showAndWait();
    }

    private static void graphic(String title) {
        window = new Stage();

        window.initModality(Modality.APPLICATION_MODAL);
        window.setTitle(title);
        window.setMinWidth(250);

        vBox = new VBox(10);
        vBox.setPadding(new Insets(10,10,10,10));
        vBox.setAlignment(Pos.CENTER);

        Scene scene = new Scene(vBox);
        window.setScene(scene);
    }
}

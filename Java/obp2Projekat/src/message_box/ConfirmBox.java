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
public class ConfirmBox {
    private static boolean answer;

    public static boolean display(String title, String message) {
        Stage window = new Stage();

        window.initModality(Modality.APPLICATION_MODAL);
        window.setTitle(title);
        window.setMinWidth(250);

        Label label = new Label();
        label.setText(message);

        Button yes = new Button("Da");
        yes.setOnAction(event -> {
            answer = true;
            window.close();
        });

        Button no = new Button("Ne");
        no.setOnAction(event -> {
            answer = false;
            window.close();
        });

        VBox vBox = new VBox(10);
        vBox.setPadding(new Insets(20,20,20,20));
        vBox.getChildren().addAll(label, yes, no);
        vBox.setAlignment(Pos.CENTER);

        Scene scene = new Scene(vBox);
        window.setScene(scene);

        window.showAndWait();

        return answer;
    }
}

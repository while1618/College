import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;

public class Graphics {
    public static void createGraphics(Stage window) {
        window.setTitle("The Maze");
        TextField[][] textFieldMatrix = new TextField[9][9];
        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10,10,10,10));
        grid.setHgap(9);
        grid.setVgap(9);
        for(int i = 0; i < textFieldMatrix.length; i++) {
            for (int j = 0; j < textFieldMatrix.length; j++) {
                textFieldMatrix[i][j] = new TextField();
                textFieldMatrix[i][j].setMinSize(20,40);
                textFieldMatrix[i][j].setAlignment(Pos.CENTER);
                if(i == 0 || j == 0 || i == 8 || j == 8) {
                    textFieldMatrix[i][j].setText("#");
                }
                if(i == 1 && j == 1) {
                    textFieldMatrix[i][j].setText("M");
                }
                if(i == 2 && ( j == 2 ||  j == 3 || j == 4 ||  j == 5 ||  j == 6 )) {
                    textFieldMatrix[i][j].setText("#");
                }
                if(i == 4 && ( j == 2 ||  j == 3 || j == 4 ||  j == 5 )) {
                    textFieldMatrix[i][j].setText("#");
                }
                if(i == 6 && ( j == 2 ||  j == 3 || j == 4 ||  j == 5 )) {
                    textFieldMatrix[i][j].setText("#");
                }
                if(j == 7 && (i == 4 || i == 5 || i == 6)) {
                    textFieldMatrix[i][j].setText("#");
                }
                GridPane.setConstraints(textFieldMatrix[i][j], i, j);
                grid.getChildren().addAll(textFieldMatrix[i][j]);
            }
        }
        Button button = new Button("Result");
        button.setOnAction(event -> {
            Maze.findExit(textFieldMatrix);
        });

        VBox vBox = new VBox(10);
        vBox.setAlignment(Pos.CENTER);
        vBox.getChildren().addAll(grid, button);

        Scene scene = new Scene(vBox, 500, 510);
        window.setScene(scene);
        window.show();
    }
}

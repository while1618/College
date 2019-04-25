import javafx.scene.control.TextField;

import java.util.ArrayList;

public class Maze {
    private static ArrayList<String>[] listsOfExits;
    private static TextField[][] maze;
    private static ArrayList<Point> pointsOfExits;

    public static void findExit(TextField[][] maze){
        Maze.maze = maze;
        pointsOfExits = new ArrayList<>();
        listsOfExits = new ArrayList[numberAndPositionsOfExits()];
        for(int i = 0; i < listsOfExits.length; listsOfExits[i++] = new ArrayList<>());
        checkField(1, 1, "", "");
        showResult();
    }

    private static void checkField(int column, int row, String currentPath, String direction){
        if (!maze[column][row].getText().equals("#") && !maze[column][row].isCache()) {
            if(maze[column][row].getText().equals("E")){
                int counter = 0;
                currentPath += direction;
                for (Point point : pointsOfExits) {
                    if(point.getColumn() == column && point.getRow() == row){
                        listsOfExits[counter].add(currentPath);
                    }
                    counter++;
                }
            } else {
                maze[column][row].setCache(true);
                currentPath += direction;
                checkField(column + 1, row, currentPath, "R");
                checkField(column, row + 1, currentPath, "D");
                checkField(column - 1, row, currentPath, "L");
                checkField(column, row - 1, currentPath, "U");
                maze[column][row].setCache(false);
            }
        }
    }

    private static int numberAndPositionsOfExits() {
        int counter = 0;
        for(int i = 0; i < maze.length; i++) {
            for(int j = 0; j < maze.length; j++) {
                if(maze[i][j].getText().equals("E")) {
                    pointsOfExits.add(new Point(i, j));
                    counter++;
                }
            }
        }
        return counter;
    }

    private static void showResult() {
        for(int i = 0; i < listsOfExits.length; i++) {
            System.out.println("Solutions for " + (i + 1) + ". exit:");
            for(String s: listsOfExits[i]){
                System.out.println(s);
            }
            System.out.println();
        }
    }
}
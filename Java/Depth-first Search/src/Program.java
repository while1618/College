public class Program {
    public static void main(String[] args) {
        String[] imenaCvorova = {
                "A",
                "B",
                "C",
                "D",
                "E"
        };
        String[] cvorISused = {
                "A;B",
                "A;C",
                "B;D",
                "C;D",
                "D;E"
        };
        DFS dfs = new DFS(false, imenaCvorova, cvorISused);
        dfs.dfs();
    }
}

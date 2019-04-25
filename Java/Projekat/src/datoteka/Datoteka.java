package datoteka;

import java.io.FileWriter;
import java.io.IOException;

public class Datoteka {
    private static String aktivnosti = "";

    public static void setAktivnosti(String string){
        aktivnosti += string;
    }

    public static void obrisiAktivnosti(){
        aktivnosti = "";
    }

    public static void upisiUDatoteku() throws IOException{
        FileWriter fileWriter = new FileWriter("aktivnosti.log", true);
        fileWriter.write(aktivnosti + "\n\n");
        fileWriter.close();
    }
}

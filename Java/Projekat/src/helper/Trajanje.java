package helper;

import muzika.Albumi;
import muzika.Pesme;
import sql.Sql;

import java.util.ArrayList;

public class Trajanje extends Sql {
    public static int formiranjeVremenaIzStringaUSekunde(String vreme) throws Exception{
        String [] podeljn = vreme.split(":");
        if(podeljn.length != 3) throw new Exception("Neki od podataka nije unet validno");
        for(String segment : podeljn){
            if(segment.trim().equals("")) throw new Exception("Neki od podataka nije unet validno");
        }

        int sekunde = 0;
        sekunde += Integer.parseInt(podeljn[0].trim()) * 60 * 60;
        sekunde += Integer.parseInt(podeljn[1].trim()) * 60;
        sekunde += Integer.parseInt(podeljn[2].trim());

        return sekunde;
    }

    public static String ukupnoTrajanjeAlbuma(int idAlbuma){
        String sql = "SELECT * FROM pesme WHERE idAlbuma = " + idAlbuma;
        ArrayList<Pesme> listaPesama = uzmiPesmeIzBaze(sql);
        int ukupnoTrajanje = 0;
        for(Pesme elementi : listaPesama){
            ukupnoTrajanje += elementi.getTrajanjePesme();
        }
        return Trajanje.formiranjeVremenaIzSekundiUString(ukupnoTrajanje);
    }

    public static String formiranjeVremenaIzSekundiUString(int ukupnoSekundi){
        int sati = ukupnoSekundi / 3600;
        int minuti = (ukupnoSekundi % 3600) / 60;
        int sekunde = ukupnoSekundi % 60;
        return sati + ":" + minuti + ":" + sekunde;
    }

    public static void ispsiTrajanjaSvihPesama(){
        String sql = "SELECT * FROM pesme";
        ArrayList<Pesme> listaPesama = uzmiPesmeIzBaze(sql);
        System.out.println("\nTrajanje pesama:\n");
        for(Pesme pesme : listaPesama){
            System.out.println(pesme.getNazivPesme() + ": " + formiranjeVremenaIzSekundiUString(pesme.getTrajanjePesme()));
        }
    }

    public static void ispisTrajanjaSvihAlbuma(){
        String sql = "SELECT * FROM albumi";
        ArrayList<Albumi> listaAlbuma = uzmiAlbumeIzBaze(sql);
        System.out.println("\nTrajanje albuma:\n");
        for(Albumi albumi : listaAlbuma){
            System.out.println(albumi.getNazivAlbuma() + ": " + ukupnoTrajanjeAlbuma(albumi.getIdAlbuma()));
        }
    }
}

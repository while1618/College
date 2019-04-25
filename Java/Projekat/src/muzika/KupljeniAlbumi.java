package muzika;

import exceptions.AlbumException;
import korisnici.Korisnici;
import meni.KorisnickiMeni;
import sql.Sql;
import unos.Unos;

import java.util.ArrayList;

public class KupljeniAlbumi extends Sql {
    private int idKupljenogAlbuma;
    private Korisnici korisnik;
    private Albumi album;

    public KupljeniAlbumi(int idKupljenogAlbuma, Korisnici korisnik, Albumi album) {
        this.idKupljenogAlbuma = idKupljenogAlbuma;
        this.korisnik = korisnik;
        this.album = album;
    }

    public static ArrayList<Albumi> vratiListuAlbumaIzBiblioteke(int idKorisnika){
        String sql = "SELECT * FROM kupljeniAlbumi WHERE idKorisnika = " + idKorisnika;
        return listaKupljenihAlbuma(sql);
    }

    public static void kupovinaAlbuma(Korisnici korisnik) throws Exception{
        try {
            int idAlbuma = Unos.unesiteIdAlbuma();
            if(idAlbuma < 1 || idAlbuma > Albumi.poslednjIdUBaziAlbumi()) throw new AlbumException(1);
            if(!Korisnici.kupiAlbum(idAlbuma, korisnik.getIdKorisnika())) throw new AlbumException(3);
            System.out.println("\nUspesno ste kupili album\n");
        } catch (AlbumException e) {
            System.err.println(e.getMessage());
            KorisnickiMeni.korisnickiMeni(korisnik);
        }
    }
}

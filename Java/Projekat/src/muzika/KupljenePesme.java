package muzika;

import exceptions.PesmaException;
import korisnici.Korisnici;
import meni.KorisnickiMeni;
import sql.Sql;
import unos.Unos;

import java.util.ArrayList;

public class KupljenePesme extends Sql {
    private int idKupljenogAlbuma;
    private Korisnici korisnik;
    private Pesme pesme;

    public KupljenePesme(int idKupljenogAlbuma, Korisnici korisnik, Pesme pesme) {
        this.idKupljenogAlbuma = idKupljenogAlbuma;
        this.korisnik = korisnik;
        this.pesme = pesme;
    }

    public static ArrayList<Pesme> vratiListuIndividualnihPesamaIzBiblioteke(int idKorisnika){
        String sql = "SELECT * FROM kupljenePesme WHERE idKorisnika = " + idKorisnika;
        return listaKupljenihIndividualnihPesama(sql);
    }

    public static void kupovinaPesme(Korisnici korisnik) throws Exception{
        try{
            int idPesme = Unos.unesiteIdPesme();
            if(idPesme < 1 || idPesme > Pesme.poslednjiIdUBaziPesme()) throw new PesmaException(1);
            if(!Korisnici.kupiPesmu(idPesme, korisnik.getIdKorisnika())) throw new PesmaException(3);
            System.out.println("\nUspesno ste kupili pesmu\n");
        } catch (PesmaException e){
            System.err.println(e.getMessage());
            KorisnickiMeni.korisnickiMeni(korisnik);
        }
    }
}

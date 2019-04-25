package korisnici;

import exceptions.AlbumException;
import exceptions.PesmaException;
import muzika.Albumi;
import muzika.KupljenePesme;
import muzika.KupljeniAlbumi;
import muzika.Pesme;
import sql.Sql;

import java.util.ArrayList;

public class Korisnici extends Sql {
    private int idKorisnika;
    private String korisnickoIme;
    private String lozinka;

    public Korisnici(int idKorisnika, String korisnickoIme, String lozinka) {
        this.idKorisnika = idKorisnika;
        this.korisnickoIme = korisnickoIme;
        this.lozinka = lozinka;
    }

    public int getIdKorisnika(){
        return idKorisnika;
    }

    public static boolean daLiJeDobroKorisnickoImeILozinka(String korisnickoIme, String lozinka){
        String sql = "SELECT ime, lozinka FROM korisnici";
        return proveraUBaziZaImeILozinku(korisnickoIme, lozinka, sql);
    }

    public static void ispisiKupljenihAlbumaIPesama(int idKorisnika){
        ArrayList<Pesme> listaIndividualnihPesama = KupljenePesme.vratiListuIndividualnihPesamaIzBiblioteke(idKorisnika);
        ArrayList<Albumi> listaAlbuma = KupljeniAlbumi.vratiListuAlbumaIzBiblioteke(idKorisnika);
        System.out.println("\nKupljene individualne pesme korisnika:\n");
        for(Pesme pesme : listaIndividualnihPesama){
            System.out.println(pesme);
        }
        System.out.println("\nKupljeni albumi korisnika:\n");
        for(Albumi albumi : listaAlbuma){
            System.out.println(albumi);
        }
    }

    public static void ispsiPesamaIAlbumaZadatogIzvodjaca(int idIzvodjaca){
        ArrayList<Pesme> listaIndividualnihPesama = Pesme.vratiIndividualnePesmeZadatogIzvodjaca(idIzvodjaca);
        ArrayList<Albumi> listaAlbuma = Albumi.vratiAlbumeZadatogIzvodjaca(idIzvodjaca);
        ArrayList<Pesme> listaPesama = Pesme.vratiListuPesamaZadatogIzvodjaca(idIzvodjaca);
        System.out.println("\nIndividualne pesme zadatog izvodjaca:\n");
        for(Pesme pesme : listaIndividualnihPesama){
            System.out.println(pesme);
        }
        System.out.println("\nAlbumi zadatog izvodjaca:\n");
        for(Albumi albumi : listaAlbuma){
            System.out.println(albumi);
            System.out.println("Lista pesama:");
            for(Pesme pesme : listaPesama){
                System.out.println(pesme);
            }
        }
    }

    public static boolean kupiPesmu(int idPesme, int idKorisnika) throws Exception {
        if(Pesme.daLiJePesmaVecKupljena(idPesme, idKorisnika)) throw new PesmaException(2);
        String sql = "INSERT INTO kupljenePesme(idKorisnika, idPesme) VALUES (" + idKorisnika + ", " + idPesme + ")";
        if (promeniPodatekeUBazi(sql)){
            return true;
        } else {
            return false;
        }
    }

    public static boolean kupiAlbum(int idAlbuma, int idKorisnika) throws Exception {
        if(Albumi.daLiJeAlbumVecKupljen(idAlbuma, idKorisnika)) throw new AlbumException(2);
        String sql = "INSERT INTO kupljeniALbumi(idKorisnika, idAlbuma) VALUES (" + idKorisnika + ", " + idAlbuma + ")";
        if (promeniPodatekeUBazi(sql)){
            return true;
        } else {
            return false;
        }
    }

    public static Korisnici vratiKorisnikaZaUnetoKorisnickoIme(String ime){
        String sql = "SELECT * FROM korisnici WHERE ime = '" + ime + "'";
        return uzmiKorisnikaIzBaze(sql);
    }

}

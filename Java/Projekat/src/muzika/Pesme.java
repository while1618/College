package muzika;

import administratori.Administratori;
import datoteka.Datoteka;
import exceptions.AlbumException;
import exceptions.IzvodjacException;
import exceptions.PesmaException;
import helper.Trajanje;
import meni.AdministratorskiMeni;
import sql.Sql;
import unos.Unos;

import java.util.ArrayList;
import java.util.Scanner;

public class Pesme extends Sql {
    private int idPesme;
    private String nazivPesme;
    private Izvodjaci izvodjac;
    private Albumi album;
    private int trajanjePesme;

    public Pesme(int idPesme, String nazivPesme, Izvodjaci izvodjac, Albumi album, int trajanjePesme) {
        this.idPesme = idPesme;
        this.nazivPesme = nazivPesme;
        this.izvodjac = izvodjac;
        this.album = album;
        this.trajanjePesme = trajanjePesme;
    }

    public Pesme(int idPesme, String nazivPesme, Izvodjaci izvodjac, int trajanjePesme) {
        this.idPesme = idPesme;
        this.nazivPesme = nazivPesme;
        this.izvodjac = izvodjac;
        this.trajanjePesme = trajanjePesme;
    }

    public String getNazivPesme(){return nazivPesme;}

    public int getTrajanjePesme() {
        return trajanjePesme;
    }

    public static int poslednjiIdUBaziPesme(){
        String sql = "SELECT idPesme FROM pesme ORDER BY idPesme DESC LIMIT 1";
        return uzmiPoslednjiIdPesme(sql);
    }

    public static Pesme vratiPesmuZaUnetiIdIzTabelePesme(int id){
        String sql = "SELECT * FROM pesme WHERE idPesme = " + id;
        return uzmiPesmuIzBaze(sql);
    }

    public static ArrayList<Pesme> vratiListuPesamaZadatogIzvodjaca(int idIzvodjaca){
        String sql = "SELECT * FROM pesme WHERE idIzvodjaca = " + idIzvodjaca;
        return uzmiPesmeIzBaze(sql);
    }

    public static ArrayList<Pesme> vratiIndividualnePesmeZadatogIzvodjaca(int idIzvodjaca){
        String sql = "SELECT * FROM pesme WHERE idIzvodjaca = " + idIzvodjaca;
        ArrayList<Pesme> listaPesama = uzmiPesmeIzBaze(sql);
        ArrayList<Pesme> listaIndividualnihPesama = new ArrayList<>();
        for(Pesme pesme : listaPesama){
            if(pesme.album == null){
                listaIndividualnihPesama.add(pesme);
            }
        }
        return listaIndividualnihPesama;
    }

    public static boolean daLiJePesmaVecKupljena(int idPesme, int idKorisnika){
        String sql = "SELECT * FROM kupljenePesme WHERE idPesme = " + idPesme + " AND idKorisnika = " + idKorisnika;
        return (kupljenePesme(sql) == null) ? false : true;
    }

    public static boolean ubaciPesmuUBazu(Administratori administrator) throws Exception {
        try {
            String aktivnostiAdmina = "\nUbacivanje pesme u bazu:\n";
            Integer idAlbuma;
            Scanner in = new Scanner(System.in);
            System.out.println("Unesite naziv pesme:");
            String nazivPesme = in.nextLine();
            aktivnostiAdmina += nazivPesme + "\n";
            System.out.println("Unesite id izvodjaca:");
            int idIzvodjaca = in.nextInt();
            aktivnostiAdmina += idIzvodjaca + "\n";
            if(Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
            in.nextLine();
            System.out.println("Unesite id albuma:");
            String idAlbumaString = in.nextLine();
            aktivnostiAdmina += idAlbumaString + "\n";
            if(idAlbumaString.equals("")){
                idAlbuma = null;
            } else{
                idAlbuma = Integer.parseInt(idAlbumaString.trim());
                if(Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(idAlbuma) == null) throw new AlbumException(1);
            }
            System.out.println("Unesite trajanje pesme:");
            System.out.println("Format: hh:mm:ss");
            String vreme = in.nextLine();
            aktivnostiAdmina += vreme + "\n";
            int trajanjePesme = Trajanje.formiranjeVremenaIzStringaUSekunde(vreme);
            String sql = "INSERT INTO pesme (nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES ('" + nazivPesme + "', " + idIzvodjaca + ", " + idAlbuma + ", " + trajanjePesme + ")";
            Datoteka.setAktivnosti(aktivnostiAdmina);
            return (promeniPodatekeUBazi(sql)) ? true : false;
        } catch (Exception e) {
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    public static boolean azurirajPesmu(Administratori administrator) throws Exception{
        String aktivnostAdmina = "\nAzuriranje pesme: \n";
        int flag = 1;
        Integer idAlbuma;
        Integer idIzvodjaca;
        int idPesme = Unos.unesiteIdPesme();
        try{
            if(vratiPesmuZaUnetiIdIzTabelePesme(idPesme) == null) throw new PesmaException(1);
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }

        Scanner in = new Scanner(System.in);
        System.out.println("Unesite naziv pesme:");
        String nazivPesme = in.nextLine();
        if(!nazivPesme.equals("")){
            aktivnostAdmina += nazivPesme + "\n";
            String sql = "UPDATE pesme SET nazivPesme = '" + nazivPesme + "' WHERE idPesme = " + idPesme;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }
        System.out.println("Unesite id izvodjaca:");
        String idIzvodjacaString = in.nextLine();
        if(!idIzvodjacaString.equals("")){
            aktivnostAdmina += idIzvodjacaString + "\n";
            try{
                idIzvodjaca = Integer.parseInt(idIzvodjacaString.trim());
                if(Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
                String sql = "UPDATE pesme SET idIzvodjaca = " + idIzvodjaca + " WHERE idPesme = " + idPesme;
                if(!promeniPodatekeUBazi(sql)){
                    flag = 0;
                }
            } catch (Exception e){
                System.err.println(e.getMessage());
                AdministratorskiMeni.administratorskiMeni(administrator);
            }
        }
        System.out.println("Unesite id albuma:");
        String idAlbumaString = in.nextLine();
        if(!idAlbumaString.equals("")) {
            aktivnostAdmina += idAlbumaString + "\n";
            try {
                idAlbuma = Integer.parseInt(idAlbumaString.trim());
                if(Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(idAlbuma) == null) throw new AlbumException(1);
                String sql = "UPDATE pesme SET idAlbuma = " + idAlbuma + " WHERE idPesme = " + idPesme;
                if (!promeniPodatekeUBazi(sql)) {
                    flag = 0;
                }
            } catch (Exception e) {
                System.err.println(e.getMessage());
                AdministratorskiMeni.administratorskiMeni(administrator);
            }
        }
        System.out.println("Unesite trajanje pesme:");
        System.out.println("Format: hh:mm:ss");
        String vreme = in.nextLine();
        if(!vreme.equals("")){
            aktivnostAdmina += vreme + "\n";
            try {
                int trajanjePesme = Trajanje.formiranjeVremenaIzStringaUSekunde(vreme);
                String sql = "UPDATE pesme SET trajanjePesme = " + trajanjePesme + " WHERE idPesme = " + idPesme;
                if(!promeniPodatekeUBazi(sql)){
                    flag = 0;
                }
            } catch (Exception e) {
                System.err.println(e.getMessage());
                AdministratorskiMeni.administratorskiMeni(administrator);
            }
        }
        Datoteka.setAktivnosti(aktivnostAdmina);
        return (flag == 1) ? true : false;
    }

    public static boolean obrisiPesmu(Administratori administrator) throws Exception{
        String aktivnostAdmina = "\nObrisi pesmu: \n";
        try {
            int idPesme = Unos.unesiteIdPesme();
            if(vratiPesmuZaUnetiIdIzTabelePesme(idPesme) == null) throw new PesmaException(1);
            aktivnostAdmina += idPesme + "\n";

            if(!Unos.daLiSteSigurniDaZeliteDaObrisete()){
                return false;
            }

            String sql = "DELETE FROM pesme WHERE idPesme = " + idPesme;

            Datoteka.setAktivnosti(aktivnostAdmina);
            return (promeniPodatekeUBazi(sql)) ? true : false;
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }


    public String toString(){
        return "ID pesme: " + idPesme + "\nNaziv pesme: " + nazivPesme + "\nIzvodjac: \n" + izvodjac +
                "\nAlbum: " + ((album == null) ? "nema album\n" : album.getNazivAlbuma()) + "\nTrajanje pesme: " + Trajanje.formiranjeVremenaIzSekundiUString(trajanjePesme) + "\n\n";
    }
}

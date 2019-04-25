package muzika;

import administratori.Administratori;
import baza_podataka.BazaPodataka;
import datoteka.Datoteka;
import exceptions.AlbumException;
import exceptions.IzvodjacException;
import helper.Trajanje;
import meni.AdministratorskiMeni;
import sql.Sql;
import unos.Unos;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Scanner;

public class Albumi extends Sql {
    private int idAlbuma;
    private String nazivAlbuma;
    private int godinaIzdanja;
    private Izvodjaci izvodjac;
    private String zanrAlbuma;

    public String getNazivAlbuma(){
        return nazivAlbuma;
    }

    public Albumi(int idAlbuma, String nazivAlbuma, int godinaIzdanja, Izvodjaci izvodjac, String zanrAlbuma) {
        this.idAlbuma = idAlbuma;
        this.nazivAlbuma = nazivAlbuma;
        this.godinaIzdanja = godinaIzdanja;
        this.izvodjac = izvodjac;
        this.zanrAlbuma = zanrAlbuma;
    }

    public int getIdAlbuma(){
        return idAlbuma;
    }

    public static Albumi vratiAlbumZaUnetiIdIzTabeleAlbumi(int id){
        String sql = "SELECT * FROM albumi WHERE idAlbuma = " + id;
        return uzmiAlbumIzBaze(sql);
    }

    public static ArrayList<Albumi> vratiAlbumeZadatogIzvodjaca(int idIzvodjaca){
        String sql = "SELECT * FROM albumi WHERE idIzvodjaca = " + idIzvodjaca;
        return uzmiAlbumeIzBaze(sql);
    }

    public static boolean daLiJeAlbumVecKupljen(int idAlbuma, int idKorisnika){
        String sql = "SELECT * FROM kupljeniAlbumi WHERE idAlbuma = " + idAlbuma + " AND idKorisnika = " + idKorisnika;
        return (kupljeniAlbumi(sql) == null) ? false : true;
    }

    public static int poslednjIdUBaziAlbumi(){
        String sql = "SELECT idAlbuma FROM albumi ORDER BY idAlbuma DESC LIMIT 1";
        return uzmiPoslednjiIdAlbuma(sql);
    }

    public static boolean azurirajAlbum(Administratori administrator) throws Exception{
        String aktivnostAdmina = "\nAzuriranje albuma: \n";
        int flag = 1;
        Integer godinaIzdanja;
        Integer idIzvodjaca;
        int idAlbuma = Unos.unesiteIdAlbuma();
        try {
            if(vratiAlbumZaUnetiIdIzTabeleAlbumi(idAlbuma) == null) throw new AlbumException(1);
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        aktivnostAdmina += idAlbuma + "\n";

        Scanner in = new Scanner(System.in);
        System.out.println("Unesite naziv albuma:");
        String nazivAlbuma = in.nextLine();
        if(!nazivAlbuma.equals("")){
            aktivnostAdmina += nazivAlbuma + "\n";
            String sql = "UPDATE albumi SET nazivAlbuma = '" + nazivAlbuma + "' WHERE idAlbuma = " + idAlbuma;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }
        System.out.println("Unesite godinu izdanja:");
        String godinaIzdanjaString = in.nextLine();
        if(!godinaIzdanjaString.equals("")){
            aktivnostAdmina += godinaIzdanjaString + "\n";
            godinaIzdanja = Integer.parseInt(godinaIzdanjaString.trim());
            String sql = "UPDATE albumi SET godinaIzdavanja = " + godinaIzdanja + " WHERE idAlbuma = " + idAlbuma;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }
        System.out.println("Unesite id izvodjaca:");
        String idIzvodjacaString = in.nextLine();
        if(!idIzvodjacaString.equals("")){
            aktivnostAdmina += idIzvodjacaString + "\n";
            try {
                idIzvodjaca = Integer.parseInt(idIzvodjacaString.trim());
                if(Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
                String sql = "UPDATE albumi SET idIzvodjaca = " + idIzvodjaca + " WHERE idAlbuma = " + idAlbuma;
                if(!promeniPodatekeUBazi(sql)){
                    flag = 0;
                }
            } catch (Exception e){
                System.err.println(e.getMessage());
                AdministratorskiMeni.administratorskiMeni(administrator);
            }
        }

        System.out.println("Unesite zanr albuma:");
        String zanrAlbuma = in.nextLine();
        if(!zanrAlbuma.equals("")){
            aktivnostAdmina += zanrAlbuma + "\n";
            String sql = "UPDATE albumi SET zanrAlbuma = '" + zanrAlbuma + "' WHERE idALbuma = " + idAlbuma;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }

        Datoteka.setAktivnosti(aktivnostAdmina);

        return (flag == 1) ? true : false;
    }

    public static boolean ubaciAlbumUBazu(Administratori administrator) throws Exception{
        String aktivnostiAdmina = "\nUbacivanje albuma u bazu: \n";
        try{
            Scanner in = new Scanner(System.in);
            System.out.println("Unesite naziv albuma:");
            String nazivAlbuma = in.nextLine();
            aktivnostiAdmina += nazivAlbuma + "\n";
            System.out.println("Unesite godinu izdavanja");
            int godinaIzdavanja = in.nextInt();
            aktivnostiAdmina += godinaIzdavanja + "\n";
            System.out.println("Unesite id izvodjaca");
            int idIzvodjaca = in.nextInt();
            aktivnostiAdmina += idIzvodjaca + "\n";
            if(Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
            in.nextLine();
            System.out.println("Unesite zanr albuma");
            String zanrAlbuma = in.nextLine();
            aktivnostiAdmina += zanrAlbuma + "\n";
            String sql = "INSERT INTO albumi (nazivAlbuma, godinaIzdavanja, idIzvodjaca, zanrAlbuma) " +
                    "VALUES ('" + nazivAlbuma + "', " + godinaIzdavanja + ", " + idIzvodjaca + ", '" + zanrAlbuma + "')";
            if(promeniPodatekeUBazi(sql)){
                aktivnostiAdmina += "\nUnos pesama upravo unetog albuma: \n";
                Datoteka.setAktivnosti(aktivnostiAdmina);
                int idAlbuma = poslednjIdUBaziAlbumi();
                while (true){
                    if(!unosPesamaUnetogAlbuma(idIzvodjaca, idAlbuma, administrator)){
                        break;
                    }
                }
            }
            return true;
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    private static boolean unosPesamaUnetogAlbuma(int idIzvodjaca, int idAlbuma, Administratori administrator) throws Exception{
        try {
            String aktivnostAdmina = "";
            Scanner in = new Scanner(System.in);
            System.out.println("Unesite naziv pesme:");
            String nazivPesme = in.nextLine();
            if(nazivPesme.equals("")){
                return false;
            }
            aktivnostAdmina += nazivPesme + "\n";
            System.out.println("Unesite trajanje pesme:");
            System.out.println("Format: hh:mm:ss");
            String vreme = in.nextLine();
            aktivnostAdmina += vreme + "\n";
            int trajanjePesme = Trajanje.formiranjeVremenaIzStringaUSekunde(vreme);
            String sql = "INSERT INTO pesme (nazivPesme, idIzvodjaca, idAlbuma, trajanjePesme) VALUES ('" + nazivPesme + "', " + idIzvodjaca + ", " + idAlbuma + ", " + trajanjePesme + ")";
            Datoteka.setAktivnosti(aktivnostAdmina);
            return (promeniPodatekeUBazi(sql)) ? true : false;
        } catch (Exception e) {
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    public static boolean obrisiAlbum(Administratori administrator) throws Exception{
        String aktivnosAdmina = "\nBrisanje albuma: \n";
        try {
            int idAlbuma = Unos.unesiteIdAlbuma();
            if(vratiAlbumZaUnetiIdIzTabeleAlbumi(idAlbuma) == null) throw new AlbumException(1);
            aktivnosAdmina += idAlbuma + "\n";

            if(!Unos.daLiSteSigurniDaZeliteDaObrisete()){
                return false;
            }
            BazaPodataka bazaPodataka = BazaPodataka.getInstanca();

            bazaPodataka.automatskaTransakcija(false);
            String sql = "DELETE FROM albumi WHERE idAlbuma = " + idAlbuma;
            bazaPodataka.updateInsertDeletUpit(sql);
            sql = "DELETE FROM pesme WHERE idAlbuma = " + idAlbuma;
            bazaPodataka.updateInsertDeletUpit(sql);
            sql = "DELETE FROM kupljeniAlbumi WHERE idAlbuma = " + idAlbuma;
            bazaPodataka.updateInsertDeletUpit(sql);
            bazaPodataka.snimiTransakciju();
            bazaPodataka.automatskaTransakcija(true);
            Datoteka.setAktivnosti(aktivnosAdmina);
            return true;
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    public String toString(){
        return "\nID albuma: " + idAlbuma + "\nNaziv albuma: " + nazivAlbuma + "\nIzvodjac: " + izvodjac.getNazivIzvodjaca() + "\nUkupno trajanje: " + Trajanje.ukupnoTrajanjeAlbuma(idAlbuma) + "\n\n";
    }
}

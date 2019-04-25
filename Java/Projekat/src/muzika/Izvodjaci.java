package muzika;

import administratori.Administratori;
import baza_podataka.BazaPodataka;
import datoteka.Datoteka;
import exceptions.IzvodjacException;
import meni.AdministratorskiMeni;
import sql.Sql;
import unos.Unos;

import java.sql.SQLException;
import java.util.Scanner;

public class Izvodjaci extends Sql {
    private int idIzvodjaca;
    private String nazivIzvodjaca;
    private Tip tipIzvodjaca;
    private int godinaFormiranja;
    private int godinaRaspada;
    private String biografija;

    public int getIdIzvodjaca() {return idIzvodjaca;}
    public String getNazivIzvodjaca(){return nazivIzvodjaca;}

    public Izvodjaci(int idIzvodjaca, String nazivIzvodjaca, Tip tipIzvodjaca, int godinaFormiranja, int godinaRaspada, String biografija) {
        this.idIzvodjaca = idIzvodjaca;
        this.nazivIzvodjaca = nazivIzvodjaca;
        this.tipIzvodjaca = tipIzvodjaca;
        this.godinaFormiranja = godinaFormiranja;
        this.godinaRaspada = godinaRaspada;
        this.biografija = biografija;
    }

    public Izvodjaci(int idIzvodjaca, String nazivIzvodjaca, Tip tipIzvodjaca, int godinaFormiranja, String biografija) {
        this.idIzvodjaca = idIzvodjaca;
        this.nazivIzvodjaca = nazivIzvodjaca;
        this.tipIzvodjaca = tipIzvodjaca;
        this.godinaFormiranja = godinaFormiranja;
        this.biografija = biografija;
    }

    public static Izvodjaci vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(int id){
        String sql = "SELECT * FROM izvodjaci WHERE idIzvodjaca = " + id;
        return uzmiIzvodjacaIzBaze(sql);
    }

    public static Izvodjaci vratiIzvodjacaZaUnetioIme(String ime){
        String sql = "SELECT * FROM izvodjaci WHERE nazivIzvodjaca = '" + ime + "'";
        return uzmiIzvodjacaIzBaze(sql);
    }

    public static boolean ubaciIzvodjacaUBazu(Administratori administrator) throws Exception{
        try{
            String aktivnostiAdmina = "\nUbacivanje izvodjaca u bazu:\n";
            Integer godinaRaspada;
            Scanner in = new Scanner(System.in);
            System.out.println("Unesite naziv izvodjaca:");
            String nazivIzvodjaca = in.nextLine();
            aktivnostiAdmina += nazivIzvodjaca + "\n";
            System.out.println("Unesite tip izvodjaca:");
            String tipIzvodjaca = in.nextLine().toUpperCase();
            if(!tipIzvodjaca.equals("SOLO") && !tipIzvodjaca.equals("BEND") && !tipIzvodjaca.equals("DUO")) throw new Exception("\nGreska pri unosenju tipa izvodjaca\n");
            aktivnostiAdmina += tipIzvodjaca + "\n";
            System.out.println("Unesite godinu formiranja:");
            int godinaFormiranja = in.nextInt();
            aktivnostiAdmina += godinaFormiranja + "\n";
            in.nextLine();
            System.out.println("Unesite godinu raspada");
            String godinaRaspadaString = in.nextLine();
            aktivnostiAdmina += godinaRaspadaString + "\n";
            if(godinaRaspadaString.equals("")){
                godinaRaspada = null;
            } else{
                godinaRaspada = Integer.parseInt(godinaRaspadaString.trim());
            }
            System.out.println("Unesite biografiju:");
            String biografija = in.nextLine();
            aktivnostiAdmina += biografija + "\n";

            String sql = "INSERT INTO izvodjaci (nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija) " +
                    "VALUES ('" + nazivIzvodjaca + "', '" + tipIzvodjaca + "', " + godinaFormiranja + ", " + godinaRaspada + ", '" + biografija + "')";

            Datoteka.setAktivnosti(aktivnostiAdmina);
            return (promeniPodatekeUBazi(sql)) ? true : false;
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    public static boolean obrisiIzvodjaca(Administratori administrator) throws Exception{
        try{
            String aktivnostiAdmina = "\nBrisanje izvodjaca: \n";
            int idIzvodjaca = Unos.unesiIdIzvodjaca();
            if(vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
            aktivnostiAdmina += idIzvodjaca + "\n";

            if(!Unos.daLiSteSigurniDaZeliteDaObrisete()){
                return false;
            }
            BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
            bazaPodataka.automatskaTransakcija(false);
            String sql = "DELETE FROM albumi WHERE idIzvodjaca = " + idIzvodjaca;
            bazaPodataka.updateInsertDeletUpit(sql);
            sql = "DELETE FROM pesme WHERE idIzvodjaca = " + idIzvodjaca;
            bazaPodataka.updateInsertDeletUpit(sql);
            sql = "DELETE FROM izvodjaci WHERE idIzvodjaca = " + idIzvodjaca;
            bazaPodataka.updateInsertDeletUpit(sql);
            bazaPodataka.snimiTransakciju();
            bazaPodataka.automatskaTransakcija(true);
            Datoteka.setAktivnosti(aktivnostiAdmina);
            return true;
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }
        return false;
    }

    public static boolean azurirajIzvodjaca(Administratori administrator) throws Exception{
        String aktivnostiAdmina = "\nAzuriranje izvodjaca:\n";
        int flag = 1;
        Integer godinaFormiranja;
        Integer godinaRaspada;
        int idIzvodjaca = Unos.unesiIdIzvodjaca();
        aktivnostiAdmina += idIzvodjaca + "\n";
        try{
            if(vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(idIzvodjaca) == null) throw new IzvodjacException();
        } catch (Exception e){
            System.err.println(e.getMessage());
            AdministratorskiMeni.administratorskiMeni(administrator);
        }

        Scanner in = new Scanner(System.in);
        System.out.println("Unesite naziv izvodjaca:");
        String nazivIzvodjaca = in.nextLine();
        if(!nazivIzvodjaca.equals("")){
            aktivnostiAdmina += nazivIzvodjaca + "\n";
            String sql = "UPDATE izvodjaci SET nazivIzvodjaca = '" + nazivIzvodjaca + "' WHERE idIzvodjaca = " + idIzvodjaca;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }
        System.out.println("Unesite tip izvodjaca:");
        String tipIzovdjaca = in.nextLine().toUpperCase();
        if(!tipIzovdjaca.equals("")){
            aktivnostiAdmina += tipIzovdjaca + "\n";
            try {
                if(!tipIzovdjaca.equals("SOLO") && !tipIzovdjaca.equals("BEND") && !tipIzovdjaca.equals("DUO")) throw new Exception("\nGreska pri unosenju tipa izvodjaca\n");
                String sql = "UPDATE izvodjaci SET tipIzvodjaca = '" + tipIzovdjaca + "' WHERE idIzvodjaca = " + idIzvodjaca;
                if(!promeniPodatekeUBazi(sql)){
                    flag = 0;
                }
            } catch (Exception e){
                System.err.println(e.getMessage());
                AdministratorskiMeni.administratorskiMeni(administrator);
            }
        }
        System.out.println("Unesite godinu formiranja:");
        String godinaFormiranjaString = in.nextLine();
        if(!godinaFormiranjaString.equals("")){
            aktivnostiAdmina += godinaFormiranjaString + "\n";
            godinaFormiranja = Integer.parseInt(godinaFormiranjaString.trim());
            String sql = "UPDATE izvodjaci SET godinaFormiranja = " + godinaFormiranja + " WHERE idIzvodjaca = " + idIzvodjaca;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }

        System.out.println("Unesite godinu raspada:");
        String godinaRaspadaString = in.nextLine();
        if(!godinaRaspadaString.equals("")){
            aktivnostiAdmina += godinaRaspadaString + "\n";
            godinaRaspada = Integer.parseInt(godinaRaspadaString.trim());
            String sql = "UPDATE izvodjaci SET godinaRaspada = " + godinaRaspada + " WHERE idIzvodjaca = " + idIzvodjaca;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }

        System.out.println("Unesite biografiju:");
        String biografija = in.nextLine();
        if(!biografija.equals("")){
            aktivnostiAdmina += biografija + "\n";
            String sql = "UPDATE izvodjaci SET biografija = '" + biografija + "' WHERE idIzvodjaca = " + idIzvodjaca;
            if(!promeniPodatekeUBazi(sql)){
                flag = 0;
            }
        }

        Datoteka.setAktivnosti(aktivnostiAdmina);

        return (flag == 1) ? true : false;
    }

    public String toString(){
        return "ID izvodjaca: " + idIzvodjaca + "\nNaziv izvodjaca: " + nazivIzvodjaca + "\nTip izvodjaca: " + tipIzvodjaca +
                "\nGodina formiranja: " + godinaFormiranja + ((godinaRaspada == 0) ? "" : "\nGodina raspada: " + godinaRaspada) +
                "\nBiografija: " + biografija;
    }
}

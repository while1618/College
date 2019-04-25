package sql;

import administratori.Administratori;
import baza_podataka.BazaPodataka;
import korisnici.Korisnici;
import muzika.Albumi;
import muzika.Izvodjaci;
import muzika.Pesme;
import muzika.Tip;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public abstract class Sql {

    protected static boolean proveraUBaziZaImeILozinku(String ime, String lozinka, String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try {
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            while (resultSet.next()){
                if(resultSet.getString("ime").equals(ime) &&
                        resultSet.getString("lozinka").equals(lozinka)){
                    return true;
                }
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return false;
    }

    protected static boolean promeniPodatekeUBazi(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try {
            int brojPromenjenihRedova = bazaPodataka.updateInsertDeletUpit(sql);
            if(brojPromenjenihRedova == 1){
                return true;
            }
            return false;
        } catch (SQLException e){
            System.err.println("Doslo je do greske prilikom menjaja podataka u bazi: " + e);
            System.exit(1);
        }
        return false;
    }

    protected static Albumi uzmiAlbumIzBaze(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                int idAlbuma = resultSet.getInt("idAlbuma");
                String nazivAlbuma = resultSet.getString("nazivAlbuma");
                int godinaIzdanja = resultSet.getInt("godinaIzdavanja");
                Izvodjaci izvodjac = Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(resultSet.getInt("idIzvodjaca"));
                String zanrAlbuma = resultSet.getString("zanrAlbuma");
                return new Albumi(idAlbuma, nazivAlbuma, godinaIzdanja, izvodjac, zanrAlbuma);
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return null;
    }

    protected static Izvodjaci uzmiIzvodjacaIzBaze(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                int idIzvodjaca = resultSet.getInt("idIzvodjaca");
                String nazivIzvodjaca = resultSet.getString("nazivIzvodjaca");
                Tip tipIzvodjaca = Tip.valueOf(resultSet.getString("tipIzvodjaca"));
                int godinaFormiranja = resultSet.getInt("godinaFormiranja");
                int godinaRaspada = resultSet.getInt("godinaRaspada");
                String biografija = resultSet.getString("biografija");
                if(godinaRaspada == 0){
                    return new Izvodjaci(idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, biografija);
                } else {
                    return new Izvodjaci(idIzvodjaca, nazivIzvodjaca, tipIzvodjaca, godinaFormiranja, godinaRaspada, biografija);
                }
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return null;
    }

    protected static Pesme uzmiPesmuIzBaze(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                int idPesme = resultSet.getInt("idPesme");
                String nazivPesme = resultSet.getString("nazivPesme");
                Izvodjaci izvodjac = Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(resultSet.getInt("idIzvodjaca"));
                Albumi album = Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(resultSet.getInt("idAlbuma"));
                int trajanjePesme = resultSet.getInt("trajanjePesme");
                if(album == null){
                    return new Pesme(idPesme, nazivPesme, izvodjac, trajanjePesme);
                } else{
                    return new Pesme(idPesme, nazivPesme, izvodjac, album, trajanjePesme);
                }
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return null;
    }

    protected static Korisnici uzmiKorisnikaIzBaze(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                int idKorisnika = resultSet.getInt("idKorisnika");
                String ime = resultSet.getString("ime");
                String lozinka = resultSet.getString("lozinka");
                return new Korisnici(idKorisnika, ime, lozinka);
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return null;
    }

    protected static Administratori uzmiAdministratoraIzBaze(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                int idAdministratora = resultSet.getInt("idAdministratora");
                String ime = resultSet.getString("ime");
                String lozinka = resultSet.getString("lozinka");
                return new Administratori(idAdministratora, ime, lozinka);
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return null;
    }

    protected static ArrayList<Pesme> listaKupljenihIndividualnihPesama(String sql){
        ArrayList<Pesme> listaKuplenjihIndividualnihPesama = new ArrayList<>();
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            while(resultSet.next()){
                Pesme pesma = Pesme.vratiPesmuZaUnetiIdIzTabelePesme(resultSet.getInt("idPesme"));
                listaKuplenjihIndividualnihPesama.add(pesma);
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return listaKuplenjihIndividualnihPesama;
    }

    protected static Pesme kupljenePesme(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                return Pesme.vratiPesmuZaUnetiIdIzTabelePesme(resultSet.getInt("idPesme"));
            }
        } catch (SQLException e){
            System.err.println("Doslo je do greske prilikom uzmianja pesma iz baze:" +  e);
            System.exit(1);
        }
        return null;
    }

    protected static Albumi kupljeniAlbumi(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            if(resultSet.next()){
                return Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(resultSet.getInt("idAlbuma"));
            }
        } catch (SQLException e){
            System.err.println("Doslo je do greske prilikom uzmianja albuma iz baze:" +  e);
            System.exit(1);
        }
        return null;
    }

    protected static ArrayList<Albumi> listaKupljenihAlbuma(String sql){
        ArrayList<Albumi> listaKupljenihAlbuma = new ArrayList<>();
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            while(resultSet.next()){
                Albumi album = Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(resultSet.getInt("idAlbuma"));
                listaKupljenihAlbuma.add(album);
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return listaKupljenihAlbuma;
    }


    protected static ArrayList<Pesme> uzmiPesmeIzBaze(String sql){
        ArrayList<Pesme> listaPesama = new ArrayList<>();
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            while(resultSet.next()){
                int idPesme = resultSet.getInt("idPesme");
                String nazivPesme = resultSet.getString("nazivPesme");
                Izvodjaci izvodjac = Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(resultSet.getInt("idIzvodjaca"));
                Albumi album = Albumi.vratiAlbumZaUnetiIdIzTabeleAlbumi(resultSet.getInt("idAlbuma"));
                int trajanjePesme = resultSet.getInt("trajanjePesme");
                if(album == null){
                     listaPesama.add(new Pesme(idPesme, nazivPesme, izvodjac, trajanjePesme));
                } else{
                     listaPesama.add(new Pesme(idPesme, nazivPesme, izvodjac, album, trajanjePesme));
                }
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return listaPesama;
    }

    protected static ArrayList<Albumi> uzmiAlbumeIzBaze(String sql){
        ArrayList<Albumi> listaAlbuma = new ArrayList<>();
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try{
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            while(resultSet.next()){
                int idAlbuma = resultSet.getInt("idAlbuma");
                String nazivAlbuma = resultSet.getString("nazivAlbuma");
                int godinaIzdanja = resultSet.getInt("godinaIzdavanja");
                Izvodjaci izvodjac = Izvodjaci.vratiIzvodjacaZaUnetiIdIzTabeleIzvodjaci(resultSet.getInt("idIzvodjaca"));
                String zanrAlbuma = resultSet.getString("zanrAlbuma");
                listaAlbuma.add(new Albumi(idAlbuma, nazivAlbuma, godinaIzdanja, izvodjac, zanrAlbuma));
            }
        } catch (SQLException e){
            System.err.println("Doslo je od greske prilikom uzimanja podataka iz tabele: " + e);
            System.exit(1);
        }
        return listaAlbuma;
    }

    protected static int uzmiPoslednjiIdPesme(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try {
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            return resultSet.getInt("idPesme");
        } catch (SQLException e){
            System.err.println("Doslo je do greske prilikom uzimanja poslednjeg id iz tabele pesme: " + e);
            System.exit(1);
        }
        return -1;
    }

    protected static int uzmiPoslednjiIdAlbuma(String sql){
        BazaPodataka bazaPodataka = BazaPodataka.getInstanca();
        try {
            ResultSet resultSet = bazaPodataka.selectUpit(sql);
            return resultSet.getInt("idAlbuma");
        } catch (SQLException e){
            System.err.println("Doslo je do greske prilikom uzimanja poslednjeg id iz tabele albumi: " + e);
            System.exit(1);
        }
        return -1;
    }
}

package meni;

import administratori.Administratori;
import datoteka.Datoteka;
import muzika.Albumi;
import muzika.Izvodjaci;
import muzika.Pesme;
import unos.Unos;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class AdministratorskiMeni{
    private static void ispisMenija(){
        System.out.println("1. Unos pesme");
        System.out.println("2. Unos izvodjaca");
        System.out.println("3. Unos albuma");
        System.out.println("4. Azuriranje pesme");
        System.out.println("5. Azuriranje izvodjaca");
        System.out.println("6. Azuriranje albuma");
        System.out.println("7. Brisanje pesme");
        System.out.println("8. Brisanje izvodjaca");
        System.out.println("9. Brisanje albuma");
        System.out.println("10. Odjava");
    }
    public static void administratorskiMeni(Administratori administrator) throws Exception{
        ispisMenija();
        int opcija = Unos.unosOpcije();
        switch (opcija){
            case 1:
                if(!Pesme.ubaciPesmuUBazu(administrator)) throw new Exception("Doslo je do greske priliokm ubacivanja pesme");
                System.out.println("\nUspesno ste uneli pesmu\n");
                administratorskiMeni(administrator);
                break;
            case 2:
                if(!Izvodjaci.ubaciIzvodjacaUBazu(administrator)) throw new Exception("Doslo je do greske priliokm ubacivanja izvodjaca");
                System.out.println("\nUspesno ste ubacili izvodjaca\n");
                administratorskiMeni(administrator);
                break;
            case 3:
                if(!Albumi.ubaciAlbumUBazu(administrator)) throw new Exception("Doslo je do greske prilikom ubacivanja albuma");
                System.out.println("\nUspesno ste ubacili album\n");
                administratorskiMeni(administrator);
                break;
            case 4:
                if(!Pesme.azurirajPesmu(administrator)) throw new Exception("Doslo je do greske priliom azuriranja pesme");
                System.out.println("\nUspesno ste azurirali pesmu\n");
                administratorskiMeni(administrator);
                break;
            case 5:
                if(!Izvodjaci.azurirajIzvodjaca(administrator)) throw new Exception("Doslo je do greske prilikom azuriranja izvodjaca");
                System.out.println("\nUspesno ste azurirali izvodjaca\n");
                administratorskiMeni(administrator);
                break;
            case 6:
                if(!Albumi.azurirajAlbum(administrator)) throw new Exception("Doslo je do greske prilikom azuriranja albuma");
                System.out.println("\nUspesno ste azurirali album\n");
                administratorskiMeni(administrator);
                break;
            case 7:
                if(!Pesme.obrisiPesmu(administrator)) throw new Exception("Doslo je do greske prilikom brisanja pesme");
                System.out.println("\nUspesno ste obrisali pesmu\n");
                administratorskiMeni(administrator);
                break;
            case 8:
                if(!Izvodjaci.obrisiIzvodjaca(administrator)) throw new Exception("Doslo je do greske prilikom brisanja izvodjaca");
                System.out.println("\nUspesno ste obrisali izvodjaca i sve njegove pesme i albume\n");
                administratorskiMeni(administrator);
                break;
            case 9:
                if(!Albumi.obrisiAlbum(administrator)) throw new Exception("Doslo je do greske prilikom brisanja albuma");
                System.out.println("\nUspesno ste obrisali album i sve pesme iz albuma\n");
                administratorskiMeni(administrator);
                break;
            case 10:
                DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
                Date date = new Date();
                Datoteka.setAktivnosti("\nVreme odjavljivanja: " + dateFormat.format(date) + "\n");
                Datoteka.upisiUDatoteku();
                System.out.println("\nAktivnosti upisane u datoteku\n");
                Datoteka.obrisiAktivnosti();
                administrator = null;
                System.out.println("\nUspesno ste se odjavili\n");
                MainMeni.mainMeni();
            default:
                System.err.println("Pogresna opcija");
                System.out.println();
                administratorskiMeni(administrator);
                break;
        }
    }
}

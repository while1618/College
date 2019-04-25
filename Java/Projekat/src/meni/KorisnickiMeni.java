package meni;

import exceptions.IzvodjacException;
import korisnici.Korisnici;
import muzika.*;
import podaci.Podaci;
import unos.Unos;

public class KorisnickiMeni{
    private static void ispisMenija(){
        System.out.println("1. Prikaz biblioteke kupljenih albuma i pesama");
        System.out.println("2. Pretraga izvodjaca u muzickoj aplikaciji");
        System.out.println("3. Dodavanje pesme u biblioteku");
        System.out.println("4. Dodavanje albuma u biblioteku");
        System.out.println("5. Odjava");
    }

    private static void ispisDrugogMenija(){
        System.out.println("1. Prikaz pesama i albuma");
        System.out.println("2. Dodavanje pesme u biblioteku");
        System.out.println("3. Dodavanje albuma u biblioteku");
        System.out.println("4. Nazad");
    }

    public static void korisnickiMeni(Korisnici korisnik) throws Exception{
        ispisMenija();
        int opcija = Unos.unosOpcije();
        switch (opcija){
            case 1:
                Korisnici.ispisiKupljenihAlbumaIPesama(korisnik.getIdKorisnika());
                break;
            case 2:
                try{
                    Podaci podatak = Unos.unesiImeIzvodjaca();
                    Izvodjaci izvodjac = Izvodjaci.vratiIzvodjacaZaUnetioIme(podatak.getIme());
                    if(izvodjac == null) throw new IzvodjacException();
                    System.out.println(izvodjac + "\n\n");
                    while (true){
                        drugiKorisnickiMeni(korisnik,izvodjac);
                    }
                } catch (IzvodjacException e){
                    System.err.println(e.getMessage());
                    korisnickiMeni(korisnik);
                }
                break;
            case 3:
                KupljenePesme.kupovinaPesme(korisnik);
                break;
            case 4:
                KupljeniAlbumi.kupovinaAlbuma(korisnik);
                break;
            case 5:
                korisnik = null;
                System.out.println("\nUspesno ste se odjavili\n");
                MainMeni.mainMeni();
            default:
                System.err.println("Pogresna opcija");
                System.out.println();
                break;
        }
        korisnickiMeni(korisnik);
    }
    private static void drugiKorisnickiMeni(Korisnici korisnik, Izvodjaci izvodjac) throws Exception{
        ispisDrugogMenija();
        int opcija = Unos.unosOpcije();
        switch (opcija){
            case 1:
                Korisnici.ispsiPesamaIAlbumaZadatogIzvodjaca(izvodjac.getIdIzvodjaca());
                break;
            case 2:
                KupljenePesme.kupovinaPesme(korisnik);
                break;
            case 3:
                KupljeniAlbumi.kupovinaAlbuma(korisnik);
                break;
            case 4:
                korisnickiMeni(korisnik);
            default:
                System.err.println("Pogresna opcija");
                System.out.println();
                drugiKorisnickiMeni(korisnik, izvodjac);
                break;
        }
    }
}

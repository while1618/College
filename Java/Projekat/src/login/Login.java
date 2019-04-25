package login;

import administratori.Administratori;
import datoteka.Datoteka;
import korisnici.Korisnici;
import podaci.Podaci;
import unos.Unos;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

import static meni.AdministratorskiMeni.administratorskiMeni;
import static meni.KorisnickiMeni.korisnickiMeni;

public class Login {
    public static void login(){
        Podaci loginPodaci;
        int brojLogovanja = 0;
        while(brojLogovanja < 3){
            try{
                loginPodaci = Unos.unesiLoginPodateke();
                if(loginPodaci.getIme().startsWith("a")){
                    if(Administratori.daLiJeDobroAdministratorskoImeILozinka(loginPodaci.getIme(), loginPodaci.getLozinka())){
                        while (true){
                            Administratori administrator = Administratori.vratiAdministratoraZaUnetoAdministratorskoIme(loginPodaci.getIme());
                            Datoteka.setAktivnosti("\nAdministrator: " + loginPodaci.getIme() + "\n");
                            DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
                            Date date = new Date();
                            Datoteka.setAktivnosti("\nVreme prijavljivanja: " + dateFormat.format(date) + "\n");
                            administratorskiMeni(administrator);
                        }
                    } else{
                        throw new Exception("Jedan od podataka nije validan");
                    }
                } else if(loginPodaci.getIme().startsWith("k")){
                    if(Korisnici.daLiJeDobroKorisnickoImeILozinka(loginPodaci.getIme(), loginPodaci.getLozinka())){
                        while (true){
                            Korisnici korisnik = Korisnici.vratiKorisnikaZaUnetoKorisnickoIme(loginPodaci.getIme());
                            korisnickiMeni(korisnik);
                        }
                    } else{
                        throw new Exception("Jedan od podataka nije validan");
                    }
                } else{
                    throw new Exception("Jedan od podataka nije validan");
                }
            } catch (Exception e){
                System.err.println(e.getMessage());
                brojLogovanja++;
            }
        }
    }
}

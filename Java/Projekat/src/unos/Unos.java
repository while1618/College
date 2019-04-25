package unos;

import podaci.Podaci;

import java.util.Scanner;

public abstract class Unos {
    public static int unosOpcije(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite opciju:");
        return in.nextInt();
    }

    public static Podaci unesiLoginPodateke(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite ime:");
        String ime = in.nextLine();
        System.out.println("Unesite lozinku:");
        String lozinka = in.nextLine();
        return new Podaci(ime, lozinka);
    }

    public static Podaci unesiImeIzvodjaca(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite ime izvodjaca:");
        String ime = in.nextLine();
        return new Podaci(ime);
    }

    public static int unesiteIdPesme(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite id pesme:");
        return in.nextInt();
    }

    public static int unesiteIdAlbuma(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite id albuma:");
        return in.nextInt();
    }

    public static int unesiIdIzvodjaca(){
        Scanner in = new Scanner(System.in);
        System.out.println("Unesite id izvodjaca:");
        return in.nextInt();
    }

    public static boolean daLiSteSigurniDaZeliteDaObrisete(){
        Scanner in = new Scanner(System.in);
        System.out.println("Da li ste sigurni da zelite da obrisete podatak? (da/ne)");
        String provera = in.nextLine();
        if(provera.toLowerCase().equals("da")){
            return true;
        }
        return false;
    }
}

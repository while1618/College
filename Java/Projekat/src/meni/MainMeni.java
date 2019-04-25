package meni;

import login.Login;
import unos.Unos;

public class MainMeni {
    private static void ispisMenija(){
        System.out.println("1. Login");
        System.out.println("2. Ugasi aplikaciju");
    }

    public static void mainMeni(){
        ispisMenija();
        int opcija = Unos.unosOpcije();
        switch (opcija){
            case 1:
                Login.login();
                break;
            case 2:
                System.exit(0);
            default:
                System.err.println("Pogresna opcija");
                System.out.println();
                mainMeni();
                break;
        }
    }

}

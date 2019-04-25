package administratori;

import sql.Sql;

public class Administratori extends Sql {
    private int idAdministratora;
    private String administratorskoIme;
    private String lozinka;

    public Administratori(int idAdministratora, String administratorskoIme, String lozinka) {
        this.idAdministratora = idAdministratora;
        this.administratorskoIme = administratorskoIme;
        this.lozinka = lozinka;
    }

    public static boolean daLiJeDobroAdministratorskoImeILozinka(String administratorskoIme, String lozinka){
        String sql = "SELECT ime, lozinka FROM administratori";
        return proveraUBaziZaImeILozinku(administratorskoIme, lozinka, sql);
    }

    public static Administratori vratiAdministratoraZaUnetoAdministratorskoIme(String ime){
        String sql = "SELECT * FROM administratori WHERE ime = '" + ime + "'";
        return uzmiAdministratoraIzBaze(sql);
    }
}

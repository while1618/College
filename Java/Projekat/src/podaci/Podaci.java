package podaci;

public class Podaci {
    private String ime;
    private String lozinka;

    public Podaci(String ime, String lozinka){
        this.ime = ime;
        this.lozinka = lozinka;
    }

    public Podaci(String ime){
        this.ime = ime;
    }

    public String getIme(){
        return ime;
    }

    public String getLozinka(){
        return lozinka;
    }
}

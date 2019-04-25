package exceptions;

public class PesmaException extends Exception {
    private int greska;

    public PesmaException(int greska) {
        this.greska = greska;
    }

    @Override
    public String getMessage() {
        switch (greska){
            case 1: return "\nUneti id ne postoji u nasoj bazi\n";
            case 2: return "\nVec ste kupili ovu pesmu\n";
            case 3: return "\nDoslo je do greske prilikom kupovine pesme\n";
            default: return "\nNepoznata greska\n";
        }
    }
}

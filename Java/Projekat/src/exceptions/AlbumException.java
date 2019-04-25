package exceptions;

public class AlbumException extends Exception {
    private int greska;

    public AlbumException(int greska) {
        this.greska = greska;
    }

    @Override
    public String getMessage() {
        switch (greska){
            case 1: return "\nUneti album ne postoji u nasoj bazi\n";
            case 2: return "\nVec ste kupili ovaj album\n";
            case 3: return "\nDoslo je do greske prilikom kupovine albuma\n";
            default: return "\nNepoznata greska\n";
        }
    }
}

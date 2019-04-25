package exceptions;

public class IzvodjacException extends Exception{
    @Override
    public String getMessage() {
        return "\nUneti izvodjac ne postoji\n";
    }
}

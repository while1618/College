#include <iostream>
#include "Knjiga.h"
#include "Polica.h"

int main() {
    Knjiga *knjiga = new Knjiga("Besnilo", "Borislav Pekic", 7);
    Knjiga *kopijaKnjige = new Knjiga(*knjiga);
    Knjiga *knjiga2 = new Knjiga("Crna ruza", "Umberto Eko", 10);

    Polica *polica = new Polica(27);

    polica->dodajKnjiguNaPolicu(knjiga);
    polica->dodajKnjiguNaPolicu(kopijaKnjige);
    polica->dodajKnjiguNaPolicu(knjiga2);

    polica->ispisPolice();

    if(polica->obrisiKnjiguSaPolice(1)){
        cout << "Uspesno obrisana knjiga sa police!" << endl;
    } else {
        cout << "Nije moguce obrisati knjigu!" << endl;
    }

    polica->ispisPolice();

    polica->dodajKopijuKnjige(*knjiga2);

    polica->ispisPolice();

    return 0;
}
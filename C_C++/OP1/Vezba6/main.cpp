#include <iostream>
#include "Pez.h"
#include "KutijaPeza.h"

int Pez::brojac = 1;

int main() {
    KutijaPeza kutija;
    kutija.ispisi();

    kutija.unistiPez();

    kutija.ispisi();

    kutija.dodajPez();
    kutija.ispisi();

    Pez *pez1 = kutija.uzmiPez();
    pez1->ispisi();

    return 0;
}
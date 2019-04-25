#include <iostream>
#include "Karta.h"
#include "Avion.h"

int main() {
    int duzinaNiza = 8;
    Karta nizKarata[duzinaNiza] = {
            Karta(1, 1, 100),
            Karta(1, 2, 100),
            Karta(2, 3, 100),
            Karta(5, 3, 100),
            Karta(10, 2, 100),
            Karta(10, 3, 100),
            Karta(10, 4, 100),
            Karta(10, 4, 100)
    };

    Karta *pokazivacNaNizKarata[duzinaNiza];

    for(int i = 0; i < duzinaNiza; i++){
        pokazivacNaNizKarata[i] = &nizKarata[i];
    }

    Avion *avion = new Avion("boing", 12, 12);

    //Ovo se radi samo zbog windowsa, posto u njemu program kresuje, u linuxu radi i bez ovoga
    avion->setujAvionNaNullptr();

    for(int i = 0; i < duzinaNiza; i++){
        avion->rezervisiMesto(pokazivacNaNizKarata[i]);
    }

    avion->ukupnaCenaKarataUAvionu();
    avion->ispisSvihKarataUAvionu();

    avion->glavniIspisAviona();

    cout << "\nIspis karata u zadatom redu: \n\n";
    Karta **redKarata = avion->getRedKarata(1);
    for(int i = 0; i < avion->getDuzinaSvakogReda(); i++){
        if(redKarata[i] != nullptr){
            redKarata[i]->ispisKarte();
        }
    }

    cout << "Ispis trazene pojedinacne karte: \n\n";
    Karta *pojedinacnaKarta = avion->getAdresaPojedineKarte(pokazivacNaNizKarata[1]);
    pojedinacnaKarta->ispisKarte();
    return 0;
}
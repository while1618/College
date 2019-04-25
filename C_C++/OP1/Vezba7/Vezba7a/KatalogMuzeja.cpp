//
// Created by dejan on 28.4.17..
//

#include "KatalogMuzeja.h"
#include <iostream>
using namespace std;

KatalogMuzeja::KatalogMuzeja(){
    this->nizSlika = nullptr;
    this->duzina = 0;
}

KatalogMuzeja::KatalogMuzeja(Slika *nizSlika, int duzina) {
    this->duzina = duzina;
    this->nizSlika = new Slika[duzina];
    for(int i = 0; i<duzina; i++){
        this->nizSlika[i] = nizSlika[i];
    }
}

void KatalogMuzeja::postavi(Slika slika) {
    Slika *pomocniNiz = new Slika[duzina+1];
    for(int i = 0; i<duzina; i++){
        pomocniNiz[i] = nizSlika[i];
    }
    pomocniNiz[duzina] = slika;
    delete[](nizSlika);
    nizSlika = new Slika[++duzina];

    for(int i = 0; i<duzina; i++){
        nizSlika[i] = pomocniNiz[i];
    }

    delete[](pomocniNiz);
}

void KatalogMuzeja::obrisi(int index) {

    if(index >= duzina){
        cout<<"Unet je index koji ne postoji u nizu\n\n";
        return;
    }

    Slika *pomocniNiz = new Slika[duzina-1];

    for(int i = 0, j = 0; i<duzina; i++){
        if(index != i){
            pomocniNiz[j++] = nizSlika[i];
        }
    }

    delete[](nizSlika);
    nizSlika = new Slika[--duzina];

    for(int i = 0; i<duzina; i++){
        nizSlika[i] = pomocniNiz[i];
    }

    delete[](pomocniNiz);
}

void KatalogMuzeja::ispisMuzej() {
    for(int i = 0; i<duzina; i++){
        nizSlika[i].ispis();
    }
}
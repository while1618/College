//
// Created by dejan on 28.4.17..
//
#pragma once

#include "Slika.h"

class KatalogMuzeja {
protected:
    Slika *nizSlika;
    int duzina;
public:
    KatalogMuzeja(Slika nizSlika[], int duzina);
    KatalogMuzeja();
    void postavi(Slika slika);
    void obrisi(int index);
    int getDuzina(){ return duzina; }
    Slika* getNizSlika(){ return nizSlika; }
    void ispisMuzej();
};
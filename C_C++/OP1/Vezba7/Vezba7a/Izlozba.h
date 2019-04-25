//
// Created by dejan on 28.4.17..
//
#pragma once

#include "KatalogMuzeja.h"

class Izlozba : public KatalogMuzeja{
private:
    Slika *slikeZaIzlozbu;
    int brojSlika;
    int *nizKat;
public:
    Izlozba(Slika nizSlika[], int duzina, int brojSlika, int *nizKat);
    void postavi(Slika slika, int index);
    void obrisi(int index);
    void ispisIzlozbe();
};

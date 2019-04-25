//
// Created by dejan on 26.5.17..
//
#pragma once
#include "Karta.h"
class Avion {
private:
    string naziv;
    int raspolozivBrojRedova;
    int duzinaSvakogReda;
    Karta ***matricaKarata;
public:
    Avion(string naziv, int raspolozivBrojRedova, int duzinaSvakogReda);
    bool daLiJeKartaSlobodna(Karta *karta);
    void zauzmiMesto(Karta *karta);
    void rezervisiMesto(Karta *karta);
    void ukupnaCenaKarataUAvionu();
    void ispisSvihKarataUAvionu();
    void glavniIspisAviona();
    bool validnosUneteKarte(Karta *karta);
    Karta* getAdresaPojedineKarte(Karta *karta);
    Karta** getRedKarata(int brojReda);
    int getDuzinaSvakogReda() const;
    bool validnosUnetogReda(int brojReda);
    void setujAvionNaNullptr();
};
//
// Created by dejan on 25.5.17..
//
#pragma once
#include <iostream>
#include "Knjiga.h"
using namespace std;
class Polica {
private:
    double sirinaPolice;
    Knjiga **knjigeZaRedjanjeNaPolicu;
    double slobodnogMestaNaPolici;
    int static brojKnjigaNaPolici;
public:
    Polica(double sirinaPolice);
    Polica(const Polica&);
    void dodajKnjiguNaPolicu(Knjiga *knjiga);
    bool daLiImaMestaNaPolici(Knjiga *knjiga);
    void dodavanjeKnjigeNaPraznuPolicu(Knjiga *knjiga);
    void dodavanjeKnjigeNaPolicuKojaVecSadrziKnjige(Knjiga *knjiga);
    static Knjiga** pravljenjeNiza(int duzinaNiza);
    void kopiranjeUPomocniNiz(Knjiga **pomocniNiz);
    void static brisanjeNiza(Knjiga **niz);
    void kopiranjeUOriginalniNiz(Knjiga **pomocniNiz);
    bool obrisiKnjiguSaPolice(int index);
    bool daLiIndexPremasujeOpseg(int index);
    void dodajKopijuKnjige(const Knjiga &);
    bool dodavanjeKnjigeNaOsnovuMestaNaPolici(Knjiga *knjiga);
    void ispisPolice();
    void menjanjeSirineSlobodnogProstoraNaPolici(double sirina);
};

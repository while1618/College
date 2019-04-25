//
// Created by dejan on 20.4.17..
//
#pragma once
#include "Pez.h"

const int kapacitet = 10;
class KutijaPeza {
private:
    Pez **nizKutija;
    int count;
public:
    //int getCount(){ return count};
    KutijaPeza();
    void dodajPez();
    Pez* uzmiPez();
    void unistiPez();
    void ispisi();
};

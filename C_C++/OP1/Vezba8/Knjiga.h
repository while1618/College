//
// Created by dejan on 4.5.17..
//
#pragma once

#include <iostream>
#include "List.h"

using namespace std;
class Knjiga {
private:
    string naziv;
    List **nizListova;
    int kapacitetKnjige;
public:
    Knjiga();
    Knjiga(string naziv, int kapacitetNiza);
    void dodajList(List *l);
    string getNazivKnige(){ return naziv; }
    int getKapacitetKnjige(){ return kapacitetKnjige; }
    void naknadnoDodajlist(List *l);
    List getList(int index);
    void ispisKnjige();
};

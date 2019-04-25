//
// Created by dejan on 4.5.17..
//
#pragma once

#include <iostream>
using namespace std;
class List {
private:
    int redniBroj;
    string tekst;
public:
    List();
    List(int redniBroj, string tekst);
    int getRedniBroj() { return redniBroj; }
    string getTekst() { return tekst; }
    void promeniTekst(string tekst);
    bool porediList(List *l);
    void nadoveziTekst(string tekst);
    void ispisLista();
};

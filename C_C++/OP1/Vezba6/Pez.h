//
// Created by dejan on 20.4.17..
//
#pragma once
#include<iostream>
using namespace std;
const string ukusi[] = {
        "jabuka", "malina", "pomorandza", "ananas"
};
class Pez {
private:
    static int brojac;
    int idPez;
    string ukus;
public:
    Pez();
    Pez(int redniBroj);
    void ispisi();
};

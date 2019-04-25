//
// Created by dejan on 26.5.17..
//
#pragma once
#include <iostream>
using namespace std;
class Karta {
private:
    int id;
    int static idBrojac;
    int brojReda;
    int brojSedistaURedu;
    double cenaKarte;
public:
    Karta();
    Karta(int brojReda, int brojSedistaURedu, double cenaKarte);
    int getBrojReda() const;
    int getBrojSedistaURedu() const;
    double getCenaKarte() const;
    void ispisKarte();
};
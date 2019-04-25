//
// Created by dejan on 27.4.17..
//
#pragma once

#include <iostream>
using namespace std;
class Slika {
private:
    int kataloskiBroj;
    string naziv;
    string autor;
    int godina;
    double cena;
    double duzina;
    double sirina;
public:
    Slika(int kataloskiBroj, string naziv, string autor, int godina, double cena, double duzina, double sirina);
    Slika();
    int getKataloskiBroj(){ return kataloskiBroj; }
    string getNaziv(){ return naziv; }
    string getAutor(){ return autor; }
    int getGodina(){ return godina; }
    double getCena(){ return cena; }
    double getDuzina(){ return duzina; }
    double getSirina(){ return sirina; }

    void setKataloskiBroj(int broj){ this->kataloskiBroj = broj; }
    void setNaziv(string naziv){ this-> naziv = naziv; }
    void setAutor(string autor){ this-> autor = autor; }
    void setGodina(int godina){ this-> godina = godina; }
    void setCena(double cena){ this-> cena = cena; }
    void setDuzina(double duzina){ this-> duzina = duzina; }
    void setSirina(double sirina){ this-> sirina = sirina; }

    void ispis();

};

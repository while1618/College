//
// Created by dejan on 26.5.17..
//

#include "Karta.h"

int Karta::idBrojac = 0;

Karta::Karta() {
    this->id = 0;
    this->brojReda = 0;
    this->brojSedistaURedu = 0;
    this->cenaKarte = 0;
}

Karta::Karta(int brojReda, int brojSedistaURedu, double cenaKarte) {
    this->id = idBrojac++;
    if(brojReda > 0) {
        this->brojReda = brojReda;
    } else {
        cout << "Niste uneli validnu kartu" << endl;
        exit(1);
    }
    if(brojSedistaURedu > 0) {
        this->brojSedistaURedu = brojSedistaURedu;
    } else {
        cout << "Niste uneli validnu kartu" << endl;
        exit(1);
    }
    if(cenaKarte > 0) {
        this->cenaKarte = cenaKarte;
    }else {
        cout << "Niste uneli validnu kartu" << endl;
        exit(1);
    }
}

int Karta::getBrojReda() const{
    return brojReda;
}

int Karta::getBrojSedistaURedu() const{
    return brojSedistaURedu;
}

double Karta::getCenaKarte() const{
    return cenaKarte;
}

void Karta::ispisKarte() {
    cout << "Karta:\nid: "<< this->id << "\nBroj reda: "<< this->brojReda << "\nBroj sedista u redu: ";
    cout << this->brojSedistaURedu << "\nCena karte: " << this->cenaKarte << endl << endl;
}
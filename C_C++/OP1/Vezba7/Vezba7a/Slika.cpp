//
// Created by dejan on 27.4.17..
//

#include "Slika.h"
#include <iostream>
using namespace std;

Slika::Slika(int kataloskiBroj, string naziv, string autor, int godina, double cena, double duzina, double sirina) {
    this->kataloskiBroj = kataloskiBroj;
    this->naziv = naziv;
    this->autor = autor;
    this->godina = godina;
    this->cena = cena;
    this->duzina = duzina;
    this->sirina = sirina;
}

Slika::Slika(){
    kataloskiBroj = 0;
    naziv = "";
    autor = "";
    godina = 0;
    cena = 0;
    duzina = 0;
    sirina = 0;
}

void Slika::ispis() {
    cout<<"Kataloski broj: "<<kataloskiBroj<<endl;
    cout<<"Naziv: "<<naziv<<endl;
    cout<<"Autor: "<<autor<<endl;
    cout<<"Godina: "<<godina<<endl;
    cout<<"Cena: "<<cena<<endl;
    cout<<"Duzina: "<<duzina<<endl;
    cout<<"Sirina: "<<sirina<<endl<<endl;
}
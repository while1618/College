//
// Created by dejan on 27.4.17..
//

#include "Broj.h"

Broj::Broj() {
    x = 46/15.0;
}

Broj::Broj(double x) {
    this->x = x;
}

void Broj::setBroj(double x) {
    this->x = x;
}

double Broj::getBroj() {
    return x;
}

double Broj::sabiranje(double broj) {
    return x+broj;
}

double Broj::oduzimanje(double broj) {
    return x-broj;
}

double Broj::mnozenje(double broj) {
    return x*broj;
}

double Broj::deljenje(double broj) {
    if(broj==0){
        cout<<"Nemoguce deliti sa nulom";
        return -1;
    }
    return x/broj;
}

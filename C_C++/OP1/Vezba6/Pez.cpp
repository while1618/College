//
// Created by dejan on 20.4.17..
//

#include "Pez.h"

Pez::Pez(){
    idPez = brojac++;
    ukus = ukusi[rand()%sizeof(ukusi)/sizeof(string)];
}

Pez::Pez(int redniBroj) {
    idPez = brojac++;
    ukus = ukusi[redniBroj];
}

void Pez::ispisi() {
    cout<<"Pez id:"<<idPez<<", ukus: "<<ukus<<endl;
}
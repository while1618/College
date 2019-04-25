//
// Created by dejan on 25.5.17..
//

#include "Knjiga.h"

int Knjiga::idBrojac = 1;

Knjiga::Knjiga() {
    this->idKnjige = idBrojac++;
    this->naslovKnjige = "";
    this->autorKnjige = "";
    this->sirinaKnjige = 0;
}

Knjiga::Knjiga(string naslovKnjige, string autorKnjige, double sirinaKnjige) {
    this->idKnjige = idBrojac++;
    this->naslovKnjige = naslovKnjige;
    this->autorKnjige = autorKnjige;
    this->sirinaKnjige = sirinaKnjige;
}

Knjiga::Knjiga(const Knjiga &kopija) :
          naslovKnjige(kopija.naslovKnjige),
          autorKnjige(kopija.autorKnjige),
          sirinaKnjige(kopija.sirinaKnjige) {
    this->idKnjige = idBrojac++;
}

void Knjiga::ispisKnjige() {
    //standardna ispis knjige sa podacima
    /*cout << "(" << idKnjige << ")" << naslovKnjige << " <=> "
         << autorKnjige << "{" << sirinaKnjige << "}" << endl;*/

    //ispis knjige na slikovit nacin
    for(int i = 0; i < sirinaKnjige; i++){
        cout << "#";
    }
}
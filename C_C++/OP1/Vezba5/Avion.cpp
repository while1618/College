//
// Created by dejan on 26.5.17..
//

#include "Avion.h"

Avion::Avion(string naziv, int raspolozivBrojRedova, int duzinaSvakogReda) {
    this->naziv = naziv;
    this->raspolozivBrojRedova = raspolozivBrojRedova;
    this->duzinaSvakogReda = duzinaSvakogReda;
    matricaKarata = new Karta**[raspolozivBrojRedova];
    for(int i = 0; i < raspolozivBrojRedova; i++){
        matricaKarata[i] = new Karta*[duzinaSvakogReda];
    }
}

void Avion::rezervisiMesto(Karta *karta) {
    if(this->validnosUneteKarte(karta)){
        if(this->daLiJeKartaSlobodna(karta)){
            this->zauzmiMesto(karta);
            cout << "Uspesno ste rezervisali mesto" << endl;
        } else {
            cout << "Mesto je vec zauzeto" << endl;
        }
    } else {
        cout << "Karta je van opsega aviona" << endl;
    }
}

bool Avion::validnosUneteKarte(Karta *karta) {
    if(karta->getBrojReda() > raspolozivBrojRedova || karta->getBrojSedistaURedu() > duzinaSvakogReda || karta == nullptr){
        return false;
    }
    return true;
}

bool Avion::daLiJeKartaSlobodna(Karta *karta) {
    if(matricaKarata[karta->getBrojReda() - 1][karta->getBrojSedistaURedu() - 1] != nullptr)
        return false;
    else
        return true;
}

void Avion::zauzmiMesto(Karta *karta) {
    matricaKarata[karta->getBrojReda() - 1][karta->getBrojSedistaURedu() - 1] = new Karta(*karta);
}

void Avion::ukupnaCenaKarataUAvionu() {
    double suma = 0;
    for(int i = 0; i < raspolozivBrojRedova; i++){
        for(int j = 0; j < duzinaSvakogReda; j++) {
            if(matricaKarata[i][j] != nullptr){
                suma += matricaKarata[i][j]->getCenaKarte();
            }
        }
    }
    cout << "Ukupna cena karata u avionu je: "<< suma << endl;
}

void Avion::ispisSvihKarataUAvionu() {
    for(int i = 0; i < raspolozivBrojRedova; i++){
        for(int j = 0; j < duzinaSvakogReda; j++) {
            if(matricaKarata[i][j] != nullptr){
                matricaKarata[i][j]->ispisKarte();
            }
        }
    }
}

void Avion::glavniIspisAviona() {
    cout << "Glavni ispis aviona: \n\n";
    for(int i = 0; i < raspolozivBrojRedova; i++){
        for(int j = 0; j < duzinaSvakogReda; j++) {
            if(matricaKarata[i][j] != nullptr){
                cout << "#";
            } else {
                cout << "_";
            }
        }
        cout << endl;
    }
}

bool Avion::validnosUnetogReda(int brojReda) {
    if(brojReda < 1 || brojReda > raspolozivBrojRedova){
        return false;
    } else {
        return true;
    }
}

Karta** Avion::getRedKarata(int brojReda) {
    if(this->validnosUnetogReda(brojReda)){
        return matricaKarata[brojReda - 1];
    } else{
        cout << "Niste uneli validan red" << endl;
        exit(0);
    }
}

Karta* Avion::getAdresaPojedineKarte(Karta *karta) {
    if(validnosUneteKarte(karta)){
        return matricaKarata[karta->getBrojReda() - 1][karta->getBrojSedistaURedu() - 1];
    } else{
        cout << "Uneli ste nepostojecu kartu" << endl;
        exit(0);
    }
}

int Avion::getDuzinaSvakogReda() const {
    return duzinaSvakogReda;
}

void Avion::setujAvionNaNullptr() {
    for(int i = 0; i < raspolozivBrojRedova; i++){
        for(int j = 0; j < duzinaSvakogReda; j++){
            matricaKarata[i][j] = nullptr;
        }
    }
}
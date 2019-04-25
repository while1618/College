//
// Created by dejan on 4.5.17..
//

#include "Knjiga.h"

Knjiga::Knjiga() {
    naziv = "";
    nizListova = nullptr;
}

Knjiga::Knjiga(string naziv, int kapacitetKnjige) {
    this->naziv = naziv;
    this->kapacitetKnjige = kapacitetKnjige;
    this->nizListova = new List*[kapacitetKnjige];
    for(int i = 0; i<kapacitetKnjige; i++){
        nizListova[i] = nullptr;
    }
}

void Knjiga::dodajList(List *l) {
    for(int i = 0; i<kapacitetKnjige; i++){
        if(nizListova[i] == nullptr){
            nizListova[i] = l;
            break;
        }
    }
}

List Knjiga::getList(int index) {
    if(index<0||index>kapacitetKnjige){
        cout<<"Index nije u granicama niza";
        exit(1);
    }
    for(int i = 0; i<kapacitetKnjige; i++){
        if(i == index){
            return *nizListova[i];
        }
    }
}

void Knjiga::naknadnoDodajlist(List *l) {
    for(int i = 0; i<kapacitetKnjige; i++){
        if(nizListova[i] != nullptr){
            if(nizListova[i]->getRedniBroj() == l->getRedniBroj()){
                nizListova[i] = l;
                return;
            }
        }
    }
    for(int i = 0; i<kapacitetKnjige; i++){
        if(nizListova[i] == nullptr){
            nizListova[i] = l;
            return;
        }
    }

    cout<<"Nema mesta u knjizi, i redni brojevi se ne poklapaju!";
}

void Knjiga::ispisKnjige(){
    cout<<naziv<<"\n\n";
    for(int i = 0; i<kapacitetKnjige; i++){
        if(nizListova[i] != nullptr){
            nizListova[i]->ispisLista();
        }
    }
}
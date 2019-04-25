//
// Created by dejan on 4.5.17..
//

#include "List.h"

List::List() {
    redniBroj = 0;
    tekst = "";
}

List::List(int redniBroj, string tekst) {
    this->redniBroj = redniBroj;
    this->tekst = tekst;
}

void List::promeniTekst(string tekst) {
    this->tekst = tekst;
}

void List::nadoveziTekst(string tekst) {
    this->tekst += tekst;
}

bool List::porediList(List *l) {
    if(this->redniBroj == l->redniBroj){
        return true;
    } else{
        return false;
    }
}

void List::ispisLista(){
    cout<<tekst<<"("<<redniBroj<<")"<<endl;
}
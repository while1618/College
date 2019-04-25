//
// Created by dejan on 25.5.17..
//

#include "Polica.h"

int Polica::brojKnjigaNaPolici = 0;

Polica::Polica(double sirinaPolice) {
    this->sirinaPolice = sirinaPolice;
    this->slobodnogMestaNaPolici = sirinaPolice;
}

Polica::Polica(const Polica &polica)
        : sirinaPolice(polica.sirinaPolice),
          slobodnogMestaNaPolici(polica.slobodnogMestaNaPolici)
        {}

void Polica::dodajKnjiguNaPolicu(Knjiga *knjiga) {
    if(this->dodavanjeKnjigeNaOsnovuMestaNaPolici(knjiga)){
        cout << "Uspesno dodata knjiga na policu!" << endl;
    } else {
        cout << "Nije moguce dodati knjigu!" << endl;
    }
}

bool Polica::dodavanjeKnjigeNaOsnovuMestaNaPolici(Knjiga *knjiga) {
    if(this->daLiImaMestaNaPolici(knjiga)){
        if(brojKnjigaNaPolici == 0){
            this->dodavanjeKnjigeNaPraznuPolicu(knjiga);
            return true;
        } else if(brojKnjigaNaPolici > 0){
            this->dodavanjeKnjigeNaPolicuKojaVecSadrziKnjige(knjiga);
            return true;
        } else {
            return false;
        }
    } else{
        return false;
    }
}

bool Polica::daLiImaMestaNaPolici(Knjiga *knjiga) {
    return (slobodnogMestaNaPolici - knjiga->getSirinaKnjige() < 0) ? false : true;
}

void Polica::dodavanjeKnjigeNaPraznuPolicu(Knjiga *knjiga) {
    knjigeZaRedjanjeNaPolicu = Polica::pravljenjeNiza(++brojKnjigaNaPolici);
    knjigeZaRedjanjeNaPolicu[0] = knjiga;
    double sirinaKnjige = knjiga->getSirinaKnjige();
    this->menjanjeSirineSlobodnogProstoraNaPolici(-sirinaKnjige);
}

void Polica::dodavanjeKnjigeNaPolicuKojaVecSadrziKnjige(Knjiga *knjiga) {
    Knjiga **pomocniNiz = Polica::pravljenjeNiza(++brojKnjigaNaPolici);
    this->kopiranjeUPomocniNiz(pomocniNiz);
    pomocniNiz[brojKnjigaNaPolici - 1] = knjiga;
    this->brisanjeNiza(knjigeZaRedjanjeNaPolicu);
    knjigeZaRedjanjeNaPolicu = Polica::pravljenjeNiza(brojKnjigaNaPolici);
    this->kopiranjeUOriginalniNiz(pomocniNiz);
    this->brisanjeNiza(pomocniNiz);
    double sirinaKnjige = knjiga->getSirinaKnjige();
    this->menjanjeSirineSlobodnogProstoraNaPolici(-sirinaKnjige);
}

void Polica::menjanjeSirineSlobodnogProstoraNaPolici(double sirinaKnjige) {
    slobodnogMestaNaPolici += sirinaKnjige;
}

Knjiga** Polica::pravljenjeNiza(int duzinaNiza) {
    Knjiga **pomocniNiz = new Knjiga*[duzinaNiza];
    return pomocniNiz;
}

void Polica::kopiranjeUPomocniNiz(Knjiga **pomocniNiz) {
    for(int i = 0; i<brojKnjigaNaPolici; i++){
        pomocniNiz[i] = knjigeZaRedjanjeNaPolicu[i];
    }
}

void Polica::brisanjeNiza(Knjiga **niz) {
    delete [] niz;
}

void Polica::kopiranjeUOriginalniNiz(Knjiga **pomocniNiz){
    for(int i = 0; i<brojKnjigaNaPolici; i++){
        knjigeZaRedjanjeNaPolicu[i] = pomocniNiz[i];
    }
}

void Polica::dodajKopijuKnjige(const Knjiga &knjiga) {
    Knjiga *kopijaKnjige = new Knjiga(knjiga);
    if(this->dodavanjeKnjigeNaOsnovuMestaNaPolici(kopijaKnjige)) {
        cout << "Uspesno dodata kopija knjige na policu!" << endl;
    } else {
        cout << "Nije moguce dodati kopiju knjige!" << endl;
    }
}

bool Polica::obrisiKnjiguSaPolice(int index) {
    if(this->daLiIndexPremasujeOpseg(index)){
        Knjiga **pomocniNiz = Polica::pravljenjeNiza(brojKnjigaNaPolici);
        this->kopiranjeUPomocniNiz(pomocniNiz);
        for(int i = 0; i<brojKnjigaNaPolici; i++){
            if(i == index){
                pomocniNiz[i] = nullptr;
                double sirina = knjigeZaRedjanjeNaPolicu[i]->getSirinaKnjige();
                this->menjanjeSirineSlobodnogProstoraNaPolici(sirina);
            }
        }
        Polica::brisanjeNiza(knjigeZaRedjanjeNaPolicu);
        knjigeZaRedjanjeNaPolicu = Polica::pravljenjeNiza(--brojKnjigaNaPolici);
        for (int i = 0, j = 0; i < brojKnjigaNaPolici + 1; i++) {
            if(pomocniNiz[i] != nullptr){
                knjigeZaRedjanjeNaPolicu[j++] = pomocniNiz[i];
            }
        }
        Polica::brisanjeNiza(pomocniNiz);
        return true;
    } else {
        return false;
    }
}

bool Polica::daLiIndexPremasujeOpseg(int index) {
    return (index >= 0 && index < brojKnjigaNaPolici) ? true : false;
}

void Polica::ispisPolice() {
    cout << "Polica:" << endl;
    for(int i = 0; i < brojKnjigaNaPolici; i++){
        knjigeZaRedjanjeNaPolicu[i]->ispisKnjige();
    }

    cout << endl;

    for(int i = 0; i < sirinaPolice; i++){
        cout << "-";
    }

    cout << endl;

}
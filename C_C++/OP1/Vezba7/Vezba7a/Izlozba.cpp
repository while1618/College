//
// Created by dejan on 28.4.17..
//

#include "Izlozba.h"
#include <iostream>
using namespace std;

Izlozba::Izlozba(Slika *nizSlika, int duzina, int brojSlika, int *nizKat)
    : KatalogMuzeja(nizSlika, duzina), brojSlika(brojSlika), nizKat(nizKat){

    this->brojSlika = brojSlika;
    this->nizKat = new int[brojSlika];
    for(int i = 0; i<brojSlika; i++){
        this->nizKat[i] = nizKat[i];
    }

    slikeZaIzlozbu = new Slika[brojSlika];

    for(int i = 0; i<brojSlika; i++){
        for(int j = 0; j<duzina; j++){
            if(nizKat[i] == nizSlika[j].getKataloskiBroj()){
                slikeZaIzlozbu[i] = nizSlika[j];
            }
        }
    }
}

void Izlozba::obrisi(int index) {

    if(index > brojSlika){
        cout<<"Unet je index koji ne postoji u nizu\n\n";
        return;
    }

    Slika *pomocniNiz = new Slika[brojSlika-1];

    for(int i = 0, j = 0; i<brojSlika; i++){
        if(index != i){
            pomocniNiz[j++] = slikeZaIzlozbu[i];
        }
    }

    delete[](slikeZaIzlozbu);
    slikeZaIzlozbu = new Slika[--brojSlika];

    for(int i = 0; i<brojSlika; i++){
        slikeZaIzlozbu[i] = pomocniNiz[i];
    }

    delete[](pomocniNiz);
}

void Izlozba::postavi(Slika slika, int index) {
    if(index > brojSlika){
        cout<<"Uneliste indeks koji prelazi kapacitet niza";
        return;
    }

    Slika *pomocniNiz = new Slika[brojSlika];
    for(int i = 0; i<brojSlika; i++){
        pomocniNiz[i] = slikeZaIzlozbu[i];
    }

    delete[](slikeZaIzlozbu);
    slikeZaIzlozbu = new Slika[++brojSlika];

    int j = 0;

    //dodaje slike jednu po jednu u niz, a ako se uneti index i i poklope
    //unosi unetu sliku na to mesto, a sl element i sve ostale posle njega
    //pomera za jedan

    //ovo nece raditi ako slika treba da se unese kao poslenji element niza
    //posto for petlja ide jedan el manje
    for(int i = 0; i<brojSlika - 1; i++){
        if(i == index){
            slikeZaIzlozbu[j++] = slika;
        }
        slikeZaIzlozbu[j++] = pomocniNiz[i];
    }

    //te stoga ova provera gde pita da li je j == broju slika u nizu umanjen za 1
    //tj da li fali jedna slika da se unese u niz
    //ako fali to je znak da fali slika koja je trebala biti uneta na zadato mesto
    //te se stoga postavlja na poslednje mesto u nizu jer nije nasla svoje mesto
    //na ostalim pozicijama
    if(j == brojSlika - 1){
        slikeZaIzlozbu[j] = slika;
    }

    delete[](pomocniNiz);
}

void Izlozba::ispisIzlozbe() {
    for(int i = 0; i<brojSlika; i++){
        slikeZaIzlozbu[i].ispis();
    }
}

#include <iostream>
#include "List.h"
#include "Knjiga.h"

int main() {
    List *l1 = new List(1, "Bla bla");
    List *l2 = new List(2, "Neki Tekst");
    List *l3 = new List(3, "hjooo");

    cout<<l1->porediList(l3);
    cout<<endl;

    l1->ispisLista();
    l2->ispisLista();

    l2->promeniTekst("Tekst Neki");

    l1->nadoveziTekst(" GNP");

    l1->ispisLista();
    l2->ispisLista();
    l3->ispisLista();

    Knjiga k1("Knjiga", 3);
    k1.dodajList(l1);
    k1.dodajList(l2);

    k1.ispisKnjige();

    //k1.dodajList(l3);
    k1.naknadnoDodajlist(l3);

    k1.ispisKnjige();

    return 0;
}
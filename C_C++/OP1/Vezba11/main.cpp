#include <iostream>
#include "Kompleks.h"

int main() {
    Kompleks kompleks1 = Kompleks(11, 12);
    Kompleks kompleks2 = Kompleks(1, 2);
    Kompleks resenje;
    Kompleks konjugovanoKompleksni;

    cout << "Kompleksni 1:" << endl;
    kompleks1.ispisKompleksongBroja();

    cout << "Kompleksni 2:" << endl;
    kompleks2.ispisKompleksongBroja();

    cout << "Konjugovano kompleksni broj 1:" << endl;
    konjugovanoKompleksni = kompleks1.konjugovanoKompleksniBroj();
    konjugovanoKompleksni.ispisKompleksongBroja();

    cout << "Apsolutna vrednost konjugovano kompleksnog broja:" << endl;
    cout << konjugovanoKompleksni.apsolutnaVrednostKopleksnogBroja() << endl;

    cout << "Sabiranje komplesnog broja 1 i 2:" << endl;
    resenje = kompleks1 * kompleks2;

    resenje.ispisKompleksongBroja();

    cout << "+= operator za komplesni broj 1:" << endl;
    kompleks1 += kompleks1;

    kompleks1.ispisKompleksongBroja();

    cout << "++ operator: " << endl;
    kompleks1++;

    kompleks1.ispisKompleksongBroja();

    return 0;
}
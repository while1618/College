#include <iostream>
#include "Broj.h"
#include "KompleksanBroj.h"

using namespace std;
int main() {
    Broj broj;

    broj.ispis();
    cout<<broj.sabiranje(10)<<endl<<endl;

    KompleksanBroj komp;

    komp.ispis();
    KompleksanBroj kom1 = komp.sabiranje(11, 12);
    KompleksanBroj kom2 = komp.oduzimanje(11, 12);
    KompleksanBroj kom3 = komp.mnozenje(11, 12);
    KompleksanBroj kom4 = komp.deljenje(11, 12);

    cout<<"sabiranje: "; kom1.ispis(); cout<<endl;
    cout<<"oduzimanje: ";kom2.ispis(); cout<<endl;
    cout<<"mnozenje: ";kom3.ispis(); cout<<endl;
    cout<<"deljenje: ";kom4.ispis(); cout<<endl;

    return 0;
}
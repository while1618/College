#include <iostream>
#include "Slika.h"
#include "KatalogMuzeja.h"
#include "Izlozba.h"

int main() {

    Slika nizSlika[] = {
            Slika(1, "Nocna straza", "Rembrant", 1941, 21321, 12, 32),
            Slika(2, "Monaliza", "DaVinci", 1456, 121242, 45, 12),
            Slika(3, "Tajna Vecera", "DaVinci", 1400, 124124, 51, 32)
    };

    Slika s2 = Slika(2, "Monaliza", "DaVinci", 1456, 121242, 45, 12);

    int duzina = sizeof(nizSlika)/sizeof(*nizSlika);
    KatalogMuzeja katalog(nizSlika, duzina);

    //cout << "Katalog pri inicijalizaciji:" << endl;
    //katalog.ispisMuzej();

    //katalog.postavi(s3);
    //cout << "Katalog posle dodavanja:" << endl;
    //katalog.ispisMuzej();

    int niz[] = {1, 3};
    Izlozba i = Izlozba(nizSlika, duzina, 2, niz);

    //i.ispisIzlozbe();
    i.postavi(s2, 1);
    i.ispisIzlozbe();

    return 0;
}
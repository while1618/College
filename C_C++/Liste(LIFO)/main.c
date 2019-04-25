#include <stdio.h>
#include <stdlib.h>

typedef struct Element{
    int podatak;
    struct Element* sledeci;
} Element;

void ispisiListu(Element *element);
void ispisiListuRekurzivno(Element *element);
void ispisElemenataVeciOdAritmetickeSredineParnih(Element *element, double aritmetickaSredina);
float aritmetickaSredinaParnihElemenata(Element *element);

int main() {
    Element *pocetakListe, *novi;
    pocetakListe = NULL;
    int broj;
    printf("Unesite podatke: \n");
    fflush(stdin);

    while (scanf("%d", &broj)){
        if(broj == 0){
            break;
        }
        novi = (Element*)malloc(sizeof(Element));
        novi->podatak = broj;
        novi->sledeci = pocetakListe;
        pocetakListe = novi;
    }

    printf("Sadrzaj liste je: \n");
    //ispisiListu(pocetakListe);
    //ispisiListuRekurzivno(pocetakListe);
    float aritmetickaSredina = aritmetickaSredinaParnihElemenata(pocetakListe);
    ispisElemenataVeciOdAritmetickeSredineParnih(pocetakListe, aritmetickaSredina);
    return 0;
}

void ispisiListu(Element *element){
    while(element != NULL){
        printf(" : %d \n", element->podatak);
        element = element->sledeci;
    }
}

void ispisElemenataVeciOdAritmetickeSredineParnih(Element *element, double aritmetickaSredina){
    while(element != NULL){
        if(element->podatak > aritmetickaSredina){
            printf(" : %d \n", element->podatak);
            element = element->sledeci;
        }
    }
}

float aritmetickaSredinaParnihElemenata(Element *element){
    int brojac = 0;
    int suma = 0;
    while (element != NULL){
        if(element->podatak % 2 == 0){
            suma += element->podatak;
            ++brojac;
        }
        element = element->sledeci;
    }
    return (float)suma/brojac;
}

void ispisiListuRekurzivno(Element *element){
    if(element == NULL){
        return;
    }

    printf("-> %d \n", element->podatak);
    ispisiListuRekurzivno(element->sledeci);

}

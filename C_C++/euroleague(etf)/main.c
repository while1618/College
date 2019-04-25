#include <stdio.h>
#define MAX 20

int kosRazlika[4];   //globalna promenljiva niz intidzera za smestanje kos razlike(globalna da bi se videla i u main-u i u funkcijama)
int bodovi[4];       //globalna pormenljiva niz intidzera za smestanje bodova

//deklaracija funkcije utakmica kojoj se predaju 4 parametra(2 pokazivaca na char(imena ekipa) i 2 intidzera(index ekipe))
int utakmica(char* tim1, char* tim2, int index1, int index2);

//deklaracija funkcije razlika kojoj se predaju 2 parametra(2 intidzera koja sadrze rezultat upravo odigrane utakmice)
int razlika(int rezultat1, int rezultat2);

int main() {
    char tim[4][MAX];   //niz karaktera u koji se smestaju imena ekipa
    int porazeni1, porazeni2, cetvrti, drugi;  //promenljive u kojima se smesteni indexi ekipa

    //unos imena ekipa
    printf("Unesite ekipe koje ucestvuju na final four-u:\n");
    for (int i = 0; i < 4; i++) {
        gets(tim[i]);
    }

    printf("Utakmica prvog polufinala:\n");
    //pozivom funkcije utakmica dobijamo prvog finalistu(index ekipe koja je pobedila smesten u promenljivu finalista1)
    int finalista1 = utakmica(tim[0], tim[1], 0, 1);   //funkciji predajemo prve dve ekipe i njihove indexe
    //u promenljivu porazeni1 smestamo gubitnika utakmice
    if(finalista1 == 0){
        porazeni1 = 1;
    }
    else{
        porazeni1 = 0;
    }

    printf("Utakmica drugog polufinala:\n");
    //pozivom funkcije utakmica dobijamo drugog finalistu(index ekipe koja je pobedila smesten u promenljivu finalista2)
    int finalista2 = utakmica(tim[2], tim[3], 2, 3);   //funkciji predajemo druge dve ekipe i njihove indexe
    //u promenljivu porazeni2 smestamo gubitnika utakmice
    if(finalista2 == 2){
        porazeni2 = 3;
    }
    else{
        porazeni2 = 2;
    }

    printf("Utakmica za trece mesto:\n");
    //pozivom funkcije utakmica dobijamo ekipu koja je osvojila trece mesto(index ekipe koja je pobedila smesten u promenljivu treci)
    int treci = utakmica(tim[porazeni1], tim[porazeni2], porazeni1, porazeni2);    //funkciji predajemo porazene ekipe iz prve dve utakmice i njihove indexe
    //u promenljivu cetvrti smestamo porazenog iz duela za trece mesto
    if(treci == porazeni1){
        cetvrti = porazeni2;
    }
    else{
        cetvrti = porazeni1;
    }

    printf("Finalna utakmica:\n");
    //pozivom funkcije utakmica dobijamo ekipu koja je osvojila prvo esto(index ekipe koja je pobedila smesten u promenljivu prvi)
    int prvi = utakmica(tim[finalista1], tim[finalista2], finalista1, finalista2);  //funkciji predajemo pobednike prve dve utakmice i njihove indexe
    //u promenljivu treci smestamo porazenog iz finalnog duela
    if(prvi == finalista1){
        drugi = finalista2;
    }
    else{
        drugi = finalista1;
    }

    //ispis konacnog redosleda ekipa
    printf("******** Konacan redosled timova ********\n");
    printf("Mesto\tEkipa\t\t\t\tRazlika\t\tBodovi\n");
    printf("1.\t\t%s\t\t\t%d\t\t\t%d\n", tim[prvi], kosRazlika[prvi], bodovi[prvi]);
    printf("2.\t\t%s\t\t\t%d\t\t\t%d\n", tim[drugi], kosRazlika[drugi], bodovi[drugi]);
    printf("3.\t\t%s\t\t\t%d\t\t\t%d\n", tim[treci], kosRazlika[treci], bodovi[treci]);
    printf("4.\t\t%s\t\t\t%d\t\t\t%d\n", tim[cetvrti], kosRazlika[cetvrti], bodovi[cetvrti]);

    return 0;
}

//unos poena za zadatu utakmicu
int utakmica(char* tim1, char* tim2, int index1, int index2){
    int rezultat1, rezultat2;
    //ponavlja se unos dokle god je neispravan(poeni manji od 0 ili rezultat neresen)
    printf("Unesite rezultat utakmice izmedju %s i %s:\n", tim1, tim2);
    do{
        scanf("%d", &rezultat1);
        scanf("%d", &rezultat2);
    }while(rezultat1<0 || rezultat2<0 || rezultat1 == rezultat2);

    //na trenutnu kos razliku ekipe se dodaje kos razlika upravo odigrane utakmice
    kosRazlika[index1] += razlika(rezultat1, rezultat2);
    kosRazlika[index2] += razlika(rezultat2, rezultat1);

    //ako je pobedila ekipa jedan funkcija vraca index ekipe koja je pobedila
    if(rezultat1>rezultat2){
        //dodaju se bodovi(po pravilima ekipa koja pobedi dobija 2 boda, a ekipa koja izgubi 1)
        bodovi[index1]+=2;
        bodovi[index2]++;
        return index1;
    }
    //isto radi samo za slucaj kada pobedi ekipa dva
    else{
        bodovi[index2]+=2;
        bodovi[index1]++;
        return index2;
    }

}

//racuna razliku koseva ekipe(broj postignutih poena na utakmici - broj primljenih)
int razlika(int rezultat1, int rezultat2){
    int razlika = rezultat1 - rezultat2;
    return razlika;
}


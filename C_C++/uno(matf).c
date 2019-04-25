#define _CRT_SECURE_NO_WARNINGS
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define MAX 5
#define MAX2 51
//nisam siguran za ovo, al koliko sam ja shvatio treba da se unese u struct samo broj i znak karata koje ima pera
//aa ne svih karata u spilu, aa i to bi bilo glupavo da se radi, nema nikakvu poentu
struct karte{
	char znak[MAX + 1];
	int broj;
};
int main(){
	struct karte *karta;
	int n, i, provera = 0, broj, br = 0;
	char znak[MAX + 1];

	do{
		printf("\nKoliko karata ima Pera?\n");
		scanf("%d", &n);
	} while (n<1 || n>MAX2);
	fflush(stdin);  //brisanje zaostalih karaktera

	//dinamicka dodela za strukturu
	if ((karta = malloc(n*sizeof(struct karte))) == NULL){
		printf("\nGreska pri dodeli memorije\n");
		exit(1);
	}
	printf("\nUnesite %d karata koje ima Pera:(znak pa broj)\n", n);
	for (i = 0; i < n; i++){
		scanf("%s", &karta[i].znak);
		//ako je pogresno unet znak promenljiva se setuje na 1
		if ((strcmp(karta[i].znak, "tref") != 0) && (strcmp(karta[i].znak, "karo") != 0) && (strcmp(karta[i].znak, "pik") != 0) && (strcmp(karta[i].znak, "herc") != 0)){
			provera = 1;
		}
		scanf("%d", &karta[i].broj);
		//ako je pogresno unet broj promenljiva se setuje na 1
		if (karta[i].broj<1 || karta[i].broj>14 || karta[i].broj==11){
			provera = 1;
		}
		fflush(stdin);  //brisanje zaostalih karaktera
	}
	//ispis perinih karata
	printf("\nPerine karte:\n");
	for (i = 0; i < n; i++){
		printf("%s %d\n", karta[i].znak, karta[i].broj);
	}

	//unos karte koja je na stolu
	printf("\nUnesite kartu koja je na stolu:(znak pa broj)\n");
	scanf("%s", &znak);
	if ((strcmp(znak, "tref") != 0) && (strcmp(znak, "karo") != 0) && (strcmp(znak, "pik") != 0) && (strcmp(znak, "herc") != 0)){
		provera = 1;
	}
	scanf("%d", &broj);
	if (broj<1 || broj>14 || broj==11){
		provera = 1;
	}

	//ako je neka od karata uneta pogresno program se prekida i ispisuje -1
	if (provera == 1){
		printf("\n -1\n");
		exit(1);
	}

	//provera koje karte moze pera da odigra
	printf("\nPera moze da odigra sledece karte:\n");
	for (i = 0; i < n; i++){
		if ((strcmp(karta[i].znak, znak) == 0) || karta[i].broj == broj){
			printf("%s %d\n", karta[i].znak, karta[i].broj);
			br++;
		}
	}
	//ako ne postoji karta koju moze da odigra ispis poruke
	if (br == 0){
		printf("\nPera nema raspolozivih karata!\n");
	}

	//oslobadjanje dinamicke memorije za strukturu
	free(karta);
	return 0;
}
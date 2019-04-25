//
// Created by dejan on 20.4.17..
//

#include "KutijaPeza.h"
#include <iostream>
using namespace std;

KutijaPeza::KutijaPeza() {
    count = kapacitet;
    nizKutija = new Pez* [kapacitet];
    for(int i = 0; i<count; i++){
        nizKutija[i] = new Pez;
    }
}

void KutijaPeza::dodajPez() {
    if(count == kapacitet){
        cout<<"Nemoguce dodati pez, kutija je puna!";
        exit(1);
    }
    else{
        nizKutija[count] = new Pez;
        count++;
    }
}

Pez* KutijaPeza::uzmiPez() {
    return nizKutija[count - 1];
}

void KutijaPeza::unistiPez() {
    delete nizKutija[count-1];
    count--;
}

void KutijaPeza::ispisi(){
    cout<<"Kutija:\n";
    for(int i = 0; i<count; i++){
        nizKutija[i]->ispisi();
    }
}
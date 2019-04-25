//
// Created by dejan on 27.4.17..
//

#include "KompleksanBroj.h"
#include <iostream>
#include <math.h>
using namespace std;

KompleksanBroj::KompleksanBroj() {
    this->x = 46/15.0;
    this->y = 15.0/46;
}

KompleksanBroj::KompleksanBroj(double x, double y) {
    this->x = x;
    this->y = y;
}

KompleksanBroj KompleksanBroj::sabiranje(double real, double imag) {
    return KompleksanBroj(x+real, y+imag);
}

KompleksanBroj KompleksanBroj::oduzimanje(double real, double imag) {
    return KompleksanBroj(x-real, y-imag);
}

KompleksanBroj KompleksanBroj::mnozenje(double real, double imag) {
    return KompleksanBroj((x * real - y * imag), (x * imag + y * real));
}

KompleksanBroj KompleksanBroj::deljenje(double real, double imag) {
    double realan = (x * real - y * imag) / pow(real, 2) + pow(imag, 2);
    double imaginaran = (x * imag + y * real) / pow(real, 2) + pow(imag, 2);
    return KompleksanBroj(realan, imaginaran);
}

double KompleksanBroj::getReal() {
    return x;
}

double KompleksanBroj::getImag() {
    return y;
}

void KompleksanBroj::setReal(double x) {
    this-> x = x;
}

void KompleksanBroj::setImag(double y) {
    this->y = y;
}

void KompleksanBroj::ispis() {
        if(y == 0){
            cout<<x<<endl;
        }
        else if(x == 0){
            cout<<y<<"i"<<endl;
        }
        else if(y > 0){
            cout<<x<<" + "<<y<<"i"<<endl;
        }
        else if(y < 0){
            cout<<x<<" - "<<y*-1<<"i"<<endl;
        }
}

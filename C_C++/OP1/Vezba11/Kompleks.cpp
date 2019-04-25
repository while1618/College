//
// Created by dejan on 1.6.17..
//

#include <cmath>
#include "Kompleks.h"

Kompleks::Kompleks() {
    this->real = 0;
    this->imag = 0;
}

Kompleks::Kompleks(double real, double imag) {
    this->real = real;
    this->imag = imag;
}

double Kompleks::apsolutnaVrednostKopleksnogBroja() {
    return abs(sqrt(pow(real, 2) + pow(imag, 2)));
}

Kompleks Kompleks::konjugovanoKompleksniBroj() {
    return Kompleks(this->real, -this->imag);
}

Kompleks Kompleks::operator+(Kompleks kompleks) {
    return Kompleks(this->real + kompleks.real, this->imag + kompleks.imag);
}

Kompleks Kompleks::operator-(Kompleks kompleks) {
    return Kompleks(this->real - kompleks.real, this->imag - kompleks.imag);
}

Kompleks Kompleks::operator*(Kompleks kompleks) {
    double realan, imaginaran;
    realan = (this->real * kompleks.real - this->imag * kompleks.imag);
    imaginaran = (this->real * kompleks.imag + this->imag * kompleks.real);
    return Kompleks(realan, imaginaran);
}

Kompleks& Kompleks::operator+=(Kompleks kompleks) {
    this->real += kompleks.real;
    this->imag += kompleks.imag;
    return *this;
}

Kompleks& Kompleks::operator-=(Kompleks kompleks) {
    this->real -= kompleks.real;
    this->imag -= kompleks.imag;
    return *this;
}

Kompleks& Kompleks::operator*=(Kompleks kompleks) {
    this->real *= kompleks.real;
    this->imag *= kompleks.imag;
    return *this;
}

Kompleks& Kompleks::operator++() {
    ++this->real;
    return *this;
}

Kompleks& Kompleks::operator--() {
    --this->real;
    return *this;
}

Kompleks Kompleks::operator--(int) {
    return Kompleks(--this->real, this->imag);
}

Kompleks Kompleks::operator++(int) {
    return Kompleks(++this->real, this->imag);
}

void Kompleks::ispisKompleksongBroja() {
    if(imag == 0){
        cout<<real<<endl;
    }
    else if(real == 0){
        cout<<imag<<"i"<<endl;
    }
    else if(imag > 0){
        cout<<real<<" + "<<imag<<"i"<<endl;
    }
    else if(imag < 0){
        cout<<real<<" - "<<imag*-1<<"i"<<endl;
    }
}

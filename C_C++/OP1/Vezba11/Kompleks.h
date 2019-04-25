//
// Created by dejan on 1.6.17..
//
#pragma once
#include <iostream>
using namespace std;
class Kompleks {
private:
    double real;
    double imag;
public:
    Kompleks();
    Kompleks(double real, double imag);
    double getReal(){
        return real;
    }
    double getImag(){
        return imag;
    }
    double apsolutnaVrednostKopleksnogBroja();
    Kompleks konjugovanoKompleksniBroj();
    Kompleks operator+(Kompleks);
    Kompleks operator-(Kompleks);
    Kompleks operator*(Kompleks);
    Kompleks& operator+=(Kompleks);
    Kompleks& operator-=(Kompleks);
    Kompleks& operator*=(Kompleks);
    Kompleks operator++(int);
    Kompleks operator--(int);
    Kompleks& operator++();
    Kompleks& operator--();
    void ispisKompleksongBroja();
};

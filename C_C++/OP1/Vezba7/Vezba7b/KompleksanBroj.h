//
// Created by dejan on 27.4.17..
//
#pragma once

#include "Broj.h"

class KompleksanBroj : public Broj{
private:
    double y;
public:
    KompleksanBroj();
    KompleksanBroj(double x, double y);
    void setReal(double x);
    void setImag(double y);
    double getReal();
    double getImag();
    KompleksanBroj sabiranje(double real = 0, double imag = 0);
    KompleksanBroj oduzimanje(double real = 0, double imag = 0);
    KompleksanBroj mnozenje(double real = 1, double imag = 1);
    KompleksanBroj deljenje(double real = 1, double imag = 1);
    void ispis();
};

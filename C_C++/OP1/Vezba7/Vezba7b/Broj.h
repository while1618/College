//
// Created by dejan on 27.4.17..
//
#pragma once

#include <iostream>
using namespace std;
class Broj {
protected:
    double x;
public:
    Broj();
    Broj(double x);
    void setBroj(double x);
    double getBroj();
    double sabiranje(double broj = 0);
    double oduzimanje(double broj = 0);
    double mnozenje(double broj = 1);
    double deljenje(double broj = 1);
    virtual void ispis(){
        cout<<"Broj: "<<x<<endl;
    }
};



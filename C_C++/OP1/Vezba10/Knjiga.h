//
// Created by dejan on 25.5.17..
//
#pragma once
#include <iostream>
using namespace std;
class Knjiga {
private:
    static int idBrojac;
    int idKnjige;
    string naslovKnjige;
    string autorKnjige;
    double sirinaKnjige;
public:
    Knjiga();
    Knjiga(string naslovKnjige, string autorKnjige, double sirinaKnjige);
    Knjiga(const Knjiga &);
    int getIdKnjige(){
        return idKnjige;
    }
    double getSirinaKnjige(){
        return sirinaKnjige;
    }
    void ispisKnjige();
};

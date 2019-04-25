//
// Created by dejan on 1.6.17..
//
#pragma once

#include "Kompleks.h"

class NizKompleksnih {
private:
    Kompleks *nizKompleksnihBrojeva;
    int duzinaNiza;
public:
    NizKompleksnih();
    NizKompleksnih(Kompleks *nizKompleksnihBrojeva, int duzinaNiza);
    NizKompleksnih(const Kompleks& kopijaNizaKompleksnihBrojeva);
};

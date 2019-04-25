//
// Created by dejan on 1.6.17..
//

#include "NizKompleksnih.h"

NizKompleksnih::NizKompleksnih() {
    nizKompleksnihBrojeva = new Kompleks[10];
}

NizKompleksnih::NizKompleksnih(Kompleks *nizKompleksnihBrojeva, int duzinaNiza) {
    this->duzinaNiza = duzinaNiza;
    nizKompleksnihBrojeva = new Kompleks[duzinaNiza];
    for(int i = 0; i < duzinaNiza; i++){
        this->nizKompleksnihBrojeva[i] = nizKompleksnihBrojeva[i];
    }
}

NizKompleksnih::NizKompleksnih(const Kompleks &kopijaNizaKompleksnihBrojeva)
: nizKompleksnihBrojeva(kopijaNizaKompleksnihBrojeva){}
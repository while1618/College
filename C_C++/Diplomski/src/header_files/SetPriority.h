#pragma once
#include <iostream>
#include <unistd.h>
#include <sys/wait.h>
#include <sys/resource.h>
#include <fcntl.h>
#define NUMBER_OF_PROCESSES 10
using namespace std;

class SetPriority {
private:
    static int* setPriority(char*** arg);
    static int spawn(char **arg);
public:
    static int *getPriority();
};
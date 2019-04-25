#pragma once
#include <time.h>
#include <iostream>
#include <unistd.h>
#include <sys/wait.h>
#include <fcntl.h>
#include <sys/resource.h>
#define NUMBER_OF_PROCESSES 10
#define NUMBER_OF_PROCESS_EXECUTION 20
using namespace std;

class BurstTime {
private:
    static double** whenProcessEnd(char ***processes);
    static double calculateBurstTime(double *timeWhenProcessIsOver);
    static void spawn(char **arg);
public:
    static double* getBurstTime();
};
#pragma once
#include <iostream>
#include <iomanip>
#define NUMBER_OF_PROCESSES 10
using namespace std;

class ScheduleProcess {
protected:
    double *burstTime;
    double *waitingTime;
    double *turnaroundTime;
    double *copyOfBurstTime;
    int *processID;
    double averageWaitingTime;
    double averageTurnaroundTime;

    virtual void allocateMemory();
    void setParameters();
    virtual void makeCopiesAndProcessesID();
    void calculateWaitingAndTurnaroundTime();
    void printWaitingAndTurnaroundTimeForProcesses(string whichAlgorithm);
    void calculateAverageWaitingAndTurnaroundTime(int i);
    void printAverageWaitingAndTurnaroundTime();
    virtual void deallocateMemory();
public:
    explicit ScheduleProcess(double *burstTime);
    virtual void start();
};

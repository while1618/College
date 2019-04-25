#include "../header_files/FirstComeFirstServed.h"

void FirstComeFirstServed::start() {
    makeCopiesAndProcessesID();
    calculateWaitingAndTurnaroundTime();
    printWaitingAndTurnaroundTimeForProcesses("\n\nFirst come first serve:\n");
    printAverageWaitingAndTurnaroundTime();
    deallocateMemory();
}

void FirstComeFirstServed::allocateMemory() {
    this->processID = new int[NUMBER_OF_PROCESSES];
    this->waitingTime = new double[NUMBER_OF_PROCESSES];
    this->turnaroundTime = new double[NUMBER_OF_PROCESSES];
    this->copyOfBurstTime = new double[NUMBER_OF_PROCESSES];
}

void FirstComeFirstServed::deallocateMemory() {
    delete[] this->processID;
    delete[] this->waitingTime;
    delete[] this->turnaroundTime;
    delete[] this->copyOfBurstTime;
}

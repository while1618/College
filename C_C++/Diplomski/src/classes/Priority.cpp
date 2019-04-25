#include "../header_files/Priority.h"

void Priority::start() {
    makeCopiesAndProcessesID();
    sortProcessesByPriority();
    calculateWaitingAndTurnaroundTime();
    printWaitingAndTurnaroundTimeForProcesses("\n\nPriority:\n");
    printAverageWaitingAndTurnaroundTime();
    deallocateMemory();
}

void Priority::makeCopiesAndProcessesID() {
    for (int i = 0; i < NUMBER_OF_PROCESSES; i++) {
        this->copyOfBurstTime[i] = this->burstTime[i];
        this->copyPriority[i] = this->priority[i];
        this->processID[i] = i + 1;
    }
}

void Priority::allocateMemory() {
    this->processID = new int[NUMBER_OF_PROCESSES];
    this->waitingTime = new double[NUMBER_OF_PROCESSES];
    this->turnaroundTime = new double[NUMBER_OF_PROCESSES];
    this->copyOfBurstTime = new double[NUMBER_OF_PROCESSES];
    this->copyPriority = new int[NUMBER_OF_PROCESSES];
}

void Priority::sortProcessesByPriority() {
    for (int i = 0; i < NUMBER_OF_PROCESSES - 1; i++) {
        for (int j = i + 1; j < NUMBER_OF_PROCESSES; j++) {
            if (this->copyPriority[i] > this->copyPriority[j]) {
                swapBurstTime(i, j);
                swapIDs(i, j);
                swapPriority(i, j);
            }
        }
    }
}

void Priority::swapBurstTime(int i, int j) {
    double temp;

    temp = this->copyOfBurstTime[i];
    this->copyOfBurstTime[i] = this->copyOfBurstTime[j];
    this->copyOfBurstTime[j] = temp;
}

void Priority::swapIDs(int i, int j) {
    int temp;

    temp = this->processID[i];
    this->processID[i] = this->processID[j];
    this->processID[j] = temp;
}

void Priority::swapPriority(int i, int j) {
    int temp;

    temp = this->copyPriority[i];
    this->copyPriority[i] = this->copyPriority[j];
    this->copyPriority[j] = temp;
}

void Priority::deallocateMemory() {
    delete[] this->processID;
    delete[] this->copyOfBurstTime;
    delete[] this->waitingTime;
    delete[] this->turnaroundTime;
    delete[] this->copyPriority;
}

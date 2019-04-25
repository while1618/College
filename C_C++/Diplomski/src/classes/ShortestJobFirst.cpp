#include "../header_files/ShortestJobFirst.h"

void ShortestJobFirst::start() {
    makeCopiesAndProcessesID();
    sortProcessesByBurstTime();
    calculateWaitingAndTurnaroundTime();
    printWaitingAndTurnaroundTimeForProcesses("\n\nShortest Job First:\n");
    printAverageWaitingAndTurnaroundTime();
    deallocateMemory();
}

void ShortestJobFirst::allocateMemory() {
    this->processID = new int[NUMBER_OF_PROCESSES];
    this->waitingTime = new double[NUMBER_OF_PROCESSES];
    this->turnaroundTime = new double[NUMBER_OF_PROCESSES];
    this->copyOfBurstTime = new double[NUMBER_OF_PROCESSES];
}

void ShortestJobFirst::sortProcessesByBurstTime() {
    for (int i = 0; i < NUMBER_OF_PROCESSES - 1; i++) {
        for (int j = i + 1; j < NUMBER_OF_PROCESSES; j++) {
            if (this->copyOfBurstTime[i] > this->copyOfBurstTime[j]) {
                swapBurstTime(i, j);
                swapIndexes(i, j);
            }
        }
    }
}

void ShortestJobFirst::swapBurstTime(int i, int j) {
    double temp;

    temp = this->copyOfBurstTime[i];
    this->copyOfBurstTime[i] = this->copyOfBurstTime[j];
    this->copyOfBurstTime[j] = temp;
}

void ShortestJobFirst::swapIndexes(int i, int j) {
    int temp;

    temp = this->processID[i];
    this->processID[i] = this->processID[j];
    this->processID[j] = temp;
}

void ShortestJobFirst::deallocateMemory() {
    delete[] this->processID;
    delete[] this->waitingTime;
    delete[] this->turnaroundTime;
    delete[] this->copyOfBurstTime;
}

#include "../header_files/ScheduleProcess.h"

ScheduleProcess::ScheduleProcess(double *burstTime) {
    this->burstTime = burstTime;
}

void ScheduleProcess::start() {}

void ScheduleProcess::allocateMemory() {}

void ScheduleProcess::setParameters() {
    this->averageWaitingTime = 0;
    this->averageTurnaroundTime = 0;
    this->waitingTime[0] = 0;
    this->turnaroundTime[0] = this->burstTime[0];
}

void ScheduleProcess::makeCopiesAndProcessesID() {
    for (int i = 0; i < NUMBER_OF_PROCESSES; i++) {
        this->copyOfBurstTime[i] = this->burstTime[i];
        this->processID[i] = i + 1;
    }
}

void ScheduleProcess::calculateWaitingAndTurnaroundTime() {
    for (int i = 1; i < NUMBER_OF_PROCESSES; i++) {
        this->waitingTime[i] = this->copyOfBurstTime[i - 1] + this->waitingTime[i - 1];
        this->turnaroundTime[i] = this->copyOfBurstTime[i] + this->turnaroundTime[i - 1];
    }
}

void ScheduleProcess::printWaitingAndTurnaroundTimeForProcesses(string whichAlgorithm) {
    cout << whichAlgorithm;
    cout << "\nProcess\t\tBurst Time\t\tWaiting Time\t\tTurnaround Time" << endl;
    for (int i = 0; i < NUMBER_OF_PROCESSES; i++) {
        cout << setprecision(0) << "P[" << this->processID[i] << setprecision(8) << fixed << "]\t\t" << this->copyOfBurstTime[i]
             << "\t\t" << this->waitingTime[i] << "\t\t\t" << this->turnaroundTime[i] << "\n";
        calculateAverageWaitingAndTurnaroundTime(i);
    }
}

void ScheduleProcess::calculateAverageWaitingAndTurnaroundTime(int i) {
    this->averageWaitingTime += this->waitingTime[i];
    this->averageTurnaroundTime += this->turnaroundTime[i];
}

void ScheduleProcess::printAverageWaitingAndTurnaroundTime() {
    cout << "\nAverage Waiting Time: " << this->averageWaitingTime / NUMBER_OF_PROCESSES << endl;
    cout << "Average Turnaround Time: " << this->averageTurnaroundTime / NUMBER_OF_PROCESSES << endl;
}

void ScheduleProcess::deallocateMemory() {}

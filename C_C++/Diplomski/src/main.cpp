#include <iostream>
#include "header_files/ShortestJobFirst.h"
#include "header_files/FirstComeFirstServed.h"
#include "header_files/BurstTime.h"
#include "header_files/Priority.h"
#include "header_files/SetPriority.h"

using namespace std;

int main() {
    double *burstTime = BurstTime::getBurstTime();
    auto *shortestJobFirst = new ShortestJobFirst(burstTime);
    auto *firstComeFirstServed = new FirstComeFirstServed(burstTime);
    auto *priority = new Priority(burstTime, SetPriority::getPriority());

    shortestJobFirst->start();
    firstComeFirstServed->start();
    priority->start();

    return 0;
}
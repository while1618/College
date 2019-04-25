#include "ScheduleProcess.h"

class FirstComeFirstServed : ScheduleProcess {
private:
    void allocateMemory();
    void deallocateMemory();
public:
    explicit FirstComeFirstServed(double *burstTime) : ScheduleProcess(burstTime) {
        allocateMemory();
        setParameters();
    };
    void start();
};

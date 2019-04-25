#include "ScheduleProcess.h"
class Priority : public ScheduleProcess {
private:
    int *copyPriority;
    int *priority;

    void makeCopiesAndProcessesID();
    void allocateMemory();
    void sortProcessesByPriority();
    void swapBurstTime(int i, int j);
    void swapIDs(int i, int j);
    void swapPriority(int i, int j);
    void deallocateMemory();
public:
    Priority(double *burstTime, int *priority) : ScheduleProcess(burstTime) {
        this->priority = priority;
        allocateMemory();
        setParameters();
    };
    void start();
};


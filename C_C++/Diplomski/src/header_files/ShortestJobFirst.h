#include "ScheduleProcess.h"

class ShortestJobFirst : public ScheduleProcess {
private:
    void allocateMemory();
    void sortProcessesByBurstTime();
    void swapBurstTime(int i, int j);
    void swapIndexes(int i, int j);
    void deallocateMemory();
public:
    explicit ShortestJobFirst(double *burstTime) : ScheduleProcess(burstTime) {
        allocateMemory();
        setParameters();
    };
    void start();
};


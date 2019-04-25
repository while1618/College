#include "../header_files/BurstTime.h"

double *BurstTime::getBurstTime() {
    char* process1[] = {const_cast<char *>("ls"), const_cast<char *>("-l"), nullptr};
    char* process2[] = {const_cast<char *>("pwd"), nullptr};
    char* process3[] = {const_cast<char *>("ls"), const_cast<char *>("-la"), nullptr};
    char* process4[] = {const_cast<char *>("ps"), const_cast<char *>("-aux"), nullptr};
    char* process5[] = {const_cast<char *>("date"), nullptr};
    char* process6[] = {const_cast<char *>("df"), nullptr};
    char* process7[] = {const_cast<char *>("du"), nullptr};
    char* process8[] = {const_cast<char *>("who"), nullptr};
    char* process9[] = {const_cast<char *>("uname"), nullptr};
    char* process10[] = {const_cast<char *>("echo"), const_cast<char *>("Hello World"), nullptr};

    char** processes[] = {
            process1,
            process2,
            process3,
            process4,
            process5,
            process6,
            process7,
            process8,
            process9,
            process10
    };

    double **timeWhenProcessEnd = whenProcessEnd(processes);

    auto *burstTimes = new double[NUMBER_OF_PROCESSES];

    for(int i = 0; i < NUMBER_OF_PROCESSES; i++){
        burstTimes[i] = calculateBurstTime(timeWhenProcessEnd[i]);
    }

    return burstTimes;
}

double **BurstTime::whenProcessEnd(char ***processes) {
    clock_t processStart, processEnd;

    int status;

    auto **timeWhenProcessEnd = new double*[NUMBER_OF_PROCESSES];
    for(int i = 0; i < NUMBER_OF_PROCESS_EXECUTION; i++){
        timeWhenProcessEnd[i] = new double[NUMBER_OF_PROCESS_EXECUTION];
    }
    for(int i = 0; i < NUMBER_OF_PROCESSES; i++){
        for(int j = 0; j < NUMBER_OF_PROCESS_EXECUTION; j++){

            processStart = clock();   //pocinje sa odbrojavanjem
            spawn(processes[i]);
            wait(&status);   //cekanje da se dete proces izvrsi

            if(!WIFEXITED(status))
                cerr << "Dete proces nije okoncan normalno" << endl;

            processEnd = clock();   //kada se proces zavrsi zavrsava sa odbrojavanjem
            timeWhenProcessEnd[i][j] = ((double) (processEnd - processStart)) / CLOCKS_PER_SEC;
        }
    }
    return timeWhenProcessEnd;
}

void BurstTime::spawn(char **process) {
    pid_t pid;
    pid = fork();

    if(pid == 0){ //dete proces
        int fd = open("/dev/null", O_WRONLY);  //preusmerava se stdout i stderr da bi se sakrio izlaz komadne

        dup2(fd, 1);
        dup2(fd, 2);
        close(fd);

        execvp(process[0], process);    //izvrsenje programa
        cerr << "Greska u funkciji execvp"; //funkcija execvp funkcija vraca nesto samo ako je doslo do greske
        abort();
    }
    if(pid < 0){
        cerr << "Greska u pid-u";
        abort();
    }
}

double BurstTime::calculateBurstTime(double *timeWhenProcessEnd) {
    const double a = 0.5;   //koficijent
    auto *burstTimes = new double[NUMBER_OF_PROCESS_EXECUTION + 1];
    burstTimes[0] = 0.01;   //prva pretpostavka (pretpostavimo da ce se proces zavrsiti za 10ms)

    for(int i = 0; i < NUMBER_OF_PROCESS_EXECUTION; i++){
        burstTimes[i + 1] = a * timeWhenProcessEnd[i] + (1 - a) * burstTimes[i];
    }
    return burstTimes[NUMBER_OF_PROCESS_EXECUTION];   //vracamo pretpostavljenu vrednost za koliko vremena bi trebao dati proces da se izvrsi sledeci put
}

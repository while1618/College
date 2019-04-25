#include "../header_files/SetPriority.h"

int *SetPriority::getPriority() {
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

    return setPriority(processes);
}

int *SetPriority::setPriority(char ***processes) {
    int status;
    int *priority = new int[NUMBER_OF_PROCESSES];

    srand(time(NULL));
    for(int i = 0; i < NUMBER_OF_PROCESSES; i++){
        priority[i] = spawn(processes[i]);    //priority se upisuju u niz
        wait(&status);   //cekanje da se dete proces izvrsi

        if(!WIFEXITED(status))
            cerr << "Dete proces nije okoncan normalno" << endl;
    }
    return priority;
}

int SetPriority::spawn(char **process) {
    pid_t pid;
    pid = fork();
    int which = PRIO_PROCESS;
    int priority = rand() % 20;
    setpriority(which, (id_t)pid, priority);  //postavlja radnom prioritet (0-19) za dati proces

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
    return getpriority(which, (id_t)pid);  //vraca prioritet procesa
}

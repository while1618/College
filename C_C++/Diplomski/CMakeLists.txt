cmake_minimum_required(VERSION 3.12)
project(Diplomski)

set(CMAKE_CXX_STANDARD 14)

add_executable(Diplomski src/main.cpp src/header_files/BurstTime.h src/header_files/FirstComeFirstServed.h src/header_files/Priority.h src/header_files/ShortestJobFirst.h src/header_files/SetPriority.h src/classes/BurstTime.cpp src/classes/FirstComeFirstServed.cpp src/classes/Priority.cpp src/classes/ShortestJobFirst.cpp src/classes/SetPriority.cpp src/classes/ScheduleProcess.cpp src/header_files/ScheduleProcess.h)
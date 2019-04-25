cmake_minimum_required(VERSION 3.7)
project(Vezba8)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp List.cpp List.h Knjiga.cpp Knjiga.h)
add_executable(Vezba8 ${SOURCE_FILES})
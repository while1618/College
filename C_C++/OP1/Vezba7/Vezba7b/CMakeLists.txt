cmake_minimum_required(VERSION 3.7)
project(Vezba7)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Broj.cpp Broj.h KompleksanBroj.cpp KompleksanBroj.h)
add_executable(Vezba7 ${SOURCE_FILES})
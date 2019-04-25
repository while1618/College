cmake_minimum_required(VERSION 3.7)
project(Vezba10)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Knjiga.cpp Knjiga.h Polica.cpp Polica.h)
add_executable(Vezba10 ${SOURCE_FILES})
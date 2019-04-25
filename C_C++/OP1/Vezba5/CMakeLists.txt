cmake_minimum_required(VERSION 3.7)
project(vezba5_proba)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Karta.cpp Karta.h Avion.cpp Avion.h)
add_executable(vezba5_proba ${SOURCE_FILES})
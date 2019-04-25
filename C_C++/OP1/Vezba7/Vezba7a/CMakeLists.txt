cmake_minimum_required(VERSION 3.7)
project(Vezba7a)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Slika.cpp Slika.h KatalogMuzeja.cpp KatalogMuzeja.h Izlozba.cpp Izlozba.h)
add_executable(Vezba7a ${SOURCE_FILES})
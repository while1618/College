cmake_minimum_required(VERSION 3.7)
project(Vezba6)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Pez.cpp Pez.h KutijaPeza.cpp KutijaPeza.h)
add_executable(Vezba6 ${SOURCE_FILES})
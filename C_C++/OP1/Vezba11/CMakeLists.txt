cmake_minimum_required(VERSION 3.7)
project(Vezba11)

set(CMAKE_CXX_STANDARD 11)

set(SOURCE_FILES main.cpp Kompleks.cpp Kompleks.h NizKompleksnih.cpp NizKompleksnih.h)
add_executable(Vezba11 ${SOURCE_FILES})
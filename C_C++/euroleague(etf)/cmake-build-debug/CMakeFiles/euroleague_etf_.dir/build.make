# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.7

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /opt/clion-2016.3.4/bin/cmake/bin/cmake

# The command to remove a file.
RM = /opt/clion-2016.3.4/bin/cmake/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "/home/dejan/CLionProjects/euroleague(etf)"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug"

# Include any dependencies generated for this target.
include CMakeFiles/euroleague_etf_.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/euroleague_etf_.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/euroleague_etf_.dir/flags.make

CMakeFiles/euroleague_etf_.dir/main.c.o: CMakeFiles/euroleague_etf_.dir/flags.make
CMakeFiles/euroleague_etf_.dir/main.c.o: ../main.c
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Building C object CMakeFiles/euroleague_etf_.dir/main.c.o"
	/usr/bin/cc  $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -o CMakeFiles/euroleague_etf_.dir/main.c.o   -c "/home/dejan/CLionProjects/euroleague(etf)/main.c"

CMakeFiles/euroleague_etf_.dir/main.c.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing C source to CMakeFiles/euroleague_etf_.dir/main.c.i"
	/usr/bin/cc  $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -E "/home/dejan/CLionProjects/euroleague(etf)/main.c" > CMakeFiles/euroleague_etf_.dir/main.c.i

CMakeFiles/euroleague_etf_.dir/main.c.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling C source to assembly CMakeFiles/euroleague_etf_.dir/main.c.s"
	/usr/bin/cc  $(C_DEFINES) $(C_INCLUDES) $(C_FLAGS) -S "/home/dejan/CLionProjects/euroleague(etf)/main.c" -o CMakeFiles/euroleague_etf_.dir/main.c.s

CMakeFiles/euroleague_etf_.dir/main.c.o.requires:

.PHONY : CMakeFiles/euroleague_etf_.dir/main.c.o.requires

CMakeFiles/euroleague_etf_.dir/main.c.o.provides: CMakeFiles/euroleague_etf_.dir/main.c.o.requires
	$(MAKE) -f CMakeFiles/euroleague_etf_.dir/build.make CMakeFiles/euroleague_etf_.dir/main.c.o.provides.build
.PHONY : CMakeFiles/euroleague_etf_.dir/main.c.o.provides

CMakeFiles/euroleague_etf_.dir/main.c.o.provides.build: CMakeFiles/euroleague_etf_.dir/main.c.o


# Object files for target euroleague_etf_
euroleague_etf__OBJECTS = \
"CMakeFiles/euroleague_etf_.dir/main.c.o"

# External object files for target euroleague_etf_
euroleague_etf__EXTERNAL_OBJECTS =

euroleague_etf_: CMakeFiles/euroleague_etf_.dir/main.c.o
euroleague_etf_: CMakeFiles/euroleague_etf_.dir/build.make
euroleague_etf_: CMakeFiles/euroleague_etf_.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir="/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug/CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Linking C executable euroleague_etf_"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/euroleague_etf_.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/euroleague_etf_.dir/build: euroleague_etf_

.PHONY : CMakeFiles/euroleague_etf_.dir/build

CMakeFiles/euroleague_etf_.dir/requires: CMakeFiles/euroleague_etf_.dir/main.c.o.requires

.PHONY : CMakeFiles/euroleague_etf_.dir/requires

CMakeFiles/euroleague_etf_.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/euroleague_etf_.dir/cmake_clean.cmake
.PHONY : CMakeFiles/euroleague_etf_.dir/clean

CMakeFiles/euroleague_etf_.dir/depend:
	cd "/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug" && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" "/home/dejan/CLionProjects/euroleague(etf)" "/home/dejan/CLionProjects/euroleague(etf)" "/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug" "/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug" "/home/dejan/CLionProjects/euroleague(etf)/cmake-build-debug/CMakeFiles/euroleague_etf_.dir/DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles/euroleague_etf_.dir/depend

cmake_minimum_required(VERSION 3.14)
project(Tennis-Refactoring LANGUAGES C)
set (CMAKE_C_STANDARD 99)

enable_testing()

include(FetchContent)
FetchContent_Declare(
        cmocka
        GIT_REPOSITORY https://git.cryptomilk.org/projects/cmocka.git
        GIT_TAG        cmocka-1.1.5
)
FetchContent_MakeAvailable(cmocka)

add_executable(TennisGame1Test TennisTest.c TennisGame.h TennisGame1.c)
target_link_libraries(TennisGame1Test cmocka)
add_test(TennisGame1Test TennisGame1Test)

add_executable(TennisGame2Test TennisTest.c TennisGame.h TennisGame2.c TennisGame2.h)
target_link_libraries(TennisGame2Test cmocka)
add_test(TennisGame2Test TennisGame2Test)

add_executable(TennisGame3Test TennisTest.c TennisGame.h TennisGame3.c)
target_link_libraries(TennisGame3Test cmocka)
add_test(TennisGame3Test TennisGame3Test)

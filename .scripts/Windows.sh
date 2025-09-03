#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Modules.sh"

# PROPERTIES
LOCATION="bin"
PLATFORM="Windows"
ARCHS=("x64" "win32" "arm64")
RIDS=("win-x64" "win-x86" "win-arm64")


# SDL
module SDL \
LIB="SDL2.dll" \
VERSION="release-2.32.8" \
GITHUB="https://github.com/libsdl-org/SDL.git" \
BUILD="cmake --build . --config Release" \
INSTALL="cmake --install . --config Release" \
CMAKE='cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
-DSDL_SHARED=ON \
-DSDL_STATIC=OFF \
-DCMAKE_C_FLAGS="-forceInterlockedFunctions-" \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5'


# IMAGE
module IMAGE \
LIB="SDL2_image.dll" \
VERSION="release-2.8.8" \
GITHUB="https://github.com/libsdl-org/SDL_image.git" \
BUILD="cmake --build . --config Release" \
INSTALL="cmake --install . --config Release" \
CMAKE='cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
-DSDL2IMAGE_BMP=ON \
-DSDL2IMAGE_PNG=ON \
-DSDL2IMAGE_JPG=ON \
-DSDL2IMAGE_AVIF=OFF \
-DSDL2IMAGE_WEBP=OFF \
-DSDL2IMAGE_GIF=OFF \
-DSDL2IMAGE_TIF=OFF \
-DSDL2IMAGE_TGA=OFF \
-DSDL2IMAGE_XCF=OFF \
-DSDL2IMAGE_XPM=OFF \
-DSDL2IMAGE_XV=OFF \
-DSDL2IMAGE_LBM=OFF \
-DSDL2IMAGE_PCX=OFF \
-DSDL2IMAGE_PNM=OFF \
-DSDL2IMAGE_QOI=OFF \
-DSDL2IMAGE_SVG=OFF \
-DSDL2IMAGE_JXL=OFF \
-DBUILD_SHARED_LIBS=ON \
-DSDL2IMAGE_SAMPLES=OFF \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/SDL2.lib'


# MIXER
module MIXER \
LIB="SDL2_mixer.dll" \
VERSION="release-2.8.1" \
GITHUB="https://github.com/libsdl-org/SDL_mixer.git" \
BUILD="cmake --build . --config Release" \
INSTALL="cmake --install . --config Release" \
CMAKE='cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
-DSDL2MIXER_WAVE=ON \
-DSDL2MIXER_MP3=ON \
-DSDL2MIXER_OGG=ON \
-DSDL2MIXER_OPUS=OFF \
-DSDL2MIXER_FLAC=OFF \
-DSDL2MIXER_MOD=OFF \
-DSDL2MIXER_MIDI=OFF \
-DSDL2MIXER_WAVPACK=OFF \
-DBUILD_SHARED_LIBS=ON \
-DSDL2MIXER_SAMPLES=OFF \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/SDL2.lib'


# TTF
module TTF \
LIB="SDL2_ttf.dll" \
VERSION="release-2.24.0" \
GITHUB="https://github.com/libsdl-org/SDL_ttf.git" \
BUILD="cmake --build . --config Release" \
INSTALL="cmake --install . --config Release" \
CMAKE='cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
-DBUILD_SHARED_LIBS=ON \
-DSDL2TTF_SAMPLES=OFF \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/SDL2.lib'


# RUN
source "$BASE_DIR/Dependencies/Build.sh"
read -p "Build complete."

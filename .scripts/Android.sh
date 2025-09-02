#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Modules.sh"

# PROPERTIES
LOCATION="lib"
PLATFORM="Android"
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
RIDS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
ANDROID_NDK="$HOME/AppData/Local/Android/Sdk/ndk/21.4.7075529/build/cmake/android.toolchain.cmake"


# SDL
module SDL \
LIB="libSDL2.so" \
VERSION="release-2.32.8" \
GITHUB="https://github.com/libsdl-org/SDL.git" \
CMAKE='cmake .. -G Ninja -Wno-dev \
-DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
-DANDROID_ABI=$ARCH \
-DANDROID_PLATFORM=android-21 \
-DSDL_SHARED=ON \
-DSDL_STATIC=OFF \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations"'


# IMAGE
module IMAGE \
LIB="libSDL2_image.so" \
VERSION="release-2.8.8" \
GITHUB="https://github.com/libsdl-org/SDL_image.git" \
CMAKE='cmake .. -G Ninja -Wno-dev \
-DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
-DANDROID_ABI=$ARCH \
-DANDROID_PLATFORM=android-21 \
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
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so'


# MIXER
module MIXER \
LIB="libSDL2_mixer.so" \
VERSION="release-2.8.1" \
GITHUB="https://github.com/libsdl-org/SDL_mixer.git" \
CMAKE='cmake .. -G Ninja -Wno-dev \
-DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
-DANDROID_ABI=$ARCH \
-DANDROID_PLATFORM=android-21 \
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
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so'


# TTF
module TTF \
LIB="libSDL2_ttf.so" \
VERSION="release-2.24.0" \
GITHUB="https://github.com/libsdl-org/SDL_ttf.git" \
CMAKE='cmake .. -G Ninja -Wno-dev \
-DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
-DANDROID_ABI=$ARCH \
-DANDROID_PLATFORM=android-21 \
-DBUILD_SHARED_LIBS=ON \
-DSDL2TTF_SAMPLES=OFF \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so'


# RUN
source "$BASE_DIR/Dependencies/Build.sh"
read -p "Build complete."

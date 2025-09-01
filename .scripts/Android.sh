# Dependencies
# Install Android Studio (https://developer.android.com/studio#get-android-studio)
# Install Ninja.exe (https://github.com/ninja-build/ninja/releases)
# Install SDK (Android Studio > SDK Tools (36.0 or 34.0 API)
# Install NDK (Android Studio > SDK Tools > NDK (Side by side) (21.4.7075529)
# Install CMAKE (https://cmake.org/download)
# Cmake (3.5 or above)

#!/bin/bash
set -e

# Properties
PLATFORM="Android"
LIB_NAMES=("libSDL2.so" "libSDL2_image.so" "libSDL2_mixer.so" "libSDL2_ttf.so")
ANDROID_NDK=$HOME/AppData/Local/Android/Sdk/ndk/21.4.7075529
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
RIDS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")
LIB_LOCATION="lib"

SDL()
{
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH
    
    cmake --build . --config Release
    cmake --install . --config Release
}

IMAGE()
{
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
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
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.so
    
    cmake --build . --config Release
    cmake --install . --config Release
}

MIXER()
{
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
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
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.so
    
    cmake --build . --config Release
    cmake --install . --config Release
}

TTF()
{
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2TTF_SAMPLES=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.so
    
    cmake --build . --config Release
    cmake --install . --config Release
}

# Run
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Build.sh"

# Complete
read -p "Build complete."

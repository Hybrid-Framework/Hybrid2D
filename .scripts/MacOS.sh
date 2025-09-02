#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Modules.sh"

# PROPERTIES
LOCATION="lib"
PLATFORM="MacOS"
ARCHS=("x86_64" "arm64")
RIDS=("osx-x64" "osx-arm64")


# LIBPNG
module LIBPNG \
LIB="" \
VERSION="v1.6.9" \
GITHUB="https://github.com/glennrp/libpng.git" \
CMAKE='cmake .. \
-DCMAKE_BUILD_TYPE=Release \
-DBUILD_SHARED_LIBS=OFF \
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DPNG_TESTS=OFF \
-DPNG_EXECUTABLES=OFF'


# FREETYPE
module FREETYPE \
LIB="" \
VERSION="VER-2-13-2" \
GITHUB="https://gitlab.freedesktop.org/freetype/freetype.git" \
CMAKE='cmake .. \
-DCMAKE_BUILD_TYPE=Release \
-DBUILD_SHARED_LIBS=OFF \
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
-DPNG_PNG_INCLUDE_DIR="$MODULES_DIR/LIBPNG/build_$ARCH" \
-DPNG_LIBRARY="$MODULES_DIR/LIBPNG/build_$ARCH/libpng16.a"'


# SDL
module SDL \
LIB="libSDL2.dylib" \
VERSION="release-2.32.8" \
GITHUB="https://github.com/libsdl-org/SDL.git" \
CMAKE='cmake .. -G "Unix Makefiles" \
-DSDL_SHARED=ON \
-DSDL_STATIC=OFF \
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations"'


# IMAGE
module IMAGE \
LIB="libSDL2_image.dylib" \
VERSION="release-2.8.8" \
GITHUB="https://github.com/libsdl-org/SDL_image.git" \
CMAKE='cmake .. -G "Unix Makefiles" \
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
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.dylib'


# MIXER
module MIXER \
LIB="libSDL2_mixer.dylib" \
VERSION="release-2.8.1" \
GITHUB="https://github.com/libsdl-org/SDL_mixer.git" \
CMAKE='cmake .. -G "Unix Makefiles" \
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
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.dylib'


# TTF
module TTF \
LIB="libSDL2_ttf.dylib" \
VERSION="release-2.24.0" \
GITHUB="https://github.com/libsdl-org/SDL_ttf.git" \
CMAKE='cmake .. -G "Unix Makefiles" \
-DBUILD_SHARED_LIBS=ON \
-DSDL2TTF_SAMPLES=OFF \
-DCMAKE_OSX_ARCHITECTURES=$ARCH \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.dylib \
-DFREETYPE_LIBRARY="$MODULES_DIR/FREETYPE/build_$ARCH/libfreetype.a" \
-DFREETYPE_INCLUDE_DIRS="$MODULES_DIR/FREETYPE/build_$ARCH/include" \
-DCMAKE_SHARED_LINKER_FLAGS="-lz -lbz2 $MODULES_DIR/LIBPNG/build_$ARCH/libpng16.a"'


# RUN
source "$BASE_DIR/Dependencies/Build.sh"
read -p "Build complete."

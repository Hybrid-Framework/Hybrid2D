#!/usr/bin/env bash
set -e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Linux"
ARCHS=("x86_64" "i686" "aarch64")
RIDS=("linux-x64" "linux-x86" "linux-arm64")
COMPILERS=("x86_64-linux-gnu-gcc" "i686-linux-gnu-gcc" "aarch64-linux-gnu-gcc")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  local COMPILER=${COMPILERS[$INDEX]}
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DCMAKE_C_COMPILER=$COMPILER \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_FLAGS="-Wno-int-to-pointer-cast -Wno-pointer-to-int-cast" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH

  cmake --build . --config Release
  cmake --install . --config Release

  Transfer "$INSTALLPATH/lib/libSDL2.so" "$BASE_DIR/../Natives/Linux/$RID/SDL.so"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  local COMPILER=${COMPILERS[$INDEX]}
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "release-2.8.8"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DSDL2IMAGE_BMP=ON \
    -DSDL2IMAGE_PNG=ON \
    -DSDL2IMAGE_JPG=ON \
    -DSDL2IMAGE_WEBP=OFF \
    -DSDL2IMAGE_AVIF=OFF \
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
    -DSDL2IMAGE_TESTS=OFF \
    -DSDL2IMAGE_SAMPLES=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2IMAGE_VENDORED=ON \
    -DSDL2IMAGE_DEPS_SHARED=OFF \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DCMAKE_C_COMPILER=$COMPILER \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-int-to-pointer-cast -Wno-pointer-to-int-cast" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release

  Transfer "$INSTALLPATH/lib/libSDL2_image.so" "$BASE_DIR/../Natives/Linux/$RID/IMAGE.so"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  local COMPILER=${COMPILERS[$INDEX]}
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
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
    -DSDL2MIXER_VENDORED=ON \
    -DSDL2MIXER_DEPS_SHARED=OFF \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DCMAKE_C_COMPILER=$COMPILER \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-int-to-pointer-cast -Wno-pointer-to-int-cast" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release

  Transfer "$INSTALLPATH/lib/libSDL2_mixer.so" "$BASE_DIR/../Natives/Linux/$RID/MIXER.so"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  local COMPILER=${COMPILERS[$INDEX]}
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "release-2.24.0"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2TTF_VENDORED=ON \
    -DSDL2TTF_SAMPLES=OFF \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DCMAKE_C_COMPILER=$COMPILER \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-int-to-pointer-cast -Wno-pointer-to-int-cast" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release

  Transfer "$INSTALLPATH/lib/libSDL2_ttf.so" "$BASE_DIR/../Natives/Linux/$RID/TTF.so"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
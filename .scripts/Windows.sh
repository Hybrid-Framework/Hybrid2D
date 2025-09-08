#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Windows"
ARCHS=("x64" "win32" "arm64")
RIDS=("win-x64" "win-x86" "win-arm64")
MODULES=("SDL2" "SDL2_mixer")

SDL2()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "SDL2" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  EXTRAFLAGS=""
  if [ "$ARCH" == "arm64" ]; then
      EXTRAFLAGS="-forceInterlockedFunctions-"
  fi
  
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_C_FLAGS=$EXTRAFLAGS \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH/bin/$MODULE.dll" "$BASE_DIR/../Natives/$PLATFORM/$RID"
}

SDL2_mixer()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "SDL2_mixer" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
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
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL2/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL2/install_$PLATFORM-$ARCH/lib/SDL2.lib

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH/bin/$MODULE.dll" "$BASE_DIR/../Natives/$PLATFORM/$RID"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
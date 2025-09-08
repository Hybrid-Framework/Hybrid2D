#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
ANDROID_NDK="$HOME/AppData/Local/Android/Sdk/ndk/21.4.7075529/build/cmake/android.toolchain.cmake"

PLATFORM="Android"
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
RIDS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
MODULES=("SDL2")

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
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations"

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH/lib/libSDL2.so" "$BASE_DIR/../Natives/$PLATFORM/$RID/libSDL2.so"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
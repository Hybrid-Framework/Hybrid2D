#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
MACOSX_DEPLOYMENT_TARGET=10.13

PLATFORM="MacOS"
ARCHS=("x86_64" "arm64")
RIDS=("osx-x64" "osx-arm64")
MODULES=("SDL2")

SDL2()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "SDL2" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  
  xcodebuild \
    -project "$MODULES_DIR/SDL2/Xcode/SDL/SDL.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk macosx \
    MACOSX_DEPLOYMENT_TARGET=$MACOSX_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
    
  Transfer "$BUILDPATH/$MODULE.framework/Versions/Current/$MODULE" "$BASE_DIR/../Natives/$PLATFORM/$RID/lib$MODULE.dylib"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
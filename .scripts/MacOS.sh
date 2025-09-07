#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="MacOS"
ARCHS=("x86_64" "arm64")
RIDS=("ios-x86_64-maccatalyst" "ios-arm64-maccatalyst")
MODULES=("SDL2")
MACCATALYST_DEPLOYMENT_TARGET=14.2

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
    -scheme "Framework-iOS" \
    -configuration Release \
    -arch "$ARCH" \
    SUPPORTS_MACCATALYST=YES \
    MACOSX_DEPLOYMENT_TARGET=$MACCATALYST_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
}

COMPLETE()
{
  for MODULE in "${MODULES[@]}"; do

    XCFRAMEWORK="$BASE_DIR/../Natives/MacOS/$MODULE.xcframework"
    rm -rf "$XCFRAMEWORK"
    mkdir -p "$XCFRAMEWORK"
    
    mkdir -p "$XCFRAMEWORK/ios-x86_64-maccatalyst/$MODULE.framework"
    mkdir -p "$XCFRAMEWORK/ios-arm64-maccatalyst/$MODULE.framework"
    
    find "$MODULES_DIR/$MODULE/build_MacOS-x86_64/$MODULE.framework" \
         -type f \( -name "$MODULE" -o -name "Info.plist" \) \
         -exec cp {} "$XCFRAMEWORK/ios-x86_64-maccatalyst/$MODULE.framework/" \;
    
    find "$MODULES_DIR/$MODULE/build_MacOS-arm64/$MODULE.framework" \
         -type f \( -name "$MODULE" -o -name "Info.plist" \) \
         -exec cp {} "$XCFRAMEWORK/ios-arm64-maccatalyst/$MODULE.framework/" \;

  done

  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
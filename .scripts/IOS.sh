#!/usr/bin/env bash
set -e

cleanup()
{
    local exit_code=$?
    if [ $exit_code -ne 0 ]; then
        echo "Script failed with exit code $exit_code."
        read -p "Press Enter to exit."
    fi
}

trap cleanup EXIT

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="IOS"
ARCHS=("IOS")
RIDS=("ios-arm64" "ios-arm64_x86_64-simulator")
MODULES=()

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" ""
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$ARCH"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  xcodebuild \
    -project "$MODULES_DIR/SDL/Xcode/SDL/SDL.xcodeproj" \
    -target "SDL3.xcframework" \
    -configuration Release
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" ""
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$ARCH"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  xcodebuild \
    -project "$MODULES_DIR/IMAGE/Xcode/SDL_image.xcodeproj" \
    -target "SDL3_image.xcframework" \
    -configuration Release
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$ARCH"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  xcodebuild \
    -project "$MODULES_DIR/MIXER/Xcode/SDL_mixer.xcodeproj" \
    -target "SDL3_mixer.xcframework" \
    -configuration Release
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$ARCH"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  xcodebuild \
    -project "$MODULES_DIR/TTF/Xcode/SDL_ttf.xcodeproj" \
    -target "SDL3_ttf.xcframework" \
    -configuration Release
}

COMPLETE()
{
  # SDL3
  for RID in "${RIDS[@]}"; do
    mkdir -p "$NATIVES_DIR/SDL3.xcframework/$RID/SDL3.framework"
    cp "$MODULES_DIR/SDL/Xcode/SDL/build/SDL3.xcframework/$RID/SDL3.framework/SDL3" "$NATIVES_DIR/SDL3.xcframework/$RID/SDL3.framework/SDL3"
    cp "$MODULES_DIR/SDL/Xcode/SDL/build/SDL3.xcframework/$RID/SDL3.framework/Info.plist" "$NATIVES_DIR/SDL3.xcframework/$RID/SDL3.framework/Info.plist"
  done
  
  cp "$MODULES_DIR/SDL/Xcode/SDL/build/SDL3.xcframework/Info.plist" "$NATIVES_DIR/SDL3.xcframework/Info.plist"
  
  # IMAGE
  for RID in "${RIDS[@]}"; do
    mkdir -p "$NATIVES_DIR/SDL3_image.xcframework/$RID/SDL3_image.framework"
    cp "$MODULES_DIR/IMAGE/Xcode/build/SDL3_image.xcframework/$RID/SDL3_image.framework/SDL3_image" "$NATIVES_DIR/SDL3_image.xcframework/$RID/SDL3_image.framework/SDL3_image"
    cp "$MODULES_DIR/IMAGE/Xcode/build/SDL3_image.xcframework/$RID/SDL3_image.framework/Info.plist" "$NATIVES_DIR/SDL3_image.xcframework/$RID/SDL3_image.framework/Info.plist"
  done
  
  cp "$MODULES_DIR/IMAGE/Xcode/build/SDL3_image.xcframework/Info.plist" "$NATIVES_DIR/SDL3_image.xcframework/Info.plist"
  
  # MIXER
  for RID in "${RIDS[@]}"; do
    mkdir -p "$NATIVES_DIR/SDL3_mixer.xcframework/$RID/SDL3_mixer.framework"
    cp "$MODULES_DIR/MIXER/Xcode/build/SDL3_mixer.xcframework/$RID/SDL3_mixer.framework/SDL3_mixer" "$NATIVES_DIR/SDL3_mixer.xcframework/$RID/SDL3_mixer.framework/SDL3_mixer"
    cp "$MODULES_DIR/MIXER/Xcode/build/SDL3_mixer.xcframework/$RID/SDL3_mixer.framework/Info.plist" "$NATIVES_DIR/SDL3_mixer.xcframework/$RID/SDL3_mixer.framework/Info.plist"
  done
  
  cp "$MODULES_DIR/MIXER/Xcode/build/SDL3_mixer.xcframework/Info.plist" "$NATIVES_DIR/SDL3_mixer.xcframework/Info.plist"
  
  # TTF
  for RID in "${RIDS[@]}"; do
    mkdir -p "$NATIVES_DIR/SDL3_ttf.xcframework/$RID/SDL3_ttf.framework"
    cp "$MODULES_DIR/TTF/Xcode/build/SDL3_ttf.xcframework/$RID/SDL3_ttf.framework/SDL3_ttf" "$NATIVES_DIR/SDL3_ttf.xcframework/$RID/SDL3_ttf.framework/SDL3_ttf"
    cp "$MODULES_DIR/TTF/Xcode/build/SDL3_ttf.xcframework/$RID/SDL3_ttf.framework/Info.plist" "$NATIVES_DIR/SDL3_ttf.xcframework/$RID/SDL3_ttf.framework/Info.plist"
  done
  
  cp "$MODULES_DIR/TTF/Xcode/build/SDL3_ttf.xcframework/Info.plist" "$NATIVES_DIR/SDL3_ttf.xcframework/Info.plist"
  
  # Complete
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
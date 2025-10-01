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
ARCHS=("iOS" "iOS Simulator")
RIDS=("ios" "ios-simulator")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" ""

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL/SDL.xcodeproj" \
    -scheme SDL3 \
    -configuration Release \
    -destination "generic/platform=$ARCH" \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    BUILD_DIR="$BUILDPATH"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" ""

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_image.xcodeproj" \
    -scheme SDL3_image \
    -configuration Release \
    -destination "generic/platform=$ARCH" \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    BUILD_DIR="$BUILDPATH"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" ""

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_mixer.xcodeproj" \
    -scheme SDL3_mixer \
    -configuration Release \
    -destination "generic/platform=$ARCH" \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    BUILD_DIR="$BUILDPATH"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" ""

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_ttf.xcodeproj" \
    -scheme SDL3_ttf \
    -configuration Release \
    -destination "generic/platform=$ARCH" \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    IPHONEOS_DEPLOYMENT_TARGET=13.0 \
    BUILD_DIR="$BUILDPATH"
}

COMPLETE()
{
  # Merge SDL
  xcodebuild -create-xcframework \
    -framework "$MODULES_DIR/SDL/build-ios/SDL3.framework" \
    -framework "$MODULES_DIR/SDL/build-ios-simulator/SDL3.framework" \
    -output "$NATIVES_DIR/SDL3.xcframework"
    
  find "$NATIVES_DIR/SDL3.xcframework" -type f ! -name "Info.plist" ! -name "SDL3" -exec rm -f "{}" \;
  find "$NATIVES_DIR/SDL3.xcframework" -type d -empty -delete
  
  # Merge SDL Image
  xcodebuild -create-xcframework \
    -framework "$MODULES_DIR/IMAGE/build-ios/SDL3_image.framework" \
    -framework "$MODULES_DIR/IMAGE/build-ios-simulator/SDL3_image.framework" \
    -output "$NATIVES_DIR/SDL3_image.xcframework"
  
  find "$NATIVES_DIR/SDL3_image.xcframework" -type f ! -name "Info.plist" ! -name "SDL3_image" -exec rm -f "{}" \;
  find "$NATIVES_DIR/SDL3_image.xcframework" -type d -empty -delete
  
  # Merge SDL Mixer
  xcodebuild -create-xcframework \
    -framework "$MODULES_DIR/MIXER/build-ios/SDL3_mixer.framework" \
    -framework "$MODULES_DIR/MIXER/build-ios-simulator/SDL3_mixer.framework" \
    -output "$NATIVES_DIR/SDL3_mixer.xcframework"
  
  find "$NATIVES_DIR/SDL3_mixer.xcframework" -type f ! -name "Info.plist" ! -name "SDL3_mixer" -exec rm -f "{}" \;
  find "$NATIVES_DIR/SDL3_mixer.xcframework" -type d -empty -delete
  
  # Merge SDL TTF
  xcodebuild -create-xcframework \
    -framework "$MODULES_DIR/TTF/build-ios/SDL3_ttf.framework" \
    -framework "$MODULES_DIR/TTF/build-ios-simulator/SDL3_ttf.framework" \
    -output "$NATIVES_DIR/SDL3_ttf.xcframework"
  
  find "$NATIVES_DIR/SDL3_ttf.xcframework" -type f ! -name "Info.plist" ! -name "SDL3_ttf" -exec rm -f "{}" \;
  find "$NATIVES_DIR/SDL3_ttf.xcframework" -type d -empty -delete
    
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
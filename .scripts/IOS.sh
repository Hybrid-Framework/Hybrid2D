#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="IOS"
ARCHS=("arm64" "x86_64" "arm64")
SDKS=("iphoneos" "iphonesimulator" "iphonesimulator")
RIDS=("ios-arm64" "iossimulator-x64" "iossimulator-arm64")
MODULES=("SDL2")

IOS_DEPLOYMENT_TARGET=13.0

SDL2()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "SDL2" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/SDL2/Xcode/SDL/SDL.xcodeproj" \
    -scheme "Framework-iOS" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
}

COMPLETE()
{
    # Create the universal simulator folder
    UNIVERSAL_DIR="$MODULES_DIR/SDL2/build_IOS-iossimulator-universal/SDL2.framework"
    mkdir -p "$UNIVERSAL_DIR"

    # Copy framework metadata (Info.plist, Headers) from one of the simulators
    cp -R "$MODULES_DIR/SDL2/build_IOS-iossimulator-arm64/SDL2.framework/"* "$UNIVERSAL_DIR"

    # Replace the binary with a lipo fat binary
    lipo -create \
      "$MODULES_DIR/SDL2/build_IOS-iossimulator-x64/SDL2.framework/SDL2" \
      "$MODULES_DIR/SDL2/build_IOS-iossimulator-arm64/SDL2.framework/SDL2" \
      -output "$UNIVERSAL_DIR/SDL2"

    # Create the XCFramework
    xcodebuild -create-xcframework \
      -framework "$MODULES_DIR/SDL2/build_IOS-ios-arm64/SDL2.framework" \
      -framework "$UNIVERSAL_DIR" \
      -output "$BASE_DIR/../Natives/IOS/SDL2.xcframework"

    read -p "Build complete."
}


source "$BASE_DIR/Dependencies/Build.sh"



SDL2_image()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "SDL2_image" "https://github.com/libsdl-org/SDL_image.git" "release-2.8.8"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/SDL2_image/Xcode/SDL_image.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD" \
    OTHER_LDFLAGS="-framework SDL2" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
}

SDL2_mixer()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "SDL2_mixer" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/SDL2_mixer/Xcode/SDL_mixer.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD" \
    OTHER_LDFLAGS="-framework SDL2" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
}

SDL2_ttf()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "SDL2_ttf" "https://github.com/libsdl-org/SDL_ttf.git" "release-2.24.0"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/SDL2_ttf/Xcode/SDL_ttf.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD" \
    OTHER_LDFLAGS="-framework SDL2" \
    OTHER_CFLAGS="-Wno-shorten-64-to-32 -Wdeprecated-declarations -DGLES_SILENCE_DEPRECATION" \
    build
}
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
MODULES=("SDL" "IMAGE" "MIXER" "TTF")
IOS_DEPLOYMENT_TARGET=13.0

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL/SDL.xcodeproj" \
    -scheme "Framework-iOS" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "release-2.8.8"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_image.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_mixer.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local SDK="${SDKS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"

  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "release-2.24.0"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$RID"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"

  SDL_BUILD="$MODULES_DIR/SDL/build_$PLATFORM-$RID"
  SDL_FRAMEWORK="$SDL_BUILD/SDL2.framework"
  SDL_INCLUDE="$SDL_FRAMEWORK/Headers"

  xcodebuild \
    -project "$MODULES_DIR/$MODULE/Xcode/SDL_ttf.xcodeproj" \
    -scheme "Framework" \
    -configuration Release \
    -arch "$ARCH" \
    -sdk "$SDK" \
    IPHONEOS_DEPLOYMENT_TARGET=$IOS_DEPLOYMENT_TARGET \
    CONFIGURATION_BUILD_DIR="$BUILDPATH" \
    HEADER_SEARCH_PATHS="$SDL_INCLUDE" \
    FRAMEWORK_SEARCH_PATHS="$SDL_BUILD"
}

COMPLETE()
{
  for MODULE in "${MODULES[@]}"; do
    
    local FRAMEWORK_NAME=""
    
    if [[ "$MODULE" == "SDL" ]]; then
      FRAMEWORK_NAME="SDL2"
    else
      FRAMEWORK_NAME="SDL2_${MODULE,,}"
    fi
    
    UNIVERSAL_DIR="$MODULES_DIR/$MODULE/build_IOS-iossimulator-universal/$FRAMEWORK_NAME.framework"
    XCFRAMEWORK="$BASE_DIR/../Natives/IOS/$FRAMEWORK_NAME.xcframework"
    mkdir -p "$UNIVERSAL_DIR"
    
    cp -R "$MODULES_DIR/$MODULE/build_IOS-iossimulator-arm64/$FRAMEWORK_NAME.framework/"* "$UNIVERSAL_DIR"
  
    lipo -create \
      "$MODULES_DIR/$MODULE/build_IOS-iossimulator-x64/$FRAMEWORK_NAME.framework/$FRAMEWORK_NAME" \
      "$MODULES_DIR/$MODULE/build_IOS-iossimulator-arm64/$FRAMEWORK_NAME.framework/$FRAMEWORK_NAME" \
      -output "$UNIVERSAL_DIR/$FRAMEWORK_NAME"
  
    xcodebuild -create-xcframework \
      -framework "$MODULES_DIR/$MODULE/build_IOS-ios-arm64/$FRAMEWORK_NAME.framework" \
      -framework "$UNIVERSAL_DIR" \
      -output "$XCFRAMEWORK"
    
    find "$XCFRAMEWORK" -type f ! -name "Info.plist" ! -name "$FRAMEWORK_NAME" -exec rm -f "{}" \;
    find "$XCFRAMEWORK" -type d -empty -delete

  done

  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
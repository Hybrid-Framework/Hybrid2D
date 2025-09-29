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
MODULES=("SDL2" "IMAGE" "MIXER" "TTF")
IOS_DEPLOYMENT_TARGET=13.0

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

SDL2()
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

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
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
    
  # Update Internals
  local FRAMEWORK="$BUILDPATH/SDL2_image.framework"
  plutil -replace CFBundleName -string "IMAGE" "$FRAMEWORK/Info.plist"
  plutil -replace CFBundleExecutable -string "IMAGE" "$FRAMEWORK/Info.plist"
  install_name_tool -change "@rpath/SDL2_image.framework/SDL2_image" "@rpath/IMAGE.framework/IMAGE" "$FRAMEWORK/SDL2_image"
  install_name_tool -id "@rpath/IMAGE.framework/IMAGE" "$FRAMEWORK/SDL2_image"
  Rename "$FRAMEWORK/SDL2_image" "$FRAMEWORK/IMAGE"
  Rename "$FRAMEWORK" "$BUILDPATH/IMAGE.framework"
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

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
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
    
  # Update Internals
  local FRAMEWORK="$BUILDPATH/SDL2_mixer.framework"
  plutil -replace CFBundleName -string "MIXER" "$FRAMEWORK/Info.plist"
  plutil -replace CFBundleExecutable -string "MIXER" "$FRAMEWORK/Info.plist"
  install_name_tool -change "@rpath/SDL2_mixer.framework/SDL2_mixer" "@rpath/MIXER.framework/MIXER" "$FRAMEWORK/SDL2_mixer"
  install_name_tool -id "@rpath/MIXER.framework/MIXER" "$FRAMEWORK/SDL2_mixer"
  Rename "$FRAMEWORK/SDL2_mixer" "$FRAMEWORK/MIXER"
  Rename "$FRAMEWORK" "$BUILDPATH/MIXER.framework"
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

  SDL_BUILD="$MODULES_DIR/SDL2/build_$PLATFORM-$RID"
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
    
  # Update Internals
  local FRAMEWORK="$BUILDPATH/SDL2_ttf.framework"
  plutil -replace CFBundleName -string "TTF" "$FRAMEWORK/Info.plist"
  plutil -replace CFBundleExecutable -string "TTF" "$FRAMEWORK/Info.plist"
  install_name_tool -change "@rpath/SDL2_ttf.framework/SDL2_ttf" "@rpath/TTF.framework/TTF" "$FRAMEWORK/SDL2_ttf"
  install_name_tool -id "@rpath/TTF.framework/TTF" "$FRAMEWORK/SDL2_ttf"
  Rename "$FRAMEWORK/SDL2_ttf" "$FRAMEWORK/TTF"
  Rename "$FRAMEWORK" "$BUILDPATH/TTF.framework"
}

COMPLETE()
{
  echo "Building Frameworks"
  
  for MODULE in "${MODULES[@]}"; do
    
    # Create Universal Framework
    UNIVERSAL_DIR="$MODULES_DIR/$MODULE/build_IOS-iossimulator-universal/$MODULE.framework"
    mkdir -p "$UNIVERSAL_DIR"
    cp -R "$MODULES_DIR/$MODULE/build_IOS-iossimulator-arm64/$MODULE.framework/"* "$UNIVERSAL_DIR"
    
    lipo -create \
      "$MODULES_DIR/$MODULE/build_IOS-iossimulator-x64/$MODULE.framework/$MODULE" \
      "$MODULES_DIR/$MODULE/build_IOS-iossimulator-arm64/$MODULE.framework/$MODULE" \
      -output "$UNIVERSAL_DIR/$MODULE"
    
    # Create xcFramework
    XCFRAMEWORK="$NATIVES_DIR/$MODULE.xcframework"
    
    xcodebuild -create-xcframework \
      -framework "$MODULES_DIR/$MODULE/build_IOS-ios-arm64/$MODULE.framework" \
      -framework "$UNIVERSAL_DIR" \
      -output "$XCFRAMEWORK"
    
    # Remove Files
    find "$XCFRAMEWORK" -type f ! -name "Info.plist" ! -name "$MODULE" -exec rm -f "{}" \;
    find "$XCFRAMEWORK" -type d -empty -delete

  done

  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
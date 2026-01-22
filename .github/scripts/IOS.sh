#!/usr/bin/env bash
set -e

echo "Building... OS: $OS PLATFORM: $PLATFORM ARCH: $ARCH RID: $RID"

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
NATIVES_DIR="$BASE_DIR/../../Natives/Mobile/$PLATFORM"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
rm -rf "$NATIVES_DIR"
mkdir -p "$NATIVES_DIR"

MODULES=("SDL" "IMAGE" "MIXER" "TTF")

ENVIRONMENT()
{
  echo "Setting up ios environment..."
}

SDL()
{
  Github "SDL" "https://github.com/libsdl-org/SDL.git" ""
  
  xcodebuild \
    -project "$MODULES_DIR/SDL/Xcode/SDL/SDL.xcodeproj" \
    -target "SDL3.xcframework" \
    -configuration Release
}

IMAGE()
{
  Github "SDL_IMAGE" "https://github.com/libsdl-org/SDL_image.git" ""
  
  xcodebuild \
    -project "$MODULES_DIR/SDL_IMAGE/Xcode/SDL_image.xcodeproj" \
    -target "SDL3_image.xcframework" \
    -configuration Release
}

MIXER()
{
  Github "SDL_MIXER" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
  xcodebuild \
    -project "$MODULES_DIR/SDL_MIXER/Xcode/SDL_mixer.xcodeproj" \
    -target "SDL3_mixer.xcframework" \
    -configuration Release
}

TTF()
{
  Github "SDL_TTF" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
  xcodebuild \
    -project "$MODULES_DIR/SDL_TTF/Xcode/SDL_ttf.xcodeproj" \
    -target "SDL3_ttf.xcframework" \
    -configuration Release
}

Create()
{
  local Location="$1"
  local Framework="$2"
  local RIDS=("ios-arm64" "ios-arm64_x86_64-simulator")
  
  for Rid in "${RIDS[@]}"; do
    mkdir -p "$NATIVES_DIR/$Framework.xcframework/$Rid/$Framework.framework"
    cp "$Location/$Framework.xcframework/$Rid/$Framework.framework/$Framework" "$NATIVES_DIR/$Framework.xcframework/$Rid/$Framework.framework/$Framework"
    cp "$Location/$Framework.xcframework/$Rid/$Framework.framework/Info.plist" "$NATIVES_DIR/$Framework.xcframework/$Rid/$Framework.framework/Info.plist"
    cp "$Location/$Framework.xcframework/Info.plist" "$NATIVES_DIR/$Framework.xcframework/Info.plist"
  done
}

COMPLETE()
{
  Create "$MODULES_DIR/SDL/Xcode/SDL/build" "SDL3"
  Create "$MODULES_DIR/SDL_IMAGE/Xcode/build" "SDL3_image"
  Create "$MODULES_DIR/SDL_MIXER/Xcode/build" "SDL3_mixer"
  Create "$MODULES_DIR/SDL_TTF/Xcode/build" "SDL3_ttf"

  echo "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
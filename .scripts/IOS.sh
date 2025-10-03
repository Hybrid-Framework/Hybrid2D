#!/usr/bin/env bash
set -e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="IOS"
ARCHS=("IOS")
RIDS=("ios-arm64" "ios-arm64_x86_64-simulator")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

SDL()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "4efdfd92a24ff3bbe6780666189000bf5d84ed30"
  
  xcodebuild \
    -project "$MODULES_DIR/SDL/Xcode/SDL/SDL.xcodeproj" \
    -target "SDL3.xcframework" \
    -configuration Release
}

IMAGE()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "e47ff6fa4e9092eec66c1b95118be0fa574c7933"
  
  xcodebuild \
    -project "$MODULES_DIR/IMAGE/Xcode/SDL_image.xcodeproj" \
    -target "SDL3_image.xcframework" \
    -configuration Release
}

MIXER()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "172997758bb69c9217a2caec57bd9450d86dc558"
  
  xcodebuild \
    -project "$MODULES_DIR/MIXER/Xcode/SDL_mixer.xcodeproj" \
    -target "SDL3_mixer.xcframework" \
    -configuration Release
}

TTF()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "7285911aea1df44f6522a8c43025a962493c6c24"
  
  xcodebuild \
    -project "$MODULES_DIR/TTF/Xcode/SDL_ttf.xcodeproj" \
    -target "SDL3_ttf.xcframework" \
    -configuration Release
}

COMPLETE()
{
  CreateFramework()
  {
    local Location="$1"
    local Framework="$2"
    
    for RID in "${RIDS[@]}"; do
      mkdir -p "$NATIVES_DIR/$Framework.xcframework/$RID/$Framework.framework"
      cp "$Location/$Framework.xcframework/$RID/$Framework.framework/$Framework" "$NATIVES_DIR/$Framework.xcframework/$RID/$Framework.framework/$Framework"
      cp "$Location/$Framework.xcframework/$RID/$Framework.framework/Info.plist" "$NATIVES_DIR/$Framework.xcframework/$RID/$Framework.framework/Info.plist"
      cp "$Location/$Framework.xcframework/Info.plist" "$NATIVES_DIR/$Framework.xcframework/Info.plist"
    done
  }
  
  CreateFramework "$MODULES_DIR/SDL/Xcode/SDL/build" "SDL3"
  CreateFramework "$MODULES_DIR/IMAGE/Xcode/build" "SDL3_image"
  CreateFramework "$MODULES_DIR/MIXER/Xcode/build" "SDL3_mixer"
  CreateFramework "$MODULES_DIR/TTF/Xcode/build" "SDL3_ttf"

  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Modules.sh"

# PROPERTIES
PLATFORM="IOS"
LOCATION="Frameworks"
ARCHS=("arm64")
RIDS=("ios-arm64")

## LIBPNG
#module LIBPNG \
#LIB="" \
#VERSION="v1.6.50" \
#GITHUB="https://github.com/libsdl-org/libpng.git" \
#BUILD="cmake --build . --config Release" \
#INSTALL="cmake --install . --config Release" \
#CMAKE='cmake .. \
#-DCMAKE_BUILD_TYPE=Release \
#-DBUILD_SHARED_LIBS=OFF \
#-DCMAKE_SYSTEM_NAME=iOS \
#-DCMAKE_OSX_DEPLOYMENT_TARGET=13.0 \
#-DCMAKE_OSX_ARCHITECTURES=arm64 \
#-DCMAKE_OSX_SYSROOT=iphoneos \
#-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
#-DPNG_TESTS=OFF \
#-DPNG_EXECUTABLES=OFF'
#
## FREETYPE
#module FREETYPE \
#LIB="" \
#VERSION="VER-2-13-3" \
#GITHUB="https://github.com/libsdl-org/freetype.git" \
#BUILD="cmake --build . --config Release" \
#INSTALL="cmake --install . --config Release" \
#CMAKE='cmake .. \
#-DCMAKE_BUILD_TYPE=Release \
#-DBUILD_SHARED_LIBS=OFF \
#-DCMAKE_SYSTEM_NAME=iOS \
#-DCMAKE_OSX_DEPLOYMENT_TARGET=13.0 \
#-DCMAKE_OSX_ARCHITECTURES=arm64 \
#-DCMAKE_OSX_SYSROOT=iphoneos \
#-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
#-DPNG_PNG_INCLUDE_DIR="$MODULES_DIR/LIBPNG/install_$PLATFORM-$ARCH/include" \
#-DPNG_LIBRARY="$MODULES_DIR/LIBPNG/install_$PLATFORM-$ARCH/lib/libpng16.a"'

# SDL2
module SDL \
LIB="SDL2.framework" \
VERSION="release-2.32.8" \
GITHUB="https://github.com/libsdl-org/SDL.git" \
BUILD='xcodebuild -project "$MODULES_DIR/SDL/build_IOS-'$ARCH'/SDL.xcodeproj" -scheme SDL -configuration Release -sdk iphoneos -arch '$ARCH' build' \
INSTALL="" \
CMAKE='cmake .. -G Xcode -Wno-dev \
-DSDL_SHARED=OFF \
-DSDL_STATIC=ON \
-DCMAKE_SYSTEM_NAME=iOS \
-DCMAKE_OSX_DEPLOYMENT_TARGET=13.0 \
-DCMAKE_OSX_ARCHITECTURES=arm64 \
-DCMAKE_OSX_SYSROOT=iphoneos \
-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations"'


#
## SDL2_image
#module IMAGE \
#LIB="SDL2_image.framework" \
#VERSION="release-2.8.8" \
#GITHUB="https://github.com/libsdl-org/SDL_image.git" \
#CMAKE='cmake .. -G Xcode \
#-DSDL2IMAGE_BMP=ON \
#-DSDL2IMAGE_PNG=ON \
#-DSDL2IMAGE_JPG=ON \
#-DSDL2IMAGE_SAMPLES=OFF \
#-DBUILD_SHARED_LIBS=ON \
#-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/Headers \
#-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/SDL2' \
#BUILD='xcodebuild -project SDL_image.xcodeproj -scheme SDL2_image -configuration Release -sdk ${ARCH/x86_64/iphonesimulator} -arch $ARCH build' \
#INSTALL='mkdir -p $INSTALLPATH && cp -R $BUILDPATH/Release-*/SDL2_image.framework $INSTALLPATH/'
#
## SDL2_mixer
#module MIXER \
#LIB="SDL2_mixer.framework" \
#VERSION="release-2.8.1" \
#GITHUB="https://github.com/libsdl-org/SDL_mixer.git" \
#CMAKE='cmake .. -G Xcode \
#-DSDL2MIXER_WAVE=ON \
#-DSDL2MIXER_MP3=ON \
#-DSDL2MIXER_OGG=ON \
#-DSDL2MIXER_SAMPLES=OFF \
#-DBUILD_SHARED_LIBS=ON \
#-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/Headers \
#-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/SDL2' \
#BUILD='xcodebuild -project SDL_mixer.xcodeproj -scheme SDL2_mixer -configuration Release -sdk ${ARCH/x86_64/iphonesimulator} -arch $ARCH build' \
#INSTALL='mkdir -p $INSTALLPATH && cp -R $BUILDPATH/Release-*/SDL2_mixer.framework $INSTALLPATH/'
#
## SDL2_ttf
#module TTF \
#LIB="SDL2_ttf.framework" \
#VERSION="release-2.24.0" \
#GITHUB="https://github.com/libsdl-org/SDL_ttf.git" \
#CMAKE='cmake .. -G Xcode \
#-DBUILD_SHARED_LIBS=ON \
#-DSDL2TTF_SAMPLES=OFF \
#-DCMAKE_OSX_ARCHITECTURES=$ARCH \
#-DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/Headers \
#-DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/SDL2.framework/SDL2 \
#-DFREETYPE_INCLUDE_DIRS="$MODULES_DIR/FREETYPE/install_$PLATFORM-$ARCH/include" \
#-DFREETYPE_LIBRARY="$MODULES_DIR/FREETYPE/install_$PLATFORM-$ARCH/lib/libfreetype.a" \
#-DCMAKE_SHARED_LINKER_FLAGS="-lz -lbz2 $MODULES_DIR/LIBPNG/install_$PLATFORM-$ARCH/lib/libpng16.a"' \
#BUILD='xcodebuild -project SDL_ttf.xcodeproj -scheme SDL2_ttf -configuration Release -sdk ${ARCH/x86_64/iphonesimulator} -arch $ARCH build' \
#INSTALL='mkdir -p $INSTALLPATH && cp -R $BUILDPATH/Release-*/SDL2_ttf.framework $INSTALLPATH/'

# RUN
source "$BASE_DIR/Dependencies/Build.sh"

read -p "iOS Build complete."

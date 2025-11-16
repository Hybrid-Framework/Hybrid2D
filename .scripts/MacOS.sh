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

PLATFORM="MacOS"
ARCHS=("x86_64" "arm64")
RIDS=("osx-x64" "osx-arm64")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

NATIVES_DIR="$BASE_DIR/../Platforms/$PLATFORM/Natives"
rm -rf "$NATIVES_DIR"

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL.git" "4efdfd92a24ff3bbe6780666189000bf5d84ed30"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_OSX_DEPLOYMENT_TARGET=10.13 \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3.dylib" "$NATIVES_DIR/$RID/libSDL3.dylib"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "e47ff6fa4e9092eec66c1b95118be0fa574c7933"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_OSX_DEPLOYMENT_TARGET=10.13 \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DSDLIMAGE_BMP=ON \
    -DSDLIMAGE_JPG=ON \
    -DSDLIMAGE_PNG=ON \
    -DSDLIMAGE_AVIF=OFF \
    -DSDLIMAGE_WEBP=OFF \
    -DSDLIMAGE_GIF=OFF \
    -DSDLIMAGE_JXL=OFF \
    -DSDLIMAGE_LBM=OFF \
    -DSDLIMAGE_PCX=OFF \
    -DSDLIMAGE_PNM=OFF \
    -DSDLIMAGE_QOI=OFF \
    -DSDLIMAGE_SVG=OFF \
    -DSDLIMAGE_TGA=OFF \
    -DSDLIMAGE_TIF=OFF \
    -DSDLIMAGE_XCF=OFF \
    -DSDLIMAGE_XPM=OFF \
    -DSDLIMAGE_XV=OFF \
    -DSDLIMAGE_VENDORED=ON \
    -DSDLIMAGE_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_image.dylib" "$NATIVES_DIR/$RID/libSDL3_image.dylib"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "172997758bb69c9217a2caec57bd9450d86dc558"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_OSX_DEPLOYMENT_TARGET=10.13 \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DSDLMIXER_MP3_DRMP3=ON \
    -DSDLMIXER_VORBIS_STB=ON \
    -DSDLMIXER_WAVE=ON \
    -DSDLMIXER_VORBIS_VORBISFILE=OFF \
    -DSDLMIXER_VORBIS_TREMOR=OFF \
    -DSDLMIXER_MIDI_TIMIDITY=OFF \
    -DSDLMIXER_FLAC_LIBFLAC=OFF \
    -DSDLMIXER_FLAC_DRFLAC=OFF \
    -DSDLMIXER_MP3_MPG123=OFF \
    -DSDLMIXER_GME_SHARED=OFF \
    -DSDLMIXER_MOD_XMP=OFF \
    -DSDLMIXER_WAVPACK=OFF \
    -DSDLMIXER_AIFF=OFF \
    -DSDLMIXER_OPUS=OFF \
    -DSDLMIXER_VOC=OFF \
    -DSDLMIXER_GME=OFF \
    -DSDLMIXER_AU=OFF \
    -DSDLMIXER_VENDORED=ON \
    -DSDLMIXER_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_mixer.dylib" "$NATIVES_DIR/$RID/libSDL3_mixer.dylib"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "7285911aea1df44f6522a8c43025a962493c6c24"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_OSX_DEPLOYMENT_TARGET=10.13 \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DSDLTTF_VENDORED=ON \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_ttf.dylib" "$NATIVES_DIR/$RID/libSDL3_ttf.dylib"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
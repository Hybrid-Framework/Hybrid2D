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

PLATFORM="Web"
RIDS=("Emscripten")
ARCHS=("Emscripten")
MODULES=("Emscripten" "SDL" "IMAGE" "MIXER" "TTF")

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

Emscripten()
{
  local INDEX="$1"
  local VERSION="3.1.56"

  Github "$MODULE" "https://github.com/emscripten-core/emsdk.git" "$VERSION"

  cd "$MODULES_DIR/$MODULE"
  ./emsdk install "$VERSION"
  ./emsdk activate "$VERSION"
  source ./emsdk_env.sh
}

SDL()
{
  local INDEX="$1"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL.git" "4efdfd92a24ff3bbe6780666189000bf5d84ed30"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  emcmake cmake .. -G Ninja \
    -DSDL_STATIC=ON \
    -DSDL_SHARED=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"
  
  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3.a" "$NATIVES_DIR/SDL3.a"
}

IMAGE()
{
  local INDEX="$1"

  Github "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "e47ff6fa4e9092eec66c1b95118be0fa574c7933"

  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  emcmake cmake .. -G Ninja \
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
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"

  ninja
  ninja install

  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_image.a" "$NATIVES_DIR/SDL3_image.a"
}

MIXER()
{
  local INDEX="$1"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "172997758bb69c9217a2caec57bd9450d86dc558"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  emcmake cmake .. -G Ninja \
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
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"

  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_mixer.a" "$NATIVES_DIR/SDL3_mixer.a"
}

TTF()
{
  local INDEX="$1"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "7285911aea1df44f6522a8c43025a962493c6c24"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  emcmake cmake .. -G Ninja \
    -DSDLTTF_HARFBUZZ=OFF \
    -DSDLTTF_PLUTOSVG=OFF \
    -DSDLTTF_VENDORED=ON \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"
  
  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_ttf.a" "$NATIVES_DIR/SDL3_ttf.a"
}

COMPLETE()
{
  LLVMPATH="$MODULES_DIR/Emscripten/upstream/bin/llvm-nm.exe"
  
  for lib in "$NATIVES_DIR"/*.a; do
    
    [ -e "$lib" ] || continue

    symbols=$("$LLVMPATH" "$lib" 2>/dev/null | grep "invoke_" || true)

    if [ -n "$symbols" ]; then
        echo "❌ $lib"
        echo "$symbols"
    else
        echo "✅ $lib"
    fi
    
  done
  
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
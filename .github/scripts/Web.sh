#!/usr/bin/env bash
set -e

echo "Building... OS: $OS PLATFORM: $PLATFORM ARCH: $ARCH RID: $RID"

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
NATIVES_DIR="$BASE_DIR/../../Hybrid/Platforms/Hybrid2D.Web/Natives"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
rm -rf "$NATIVES_DIR"
mkdir -p "$NATIVES_DIR"

MODULES=("SDL" "IMAGE" "MIXER" "TTF")

ENVIRONMENT()
{
  echo "Setting up emscripten environment..."
  
  Github "EMSCRIPTEN" "https://github.com/emscripten-core/emsdk.git" "3.1.56"

  cd "$MODULES_DIR/EMSCRIPTEN"
  ./emsdk install "3.1.56"
  ./emsdk activate "3.1.56"
  source ./emsdk_env.sh
}

SDL()
{
  Github "SDL" "https://github.com/libsdl-org/SDL.git" ""
  
  cd "$MODULES_DIR/SDL" || exit
  BUILDPATH="$MODULES_DIR/SDL/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/SDL/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  emcmake cmake .. -G Ninja \
    -DSDL_STATIC=ON \
    -DSDL_SHARED=OFF \
    -DSDL_TEST_LIBRARY=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"
  
  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3.a" "$NATIVES_DIR/SDL3.a"
}

IMAGE()
{
  Github "SDL_IMAGE" "https://github.com/libsdl-org/SDL_image.git" ""

  cd "$MODULES_DIR/SDL_IMAGE" || exit
  BUILDPATH="$MODULES_DIR/SDL_IMAGE/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/SDL_IMAGE/install_$PLATFORM"
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
    -DSDLIMAGE_PNG_LIBPNG=OFF \
    -DSDLIMAGE_ANI=OFF \
    -DSDLIMAGE_TESTS=OFF \
    -DSDLIMAGE_VENDORED=ON \
    -DSDLIMAGE_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DCMAKE_CXX_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"

  ninja
  ninja install

  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_image.a" "$NATIVES_DIR/SDL3_image.a"
}

MIXER()
{
  Github "SDL_MIXER" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
  cd "$MODULES_DIR/SDL_MIXER" || exit
  BUILDPATH="$MODULES_DIR/SDL_MIXER/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/SDL_MIXER/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  emcmake cmake .. -G Ninja \
    -DSDLMIXER_WAVE=ON \
    -DSDLMIXER_MP3_DRMP3=ON \
    -DSDLMIXER_VORBIS_STB=ON \
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
    -DSDLMIXER_TESTS=OFF \
    -DSDLMIXER_VENDORED=ON \
    -DSDLMIXER_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DCMAKE_CXX_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"

  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_mixer.a" "$NATIVES_DIR/SDL3_mixer.a"
}

TTF()
{
  Github "SDL_TTF" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
  cd "$MODULES_DIR/SDL_TTF" || exit
  BUILDPATH="$MODULES_DIR/SDL_TTF/build_$PLATFORM"
  INSTALLPATH="$MODULES_DIR/SDL_TTF/install_$PLATFORM"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  emcmake cmake .. -G Ninja \
    -DSDLTTF_VENDORED=ON \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DCMAKE_C_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DCMAKE_CXX_FLAGS="-fwasm-exceptions -sSUPPORT_LONGJMP=wasm" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM/lib/cmake/SDL3"
  
  ninja
  ninja install
  
  mkdir -p "$NATIVES_DIR"
  cp "$INSTALLPATH/lib/libSDL3_ttf.a" "$NATIVES_DIR/SDL3_ttf.a"
}

COMPLETE()
{
  echo "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
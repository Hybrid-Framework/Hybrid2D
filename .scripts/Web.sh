#!/usr/bin/env bash
set +e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Web"
MODULES=("Emscripten" "SDL2")

PORTPATH="$MODULES_DIR/Emscripten/upstream/emscripten/tools/ports"
LIBPATH="$MODULES_DIR/Emscripten/build_$PLATFORM/sysroot/lib/wasm32-emscripten"
TARGETPATH="$BASE_DIR/../Natives/$PLATFORM"

Emscripten()
{
  local INDEX="$1"
  local VERSION="3.1.56"

  Install "Emscripten" "https://github.com/emscripten-core/emsdk.git" "$VERSION"

  cd "$MODULES_DIR/$MODULE"
  ./emsdk install "$VERSION"
  ./emsdk activate "$VERSION"
  source ./emsdk_env.sh

  export EM_CACHE="$MODULES_DIR/$MODULE/build_$PLATFORM"
  read -p "Emscripten installed... continue to build?"
}

SDL2()
{
  local INDEX="$1"
  
  for file in "$DEPENDENCIES_DIR/System/Emscripten/"*.py; do
    [ -e "$file" ] || continue
    Transfer "$file" "$PORTPATH"
  done
  
  cd "$MODULES_DIR/Emscripten" || exit
  BUILDPATH="$MODULES_DIR/Emscripten/build_$PLATFORM"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  echo 'int main() { return 0; }' > test.c
  
  emcc test.c \
    -s USE_SDL=2 \
    -s USE_SDL_IMAGE=2 -s SDL2_IMAGE_FORMATS='["png","jpg","bmp"]' \
    -s USE_SDL_MIXER=2 -s SDL2_MIXER_FORMATS='["ogg","wav","mp3"]' \
    -s USE_SDL_TTF=2 \
    -o test.html
}

COMPLETE()
{
  # Rename libs for consistent pinvoke across platforms
  Rename "$LIBPATH/libSDL2_image*.a" "$LIBPATH/SDL2_image.a"
  Rename "$LIBPATH/libSDL2_mixer*.a" "$LIBPATH/SDL2_mixer.a"
  Rename "$LIBPATH/libSDL2_ttf*.a" "$LIBPATH/SDL2_ttf.a"
  Rename "$LIBPATH/libSDL2*.a" "$LIBPATH/SDL2.a"

  # Transfer specific files for our build to keep size low
  Transfer "$LIBPATH/libfreetype*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libharfbuzz*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libjpeg*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libpng*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libmpg123*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libogg*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libvorbis*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/libz*.a" "$TARGETPATH/Dependencies"
  Transfer "$LIBPATH/SDL2_image*.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_mixer*.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_ttf*.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2.a*" "$TARGETPATH"
  
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
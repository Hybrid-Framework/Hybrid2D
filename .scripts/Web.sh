#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Web"
MODULES=("Emscripten")
ARCHS=("Browser")

Emscripten()
{
  local INDEX="$1"
  local VERSION="3.1.34"

  Install "Emscripten" "https://github.com/emscripten-core/emsdk.git" "$VERSION"

  cd "$MODULES_DIR/$MODULE"
  ./emsdk install "$VERSION"
  ./emsdk activate "$VERSION"
  source ./emsdk_env.sh
  
  cd "$MODULES_DIR/Emscripten" || exit
  BUILDPATH="$MODULES_DIR/Emscripten/build_$PLATFORM"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  export EM_CACHE="$MODULES_DIR/$MODULE/build_$PLATFORM"
  echo 'int main() { return 0; }' > test.c
  
  emcc test.c \
      -s USE_SDL=2 \
      -s USE_SDL_MIXER=2 -s SDL2_MIXER_FORMATS='["ogg","wav","mp3"]' \
      -o test.html
  
  local LIBPATH="$MODULES_DIR/$MODULE/build_$PLATFORM/sysroot/lib/wasm32-emscripten"
  local TARGETPATH="$BASE_DIR/../Natives/$PLATFORM/browser"
  
  Rename "$LIBPATH/libSDL2_mixer*.a" "$LIBPATH/SDL2_mixer.a"
  Rename "$LIBPATH/libSDL2*.a" "$LIBPATH/SDL2.a"
  
  Transfer "$LIBPATH/SDL2.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_mixer.a" "$TARGETPATH"
  Transfer "$LIBPATH/libmpg123.a" "$TARGETPATH"
  Transfer "$LIBPATH/libogg.a" "$TARGETPATH"
  Transfer "$LIBPATH/libvorbis.a" "$TARGETPATH"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"

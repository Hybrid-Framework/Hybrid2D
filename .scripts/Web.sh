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
  emcc test.c -s USE_SDL=2 -o test.html
  
  Transfer "$BUILDPATH/sysroot/lib/wasm32-emscripten/libSDL2.a" "$BASE_DIR/../Natives/$PLATFORM/Universal/SDL2.a"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"

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
MODULES=("Emscripten" "SDL")

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
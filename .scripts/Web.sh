#!/usr/bin/env bash
set +e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Web"
MODULES=("Emscripten" "SDL2")
ARCHS=("Any")

LIBPATH="$MODULES_DIR/Emscripten/build_$PLATFORM/sysroot/lib/wasm32-emscripten"
TARGETPATH="$BASE_DIR/../Natives/$PLATFORM"

Emscripten()
{
  local INDEX="$1"
  local VERSION="3.1.34"

  Install "Emscripten" "https://github.com/emscripten-core/emsdk.git" "$VERSION"

  cd "$MODULES_DIR/$MODULE"
  ./emsdk install "$VERSION"
  ./emsdk activate "$VERSION"
  source ./emsdk_env.sh

  export EM_CACHE="$MODULES_DIR/$MODULE/build_$PLATFORM"
}

SDL2()
{
  local INDEX="$1"
  local VERSION="3.1.34"
  
  cd "$MODULES_DIR/Emscripten" || exit
  BUILDPATH="$MODULES_DIR/Emscripten/build_$PLATFORM"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  emcc --clear-cache
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
  Rename "$LIBPATH/libSDL2_image*.a" "$LIBPATH/SDL2_image.a"
  Rename "$LIBPATH/libSDL2_mixer*.a" "$LIBPATH/SDL2_mixer.a"
  Rename "$LIBPATH/libSDL2_ttf*.a" "$LIBPATH/SDL2_ttf.a"
  Rename "$LIBPATH/libSDL2*.a" "$LIBPATH/SDL2.a"

  Transfer "$LIBPATH/SDL2.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_image.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_mixer.a" "$TARGETPATH"
  Transfer "$LIBPATH/SDL2_ttf.a" "$TARGETPATH"
  Transfer "$LIBPATH/libfreetype.a" "$TARGETPATH"
  Transfer "$LIBPATH/libharfbuzz.a" "$TARGETPATH"
  Transfer "$LIBPATH/libjpeg.a" "$TARGETPATH"
  Transfer "$LIBPATH/libpng.a" "$TARGETPATH"
  Transfer "$LIBPATH/libmpg123.a" "$TARGETPATH"
  Transfer "$LIBPATH/libogg.a" "$TARGETPATH"
  Transfer "$LIBPATH/libvorbis.a" "$TARGETPATH"
  Transfer "$LIBPATH/libz.a" "$TARGETPATH"
  
  echo
  echo "Checking for invoke_"
  echo
  
  LLVMPATH="$MODULES_DIR/Emscripten/upstream/bin/llvm-nm.exe"
  
  for lib in "$TARGETPATH"/*.a; do
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

source "$BASE_DIR/Dependencies/Build.sh"
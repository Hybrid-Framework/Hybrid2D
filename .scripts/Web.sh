#!/usr/bin/env bash
set +e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Web"
RIDS=("Emscripten")
ARCHS=("Emscripten")
MODULES=("Emscripten" "SDL")

LIBPATH="$MODULES_DIR/Emscripten/build_$PLATFORM/sysroot/lib/wasm32-emscripten"
PORTPATH="$MODULES_DIR/Emscripten/upstream/emscripten/tools/ports"
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
  
  for file in "$DEPENDENCIES_DIR/System/Emscripten/"*.py; do
    [ -e "$file" ] || continue
    cp "$file" "$PORTPATH"
  done
  
  cd "$MODULES_DIR/Emscripten" || exit
  BUILDPATH="$MODULES_DIR/Emscripten/build_$PLATFORM"
  rm -rf "$BUILDPATH"
  mkdir -p "$BUILDPATH"
  cd "$BUILDPATH" || exit
  
  export EM_CACHE="$BUILDPATH"
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
  # Merge TTF
  cd "$LIBPATH" || exit
  rm -f TTF.a
  emar x libSDL2_ttf.a
  emar x libfreetype.a
  emar rcs TTF.a *.o
  rm -f *.o
  cp "$LIBPATH/TTF.a" "$NATIVES_DIR/TTF.a"
  
  # Merge IMAGE
  cd "$LIBPATH" || exit
  rm -f IMAGE.a
  emar x libSDL2_image_bmp-jpg-png.a
  emar x libz.a
  emar x libpng.a
  emar x libjpeg.a
  emar rcs IMAGE.a *.o
  rm -f *.o
  cp "$LIBPATH/IMAGE.a" "$NATIVES_DIR/IMAGE.a"
  
  # Merge MIXER
  cd "$LIBPATH" || exit
  rm -f MIXER.a
  emar x libSDL2_mixer_mp3-ogg-wav.a
  emar x libmpg123.a
  emar x libvorbis.a
  emar x libogg.a
  emar rcs MIXER.a *.o
  rm -f *.o
  cp "$LIBPATH/MIXER.a" "$NATIVES_DIR/MIXER.a"
  
  # Merge SDL
  cp "$LIBPATH/libSDL2.a" "$NATIVES_DIR/SDL2.a"
  
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
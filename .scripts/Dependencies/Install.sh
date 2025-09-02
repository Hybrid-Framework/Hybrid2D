#!/bin/bash
set -e

for MODULE in "${MODULES[@]}"; do
  cd "$BASE_DIR"

  if [ "$MODULE" = "LIBPNG" ]; then
    LIBPNG_PATH="$BASE_DIR/$MODULE"
    REPO="https://github.com/glennrp/libpng.git"
    VERSION="v1.6.9"
  fi

  if [ "$MODULE" = "FREETYPE" ]; then
    FREETYPE_PATH="$BASE_DIR/$MODULE"
    REPO="https://gitlab.freedesktop.org/freetype/freetype.git"
    VERSION="VER-2-13-2"
  fi

  if [ "$MODULE" = "SDL" ]; then
    SDL_PATH="$BASE_DIR/$MODULE"
    REPO="https://github.com/libsdl-org/SDL.git"
    VERSION="release-2.32.8"
  fi

  if [ "$MODULE" = "IMAGE" ]; then
    IMAGE_PATH="$BASE_DIR/$MODULE"
    REPO="https://github.com/libsdl-org/SDL_image.git"
    VERSION="release-2.8.8"
  fi

  if [ "$MODULE" = "MIXER" ]; then
    MIXER_PATH="$BASE_DIR/$MODULE"
    REPO="https://github.com/libsdl-org/SDL_mixer.git"
    VERSION="release-2.8.1"
  fi

  if [ "$MODULE" = "TTF" ]; then
    TTF_PATH="$BASE_DIR/$MODULE"
    REPO="https://github.com/libsdl-org/SDL_ttf.git"
    VERSION="release-2.24.0"
  fi

  if [ ! -d "$BASE_DIR/$MODULE" ]; then
      echo "$MODULE $VERSION [Downloading]"
      git clone "$REPO" "$BASE_DIR/$MODULE"
      cd "$BASE_DIR/$MODULE"
      git checkout "$VERSION"
      git submodule update --init --recursive
  else
      echo "$MODULE $VERSION [Found]"
  fi
done

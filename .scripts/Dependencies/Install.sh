#!/bin/bash
set -e

SDL="release-2.32.8"
IMAGE="release-2.8.8"
MIXER="release-2.8.1"
TTF="release-2.24.0"


# SDL2
if [ ! -d "$BASE_DIR/SDL" ]; then
    echo "SDL $SDL [Downloading]"
    git clone https://github.com/libsdl-org/SDL.git "$BASE_DIR/SDL"
    cd "$BASE_DIR/SDL"
    git checkout "$SDL"
    git submodule update --init --recursive
    cd "$BASE_DIR"
else
    echo "SDL $SDL [Found]"
fi

# IMAGE
if [ ! -d "$BASE_DIR/IMAGE" ]; then
    echo "IMAGE $IMAGE [Downloading]"
    git clone https://github.com/libsdl-org/SDL_image.git "$BASE_DIR/IMAGE"
    cd "$BASE_DIR/IMAGE"
    git checkout "$IMAGE"
    git submodule update --init --recursive
    cd "$BASE_DIR"
else
    echo "IMAGE $IMAGE [Found]"
fi

# MIXER
if [ ! -d "$BASE_DIR/MIXER" ]; then
    echo "MIXER $MIXER [Downloading]"
    git clone https://github.com/libsdl-org/SDL_mixer.git "$BASE_DIR/MIXER"
    cd "$BASE_DIR/MIXER"
    git checkout "$MIXER"
    git submodule update --init --recursive
    cd "$BASE_DIR"
else
    echo "MIXER $MIXER [Found]"
fi

# TTF
if [ ! -d "$BASE_DIR/TTF" ]; then
    echo "TTF $TTF [Downloading]"
    git clone https://github.com/libsdl-org/SDL_ttf.git "$BASE_DIR/TTF"
    cd "$BASE_DIR/TTF"
    git checkout "$TTF"
    git submodule update --init --recursive
    cd "$BASE_DIR"
else
    echo "TTF $TTF [Found]"
fi

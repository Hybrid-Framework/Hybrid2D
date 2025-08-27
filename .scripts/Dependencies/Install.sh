#!/bin/bash
set -e  # Exit on error

SDL="release-2.32.8"
IMAGE="release-2.8.8"
MIXER="release-2.8.1"
TTF="release-2.24.0"

# SDL2
if [ ! -d "SDL" ]; then
    echo "SDL $SDL [Downloading]"
    git clone https://github.com/libsdl-org/SDL.git SDL
    cd SDL
    git checkout "$SDL"
    git submodule update --init --recursive
    cd ..
else
    echo "SDL $SDL [Found]"
fi

# IMAGE
if [ ! -d "IMAGE" ]; then
    echo "IMAGE $IMAGE [Downloading]"
    git clone https://github.com/libsdl-org/SDL_image.git IMAGE
    cd IMAGE
    git checkout "$IMAGE"
    git submodule update --init --recursive
    cd ..
else
    echo "IMAGE $IMAGE [Found]"
fi

# MIXER
if [ ! -d "MIXER" ]; then
    echo "MIXER $MIXER [Downloading]"
    git clone https://github.com/libsdl-org/SDL_mixer.git MIXER
    cd MIXER
    git checkout "$MIXER"
    git submodule update --init --recursive
    cd ..
else
    echo "MIXER $MIXER [Found]"
fi

# TTF
if [ ! -d "TTF" ]; then
    echo "TTF $TTF [Downloading]"
    git clone https://github.com/libsdl-org/SDL_ttf.git TTF
    cd TTF
    git checkout "$TTF"
    git submodule update --init --recursive
    cd ..
else
    echo "TTF $TTF [Found]"
fi

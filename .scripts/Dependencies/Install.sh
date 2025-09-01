#!/bin/bash
set -e

SDL="release-2.32.8"
IMAGE="release-2.8.8"
MIXER="release-2.8.1"
TTF="release-2.24.0"

LOCALDIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)/.."

# SDL2
if [ ! -d "$LOCALDIR/SDL" ]; then
    echo "SDL $SDL [Downloading]"
    git clone https://github.com/libsdl-org/SDL.git "$LOCALDIR/SDL"
    cd "$LOCALDIR/SDL"
    git checkout "$SDL"
    git submodule update --init --recursive
    cd "$LOCALDIR"
else
    echo "SDL $SDL [Found]"
fi

# IMAGE
if [ ! -d "$LOCALDIR/IMAGE" ]; then
    echo "IMAGE $IMAGE [Downloading]"
    git clone https://github.com/libsdl-org/SDL_image.git "$LOCALDIR/IMAGE"
    cd "$LOCALDIR/IMAGE"
    git checkout "$IMAGE"
    git submodule update --init --recursive
    cd "$LOCALDIR"
else
    echo "IMAGE $IMAGE [Found]"
fi

# MIXER
if [ ! -d "$LOCALDIR/MIXER" ]; then
    echo "MIXER $MIXER [Downloading]"
    git clone https://github.com/libsdl-org/SDL_mixer.git "$LOCALDIR/MIXER"
    cd "$LOCALDIR/MIXER"
    git checkout "$MIXER"
    git submodule update --init --recursive
    cd "$LOCALDIR"
else
    echo "MIXER $MIXER [Found]"
fi

# TTF
if [ ! -d "$LOCALDIR/TTF" ]; then
    echo "TTF $TTF [Downloading]"
    git clone https://github.com/libsdl-org/SDL_ttf.git "$LOCALDIR/TTF"
    cd "$LOCALDIR/TTF"
    git checkout "$TTF"
    git submodule update --init --recursive
    cd "$LOCALDIR"
else
    echo "TTF $TTF [Found]"
fi

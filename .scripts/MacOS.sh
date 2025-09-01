# Dependencies
# XCode
# Cmake (3.5 or above)


#!/bin/bash
set -e
shopt -s extglob


# Base
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Install dependencies
source "$BASE_DIR/Dependencies/Install.sh"

# Errors
error_handler() {
    echo
    echo "An error occurred. Press Enter to exit..."
    read -r
}
trap error_handler ERR

# Architectures
ARCHS=("x86_64" "arm64")

cd $BASE_DIR

# Build
for ARCH in "${ARCHS[@]}"; do
    echo
    echo "============================================"
    echo "Building SDL MacOS - [$ARCH]"
    echo "============================================"
    echo

    cd SDL || exit
    BUILDPATH="$BASE_DIR/SDL/build_mac-$ARCH"
    INSTALLPATH="$BASE_DIR/SDL/install_mac-$ARCH"
    [[ -d "$BUILDPATH" ]] && rm -rf "$BUILDPATH"
    [[ -d "$INSTALLPATH" ]] && rm -rf "$INSTALLPATH"
    mkdir -p "$BUILDPATH" "$INSTALLPATH"
    cd "$BUILDPATH" || exit
    
    cmake .. -G "Unix Makefiles" \
    	-DSDL_SHARED=ON \
    	-DSDL_STATIC=OFF \
    	-DCMAKE_OSX_ARCHITECTURES=$ARCH \
    	-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
      -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
      -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

    cmake --build . --config Release
    cmake --install . --config Release
    cd $BASE_DIR

    echo
    echo "============================================"
    echo "Building SDL2 Image MacOS - [$ARCH]"
    echo "============================================"
    echo

    cd IMAGE || exit
    BUILDPATH="$BASE_DIR/IMAGE/build_mac-$ARCH"
    INSTALLPATH="$BASE_DIR/IMAGE/install_mac-$ARCH"
    [[ -d "$BUILDPATH" ]] && rm -rf "$BUILDPATH"
    [[ -d "$INSTALLPATH" ]] && rm -rf "$INSTALLPATH"
    mkdir -p "$BUILDPATH" "$INSTALLPATH"
    cd "$BUILDPATH" || exit

    cmake .. -G "Unix Makefiles" \
        -DSDL2IMAGE_BMP=ON \
        -DSDL2IMAGE_PNG=ON \
        -DSDL2IMAGE_JPG=ON \
        -DSDL2IMAGE_AVIF=OFF \
        -DSDL2IMAGE_WEBP=OFF \
        -DSDL2IMAGE_GIF=OFF \
        -DSDL2IMAGE_TIF=OFF \
        -DSDL2IMAGE_TGA=OFF \
        -DSDL2IMAGE_XCF=OFF \
        -DSDL2IMAGE_XPM=OFF \
        -DSDL2IMAGE_XV=OFF \
        -DSDL2IMAGE_LBM=OFF \
        -DSDL2IMAGE_PCX=OFF \
        -DSDL2IMAGE_PNM=OFF \
        -DSDL2IMAGE_QOI=OFF \
        -DSDL2IMAGE_SVG=OFF \
        -DSDL2IMAGE_JXL=OFF \
        -DBUILD_SHARED_LIBS=ON \
        -DSDL2IMAGE_SAMPLES=OFF \
        -DCMAKE_OSX_ARCHITECTURES=$ARCH \
        -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
        -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DSDL2_INCLUDE_DIR="$BASE_DIR/SDL/install_mac-$ARCH/include/SDL2" \
        -DSDL2_LIBRARY="$BASE_DIR/SDL/install_mac-$ARCH/lib/libSDL2.dylib"

    cmake --build . --config Release
    cmake --install . --config Release
    cd $BASE_DIR

    echo
    echo "============================================"
    echo "Building SDL2 Mixer MacOS - [$ARCH]"
    echo "============================================"
    echo

    cd MIXER || exit
    BUILDPATH="$BASE_DIR/MIXER/build_mac-$ARCH"
    INSTALLPATH="$BASE_DIR/MIXER/install_mac-$ARCH"
    [[ -d "$BUILDPATH" ]] && rm -rf "$BUILDPATH"
    [[ -d "$INSTALLPATH" ]] && rm -rf "$INSTALLPATH"
    mkdir -p "$BUILDPATH" "$INSTALLPATH"
    cd "$BUILDPATH" || exit

    cmake .. -G "Unix Makefiles" \
        -DSDL2MIXER_WAVE=ON \
        -DSDL2MIXER_MP3=ON \
        -DSDL2MIXER_OGG=ON \
        -DSDL2MIXER_OPUS=OFF \
        -DSDL2MIXER_FLAC=OFF \
        -DSDL2MIXER_MOD=OFF \
        -DSDL2MIXER_MIDI=OFF \
        -DSDL2MIXER_WAVPACK=OFF \
        -DBUILD_SHARED_LIBS=ON \
        -DSDL2MIXER_SAMPLES=OFF \
        -DCMAKE_OSX_ARCHITECTURES=$ARCH \
        -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
        -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DSDL2_INCLUDE_DIR="$BASE_DIR/SDL/install_mac-$ARCH/include/SDL2" \
        -DSDL2_LIBRARY="$BASE_DIR/SDL/install_mac-$ARCH/lib/libSDL2.dylib"

    cmake --build . --config Release
    cmake --install . --config Release
    cd $BASE_DIR

    echo
    echo "============================================"
    echo "Building SDL2 TTF MacOS - [$ARCH]"
    echo "============================================"
    echo

    cd TTF || exit
    BUILDPATH="$BASE_DIR/TTF/build_mac-$ARCH"
    INSTALLPATH="$BASE_DIR/TTF/install_mac-$ARCH"
    [[ -d "$BUILDPATH" ]] && rm -rf "$BUILDPATH"
    [[ -d "$INSTALLPATH" ]] && rm -rf "$INSTALLPATH"
    mkdir -p "$BUILDPATH" "$INSTALLPATH"
    cd "$BUILDPATH" || exit

    cmake .. -G "Unix Makefiles" \
        -DBUILD_SHARED_LIBS=ON \
        -DSDL2TTF_SAMPLES=OFF \
        -DCMAKE_OSX_ARCHITECTURES=$ARCH \
        -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
        -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DSDL2_INCLUDE_DIR="$BASE_DIR/SDL/install_mac-$ARCH/include/SDL2" \
        -DSDL2_LIBRARY="$BASE_DIR/SDL/install_mac-$ARCH/lib/libSDL2.dylib"

    cmake --build . --config Release
    cmake --install . --config Release
    cd $BASE_DIR

done


# Move Files ARCHS=("x86_64" "arm64")
declare -A ARCH_MAP=( [x86_64]=mac-x86_64 [arm64]=mac-arm64 )

for ARCH in "${ARCHS[@]}"; do
    DEST_SUBDIR="${ARCH_MAP[$ARCH]}"
    [[ -n "$DEST_SUBDIR" ]] || { echo "Unknown arch $ARCH"; continue; }

    DEST_DIR="$BASE_DIR/../Natives/MacOS/$DEST_SUBDIR"
    mkdir -p "$DEST_DIR"
    echo "Copying files for $ARCH to $DEST_DIR"

    for MODULE in SDL IMAGE MIXER TTF; do
        MOD_SRC="$BASE_DIR/$MODULE/install_mac-$ARCH/lib"
        [[ -d "$MOD_SRC" ]] || continue
        cp "$MOD_SRC"/*.dylib "$DEST_DIR"/ 2>/dev/null || true
    done
done


# Complete
read -p "Build complete."

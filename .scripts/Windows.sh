# Dependencies
# Visual Studio Build Tools 2022
# Desktop Development with C++ Workload
# MSVC v143- VS 2022 C++ ARM Build Tools (Latest)
# MSVC v143- VS 2022 C++ ARM64/ARM64EC Build Tools (Latest)
# MSVC v143- VS 2022 C++ x64/x86 Build Tools (Latest)
# Cmake (3.5 or above)


#!/bin/bash
set -e
shopt -s extglob


# Install
source ./Dependencies/Install.sh


# Errors
error_handler() {
    echo
    echo "An error occurred. Press Enter to exit..."
    read -r
}
trap error_handler ERR


# Architectures
ARCHS=("x64" "win32" "arm64")


# Build
for ARCH in "${ARCHS[@]}"; do
    echo
    echo "============================================"
    echo "Building SDL Windows - [$ARCH]"
    echo "============================================"
    echo

    cd SDL || exit

    [[ -d "build_win-$ARCH" ]] && rm -rf "build_win-$ARCH"
    [[ -d "install_win-$ARCH" ]] && rm -rf "install_win-$ARCH"
    mkdir -p "install_win-$ARCH" "build_win-$ARCH"
    cd "build_win-$ARCH" || exit

    EXTRAFLAGS=""
    if [ "$ARCH" == "arm64" ]; then
        # Wrap the flag in quotes to prevent path parsing issues
        EXTRAFLAGS='"/forceInterlockedFunctions-"'
    fi
    
    MSYS_NO_PATHCONV=1 cmake .. -G "Visual Studio 17 2022" -A "$ARCH" -Wno-dev \
    	-DSDL_SHARED=ON \
    	-DSDL_STATIC=OFF \
    	-DCMAKE_C_FLAGS="$EXTRAFLAGS" \
    	-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    	-DCMAKE_INSTALL_PREFIX=../install_win-"$ARCH"

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 Image Windows - [$ARCH]"
    echo "============================================"
    echo

    cd IMAGE || exit
    [[ -d "build_win-$ARCH" ]] && rm -rf "build_win-$ARCH"
    [[ -d "install_win-$ARCH" ]] && rm -rf "install_win-$ARCH"
    mkdir -p "install_win-$ARCH" "build_win-$ARCH"
    cd "build_win-$ARCH" || exit

    cmake .. -G "Visual Studio 17 2022" -A "$ARCH" -Wno-dev \
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
        -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
        -DCMAKE_INSTALL_PREFIX=../install_win-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_win-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_win-"$ARCH"/lib/SDL2.lib

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 Mixer Windows - [$ARCH]"
    echo "============================================"
    echo

    cd MIXER || exit
    [[ -d "build_win-$ARCH" ]] && rm -rf "build_win-$ARCH"
    [[ -d "install_win-$ARCH" ]] && rm -rf "install_win-$ARCH"
    mkdir -p "install_win-$ARCH" "build_win-$ARCH"
    cd "build_win-$ARCH" || exit

    cmake .. -G "Visual Studio 17 2022" -A "$ARCH" -Wno-dev \
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
        -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
        -DCMAKE_INSTALL_PREFIX=../install_win-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_win-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_win-"$ARCH"/lib/SDL2.lib

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 TTF Windows - [$ARCH]"
    echo "============================================"
    echo

    cd TTF || exit
    [[ -d "build_win-$ARCH" ]] && rm -rf "build_win-$ARCH"
    [[ -d "install_win-$ARCH" ]] && rm -rf "install_win-$ARCH"
    mkdir -p "install_win-$ARCH" "build_win-$ARCH"
    cd "build_win-$ARCH" || exit

    cmake .. -G "Visual Studio 17 2022" -A "$ARCH" -Wno-dev \
        -DBUILD_SHARED_LIBS=ON \
        -DSDL2TTF_SAMPLES=OFF \
        -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
        -DCMAKE_INSTALL_PREFIX=../install_win-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_win-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_win-"$ARCH"/lib/SDL2.lib

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

done


# Move Files
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
declare -A ARCH_MAP=( [x64]=win-x64 [win32]=win-x86 [arm64]=win-arm64 )

for ARCH in "${ARCHS[@]}"; do
    DEST_SUBDIR="${ARCH_MAP[$ARCH]}"
    [[ -n "$DEST_SUBDIR" ]] || { echo "Unknown arch $ARCH"; continue; }

    DEST_DIR="$BASE_DIR/../Natives/Windows/$DEST_SUBDIR"
    mkdir -p "$DEST_DIR"
    echo "Copying DLLs for $ARCH to $DEST_DIR"

    for MODULE in SDL IMAGE MIXER TTF; do
        MOD_SRC="$BASE_DIR/$MODULE/install_win-$ARCH/bin"
        [[ -d "$MOD_SRC" ]] || continue
        cp "$MOD_SRC"/*.dll "$DEST_DIR"/ 2>/dev/null || true
    done
done


# Remove Folders
rm -rf SDL IMAGE MIXER TTF

# Complete
read -p "Build complete."

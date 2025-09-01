# Dependencies
# XCode
# Freetype (Universal) (Build using cmake from git)
# Cmake (3.5 or above)

#!/bin/bash
set -e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Properties
PLATFORM="MacOS"
LIB_NAMES=("libSDL2.dylib" "libSDL2_ttf.dylib")
MODULES=("SDL" "TTF")
RIDS=("osx-arm64")
ARCHS=("arm64")
LIB_LOCATION="lib"


# Build PNG (Universal)
LIBPNGINSTALLPATH="$BASE_DIR/LIBPNG"

if [ ! -d "$LIBPNGINSTALLPATH" ]; then
    echo "LIBPNG [Downloading]"
    git clone https://github.com/glennrp/libpng.git "$LIBPNGINSTALLPATH"
    cd "$LIBPNGINSTALLPATH"
else
    echo "LIBPNG [Found]"
fi

for ai in "${!ARCHS[@]}"; do
  ARCH="${ARCHS[$ai]}"
  rm -rf "$LIBPNGINSTALLPATH/build_$ARCH"
  mkdir -p "$LIBPNGINSTALLPATH/build_$ARCH"
  cd "$LIBPNGINSTALLPATH/build_$ARCH"

  cmake .. \
    -DCMAKE_BUILD_TYPE=Release \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DPNG_TESTS=OFF \
    -DPNG_EXECUTABLES=OFF

  make -j$(sysctl -n hw.logicalcpu)
done

# Build Freetype (Universal)
FREETYPEINSTALLPATH="$BASE_DIR/FREETYPE"

if [ ! -d "$FREETYPEINSTALLPATH" ]; then
    echo "Freetype [Downloading]"
    git clone https://gitlab.freedesktop.org/freetype/freetype.git "$FREETYPEINSTALLPATH"
    cd "$FREETYPEINSTALLPATH"
else
    echo "FREETYPE [Found]"
fi

for ai in "${!ARCHS[@]}"; do
  ARCH="${ARCHS[$ai]}"
  rm -rf "$FREETYPEINSTALLPATH/build_$ARCH"
  mkdir -p "$FREETYPEINSTALLPATH/build_$ARCH"
  cd "$FREETYPEINSTALLPATH/build_$ARCH"

  cmake .. \
    -DCMAKE_BUILD_TYPE=Release \
    -DBUILD_SHARED_LIBS=OFF \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DPNG_PNG_INCLUDE_DIR="$LIBPNGINSTALLPATH/build_$ARCH" \
    -DPNG_LIBRARY="$LIBPNGINSTALLPATH/build_$ARCH/libpng16.a"

  make -j$(sysctl -n hw.logicalcpu)
done


SDL()
{
  cmake .. -G "Unix Makefiles" \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH
    
    cmake --build . --config Release
    cmake --install . --config Release
}

IMAGE()
{
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
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.dylib
    
    cmake --build . --config Release
    cmake --install . --config Release
}

MIXER()
{
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
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.dylib
    
    cmake --build . --config Release
    cmake --install . --config Release
}

TTF()
{
  cmake .. -G "Unix Makefiles" \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2TTF_SAMPLES=OFF \
    -DCMAKE_OSX_ARCHITECTURES=$ARCH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/libSDL2.dylib \
    -DFREETYPE_LIBRARY="$FREETYPEINSTALLPATH/build_$ARCH/libfreetype.a" \
    -DFREETYPE_INCLUDE_DIRS="$FREETYPEINSTALLPATH/build_$ARCH/include" \
    -DCMAKE_SHARED_LINKER_FLAGS="-lz -lbz2 -lpng"

  cmake --build . --config Release
  cmake --install . --config Release
}




# Run
source "$BASE_DIR/Dependencies/Build.sh"

# Complete
read -p "Build complete."

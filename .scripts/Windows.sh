# Dependencies
# Visual Studio Build Tools 2022
# Desktop Development with C++ Workload
# MSVC v143- VS 2022 C++ ARM64/ARM64EC Build Tools (Latest)
# MSVC v143- VS 2022 C++ x64/x86 Build Tools (Latest)
# Cmake (3.5 or above)

#!/bin/bash
set -e

# Properties
PLATFORM="Windows"
LIB_NAMES=("SDL2.dll" "SDL2_image.dll" "SDL2_mixer.dll" "SDL2_ttf.dll")
RIDS=("win-x64" "win-x86" "win-arm64")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")
ARCHS=("x64" "win32" "arm64")
LIB_LOCATION="bin"

SDL()
{
  EXTRAFLAGS=""
  if [ "$ARCH" == "arm64" ]; then
      EXTRAFLAGS="-forceInterlockedFunctions-"
  fi
  
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_C_FLAGS=$EXTRAFLAGS \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH

  cmake --build . --config Release
  cmake --install . --config Release
}

IMAGE()
{
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
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
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
    -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/SDL2.lib
    
  cmake --build . --config Release
  cmake --install . --config Release
}

MIXER()
{
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
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
      -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
      -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
      -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/SDL2.lib

  cmake --build . --config Release
  cmake --install . --config Release
}

TTF()
{
  cmake .. -G "Visual Studio 17 2022" -A $ARCH -Wno-dev \
      -DBUILD_SHARED_LIBS=ON \
      -DSDL2TTF_SAMPLES=OFF \
      -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
      -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
      -DSDL2_INCLUDE_DIR=$SDLINSTALLPATH/include/SDL2 \
      -DSDL2_LIBRARY=$SDLINSTALLPATH/lib/SDL2.lib

  cmake --build . --config Release
  cmake --install . --config Release
}

# Run
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source "$BASE_DIR/Dependencies/Build.sh"

# Complete
read -p "Build complete."

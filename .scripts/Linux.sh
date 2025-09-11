#!/usr/bin/env bash
set -uo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Linux"
ARCHS=("x86_64" "i686" "aarch64")
RIDS=("linux-x64" "linux-x86" "linux-arm64")
COMPILERS=("x86_64-linux-gnu-gcc" "i686-linux-gnu-gcc" "aarch64-linux-gnu-gcc")
ROOTPATHS=("" "i686-linux-gnu" "/usr/aarch64-linux-gnu")
MODULES=("SDL2")

echo
echo "WARNING!"
echo "Linux.sh is about to call a submodule (Dependencies/Linux-Setup.sh)"
echo "This will change add system architectures and download compilers & libraries"
echo "This will apply changes to the /etc/apt/sources.list file for accessing ports for external files for other architectures"
echo
read -p "Do you wish to run Linux-Setup? (y/n): " choice

case "$choice" in
  y|Y|yes|YES|Yes)
    echo
    echo "Running Linux-Setup"
    source "$DEPENDENCIES_DIR/Linux-Setup.sh"
    echo
    ;;
  n|N|no|NO|No)
    echo
    echo "Skipping Linux-Setup"
    echo "If you have issues with the build I recommend running Linux-Setup!"
    echo
    ;;
  *)
    echo "⚠️ Invalid choice. Please enter y or n."
    exit 1
    ;;
esac


SDL2()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  local COMPILER=${COMPILERS[$INDEX]}
  local ROOTPATH=${ROOTPATHS[$INDEX]}
  
  Install "SDL2" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_SYSTEM_NAME=Linux \
    -DCMAKE_SYSTEM_PROCESSOR=$ARCH \
    -DCMAKE_C_COMPILER=$COMPILER \
    -DCMAKE_C_FLAGS="-Wno-int-to-pointer-cast -Wno-pointer-to-int-cast" \
    -DSDL_TESTS=OFF \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH/lib/lib$MODULE.so" "$BASE_DIR/../Natives/Desktop/$RID"
}

COMPLETE()
{
  read -p "Build complete."
}

source "$BASE_DIR/Dependencies/Build.sh"
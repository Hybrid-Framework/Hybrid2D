#!/usr/bin/env bash
set -euo pipefail

ANDROID_NDK="$HOME/AppData/Local/Android/Sdk/ndk/21.4.7075529/build/cmake/android.toolchain.cmake"
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Android"
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
RIDS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations"

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$INSTALLPATH/lib/libSDL2.so" "$BASE_DIR/../Natives/$PLATFORM/$RID/libSDL2.so"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "release-2.8.8"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
    -DSDL2IMAGE_BMP=ON \
    -DSDL2IMAGE_PNG=ON \
    -DSDL2IMAGE_JPG=ON \
    -DSDL2IMAGE_WEBP=OFF \
    -DSDL2IMAGE_AVIF=OFF \
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
    -DSDL2IMAGE_TESTS=OFF \
    -DSDL2IMAGE_SAMPLES=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2IMAGE_VENDORED=ON \
    -DSDL2IMAGE_DEPS_SHARED=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$INSTALLPATH/lib/libSDL2_image.so" "$BASE_DIR/../Natives/$PLATFORM/$RID/libIMAGE.so"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_ABI=$ARCH \
    -DANDROID_PLATFORM=android-21 \
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
    -DSDL2MIXER_VENDORED=ON \
    -DSDL2MIXER_DEPS_SHARED=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$INSTALLPATH/lib/libSDL2_mixer.so" "$BASE_DIR/../Natives/$PLATFORM/$RID/libMIXER.so"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "release-2.24.0"
  
  cd "$MODULES_DIR/$MODULE" || exit
  BUILDPATH="$MODULES_DIR/$MODULE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/$MODULE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit
  
  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_PLATFORM=android-21 \
    -DANDROID_ABI=$ARCH \
    -DBUILD_SHARED_LIBS=ON \
    -DSDL2TTF_VENDORED=ON \
    -DSDL2TTF_SAMPLES=OFF \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX=$INSTALLPATH \
    -DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    -DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
    -DSDL2_INCLUDE_DIR=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/include/SDL2 \
    -DSDL2_LIBRARY=$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/libSDL2.so

  cmake --build . --config Release
  cmake --install . --config Release
  
  Transfer "$INSTALLPATH/lib/libSDL2_ttf.so" "$BASE_DIR/../Natives/$PLATFORM/$RID/libTTF.so"
}

COMPLETE()
{
  # Dirty Patch SDLActivity...
  # This patch may break in future releases..
  local PATCHFILE="$MODULES_DIR/SDL/android-project/app/src/main/java/org/libsdl/app/SDLActivity.java"
  
  echo "$PATCHFILE"
  
  # Patch 1
  local SEARCH="class SDLActivity"
  local INSERT="protected void main() {}"
  
  if ! grep -qF "$INSERT" "$PATCHFILE"; then
  
      LINENUM=$(grep -n "$SEARCH" "$PATCHFILE" | cut -d: -f1)
  
      if [[ -n "$LINENUM" ]]; then
          LINENUM=$((LINENUM + 1))
          sed -i "${LINENUM}i $INSERT" "$PATCHFILE"
      fi
  fi
  
  # Patch 2
  local SEARCH="SDLActivity.nativeRunMain"
  local INSERT="SDLActivity.mSingleton.main();"
  
  if ! grep -qF "$INSERT" "$PATCHFILE"; then
  
      LINENUM=$(grep -n "$SEARCH" "$PATCHFILE" | cut -d: -f1)
  
      if [[ -n "$LINENUM" ]]; then
          LINENUM=$((LINENUM + 1))
          sed -i "${LINENUM}i $INSERT" "$PATCHFILE"
      fi
  fi
  
  # Build SDLActivity.jar
  export PATH="$PATH:/c/Program Files/Android/Android Studio/jbr/bin"
  local ANDROID_JAR="$HOME/AppData/Local/Android/Sdk/platforms/android-36/android.jar"
  cd $MODULES_DIR/SDL/android-project/app/src/main/java || exit 1
  mkdir -p out
  JAVA_FILES=$(find . -name "*.java")
  javac -source 1.8 -target 1.8 -classpath "$ANDROID_JAR" -d out $JAVA_FILES
  jar cf SDLActivity.jar -C out .
  jar tf SDLActivity.jar
  
  # Move Files
  mkdir -p "$BASE_DIR/../Platforms/Android/Jars"
  cp SDLActivity.jar "$BASE_DIR/../Platforms/Android/Jars"
  
  # Complete
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
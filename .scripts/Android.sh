#!/usr/bin/env bash
set -e

cleanup()
{
    local exit_code=$?
    if [ $exit_code -ne 0 ]; then
        echo "Script failed with exit code $exit_code."
        read -p "Press Enter to exit."
    fi
}

trap cleanup EXIT

ANDROID_NDK="$HOME/AppData/Local/Android/Sdk/ndk/29.0.13846066/build/cmake/android.toolchain.cmake"
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Android"
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
RIDS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
MODULES=("SDL" "IMAGE" "MIXER" "TTF")

NATIVES_DIR="$BASE_DIR/../Natives/$PLATFORM"
rm -rf "$NATIVES_DIR"

SDL()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL.git" ""
  
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
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DSDL_ANDROID_JAR=OFF \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3.so" "$NATIVES_DIR/$RID/libSDL3.so"
}

IMAGE()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_image.git" ""
  
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
    -DSDLIMAGE_BMP=ON \
    -DSDLIMAGE_JPG=ON \
    -DSDLIMAGE_PNG=ON \
    -DSDLIMAGE_AVIF=OFF \
    -DSDLIMAGE_WEBP=OFF \
    -DSDLIMAGE_GIF=OFF \
    -DSDLIMAGE_JXL=OFF \
    -DSDLIMAGE_LBM=OFF \
    -DSDLIMAGE_PCX=OFF \
    -DSDLIMAGE_PNM=OFF \
    -DSDLIMAGE_QOI=OFF \
    -DSDLIMAGE_SVG=OFF \
    -DSDLIMAGE_TGA=OFF \
    -DSDLIMAGE_TIF=OFF \
    -DSDLIMAGE_XCF=OFF \
    -DSDLIMAGE_XPM=OFF \
    -DSDLIMAGE_XV=OFF \
    -DSDLIMAGE_VENDORED=ON \
    -DSDLIMAGE_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_image.so" "$NATIVES_DIR/$RID/libSDL3_image.so"
}

MIXER()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
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
    -DSDLMIXER_MP3_DRMP3=ON \
    -DSDLMIXER_VORBIS_STB=ON \
    -DSDLMIXER_WAVE=ON \
    -DSDLMIXER_VORBIS_VORBISFILE=OFF \
    -DSDLMIXER_VORBIS_TREMOR=OFF \
    -DSDLMIXER_MIDI_TIMIDITY=OFF \
    -DSDLMIXER_FLAC_LIBFLAC=OFF \
    -DSDLMIXER_FLAC_DRFLAC=OFF \
    -DSDLMIXER_MP3_MPG123=OFF \
    -DSDLMIXER_GME_SHARED=OFF \
    -DSDLMIXER_MOD_XMP=OFF \
    -DSDLMIXER_WAVPACK=OFF \
    -DSDLMIXER_AIFF=OFF \
    -DSDLMIXER_OPUS=OFF \
    -DSDLMIXER_VOC=OFF \
    -DSDLMIXER_GME=OFF \
    -DSDLMIXER_AU=OFF \
    -DSDLMIXER_VENDORED=ON \
    -DSDLMIXER_DEPS_SHARED=OFF \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_mixer.so" "$NATIVES_DIR/$RID/libSDL3_mixer.so"
}

TTF()
{
  local INDEX="$1"
  local ARCH="${ARCHS[$INDEX]}"
  local RID="${RIDS[$INDEX]}"
  
  Github "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
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
    -DSDLTTF_HARFBUZZ=OFF \
    -DSDLTTF_PLUTOSVG=OFF \
    -DSDLTTF_VENDORED=ON \
    -DBUILD_SHARED_LIBS=ON \
    -DCMAKE_BUILD_TYPE=Release \
    -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
    -DCMAKE_INSTALL_PREFIX="$INSTALLPATH" \
    -DSDL3_DIR="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH/lib/cmake/SDL3"

  cmake --build . --config Release
  cmake --install . --config Release
  
  mkdir -p "$NATIVES_DIR/$RID"
  cp "$INSTALLPATH/lib/libSDL3_ttf.so" "$NATIVES_DIR/$RID/libSDL3_ttf.so"
}

COMPLETE()
{
  JAR_DIR="$BASE_DIR/../Platforms/$PLATFORM/Jars"
  JAVA_DIR="$MODULES_DIR/SDL/android-project/app/src/main/java"

  export PATH="$PATH:/c/Program Files/Android/Android Studio/jbr/bin"
  local ANDROID_JAR="$HOME/AppData/Local/Android/Sdk/platforms/android-36/android.jar"
  cd "$JAVA_DIR" || exit 1
  mkdir -p out
  
  JAVA_FILES=$(find . -name "*.java")
  javac -source 1.8 -target 1.8 -classpath "$ANDROID_JAR" -d out $JAVA_FILES
  jar cf SDLActivity.jar -C out .
  jar tf SDLActivity.jar

  rm -rf "$JAR_DIR"
  mkdir -p "$JAR_DIR"
  
  cp "$JAVA_DIR/SDLActivity.jar" "$JAR_DIR/SDLActivity.jar"
  read -p "Build complete."
}

source "$DEPENDENCIES_DIR/Build.sh"
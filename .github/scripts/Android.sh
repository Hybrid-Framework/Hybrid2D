#!/usr/bin/env bash
set -e

echo "Building... OS: $OS PLATFORM: $PLATFORM ARCH: $ARCH RID: $RID"

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
NATIVES_DIR="$BASE_DIR/../../Hybrid/Platforms/Hybrid2D.Android/Natives"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"
rm -rf "$NATIVES_DIR"
mkdir -p "$NATIVES_DIR"

MODULES=("SDL" "IMAGE" "MIXER" "TTF")

ENVIRONMENT()
{
  echo "Setting up android environment..."
  
  ANDROID_SDK="$ANDROID_HOME"
  ANDROID_NDK="$ANDROID_NDK_HOME/build/cmake/android.toolchain.cmake"
  
  NDK_VERSION="29.0.13846066"
  ANDROID_TARGET="26"
  ANDROID_COMPILE="36"
  
  export PATH="$ANDROID_HOME/cmdline-tools/latest/bin:$ANDROID_HOME/tools/bin:$PATH"
  
  yes | sdkmanager --install "platform-tools"
  yes | sdkmanager --install "platforms;android-$ANDROID_TARGET"
  yes | sdkmanager --install "platforms;android-$ANDROID_COMPILE"
  yes | sdkmanager --install "ndk;$NDK_VERSION"
}

SDL()
{
  Github "SDL" "https://github.com/libsdl-org/SDL.git" ""
  
  cd "$MODULES_DIR/SDL" || exit
  BUILDPATH="$MODULES_DIR/SDL/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/SDL/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_SHARED_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_EXE_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_PLATFORM=android-$ANDROID_TARGET \
    -DANDROID_ABI="$ARCH" \
    -DSDL_SHARED=ON \
    -DSDL_STATIC=OFF \
    -DSDL_ANDROID_JAR=OFF \
    -DSDL_TEST_LIBRARY=OFF \
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
  Github "SDL_IMAGE" "https://github.com/libsdl-org/SDL_image.git" ""
  
  cd "$MODULES_DIR/SDL_IMAGE" || exit
  BUILDPATH="$MODULES_DIR/SDL_IMAGE/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/SDL_IMAGE/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_SHARED_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_EXE_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_PLATFORM=android-$ANDROID_TARGET \
    -DANDROID_ABI="$ARCH" \
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
    -DSDLIMAGE_PNG_LIBPNG=OFF \
    -DSDLIMAGE_ANI=OFF \
    -DSDLIMAGE_TESTS=OFF \
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
  Github "SDL_MIXER" "https://github.com/libsdl-org/SDL_mixer.git" ""
  
  cd "$MODULES_DIR/SDL_MIXER" || exit
  BUILDPATH="$MODULES_DIR/SDL_MIXER/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/SDL_MIXER/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_SHARED_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_EXE_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_PLATFORM=android-$ANDROID_TARGET \
    -DANDROID_ABI="$ARCH" \
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
    -DSDLMIXER_TESTS=OFF \
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
  Github "SDL_TTF" "https://github.com/libsdl-org/SDL_ttf.git" ""
  
  cd "$MODULES_DIR/SDL_TTF" || exit
  BUILDPATH="$MODULES_DIR/SDL_TTF/build_$PLATFORM-$ARCH"
  INSTALLPATH="$MODULES_DIR/SDL_TTF/install_$PLATFORM-$ARCH"
  rm -rf "$BUILDPATH" "$INSTALLPATH"
  mkdir -p "$BUILDPATH" "$INSTALLPATH"
  cd "$BUILDPATH" || exit

  cmake .. -G Ninja -Wno-dev \
    -DCMAKE_SHARED_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_EXE_LINKER_FLAGS="-Wl,-z,max-page-size=16384" \
    -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK" \
    -DANDROID_PLATFORM=android-$ANDROID_TARGET \
    -DANDROID_ABI="$ARCH" \
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
  export PATH="$PATH:$JAVA_HOME/bin"
  
  JAR_DIR="$BASE_DIR/../../Hybrid/Jars"
  JAVA_DIR="$MODULES_DIR/SDL/android-project/app/src/main/java"

  ANDROID_JAR="$ANDROID_HOME/platforms/android-$ANDROID_COMPILE/android.jar"
  cd "$JAVA_DIR" || exit 1
  mkdir -p out

  JAVA_FILES=$(find . -name "*.java")
  javac -source 1.8 -target 1.8 -classpath "$ANDROID_JAR" -d out $JAVA_FILES

  jar cf SDLActivity.jar -C out .
  jar tf SDLActivity.jar

  rm -rf "$JAR_DIR"
  mkdir -p "$JAR_DIR"
  cp SDLActivity.jar "$JAR_DIR/SDLActivity.jar"

  echo "Build complete."
}


source "$DEPENDENCIES_DIR/Build.sh"
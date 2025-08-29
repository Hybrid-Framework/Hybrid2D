# Dependencies
# Install Android Studio (https://developer.android.com/studio#get-android-studio)
# Install Ninja.exe (https://github.com/ninja-build/ninja/releases)
# Install SDK (Android Studio > SDK Tools (36.0 API)
# Install NDK (Android Studio > SDK Tools > NDK (Side by side) (21.4.7075529)
# Install CMAKE (https://cmake.org/download)
# Cmake (3.5 or above)

#!/bin/bash
set -e
shopt -s extglob

# Base
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Install
source ./Dependencies/Install.sh


# Errors
error_handler() {
    echo
    echo "An error occurred. Press Enter to exit..."
    read -r
}
trap error_handler ERR

# Default Android location
ANDROID_NDK=$HOME/AppData/Local/Android/Sdk/ndk/21.4.7075529


# Architectures ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")
ARCHS=("armeabi-v7a" "arm64-v8a" "x86" "x86_64")


# Build
for ARCH in "${ARCHS[@]}"; do
    echo
    echo "============================================"
    echo "Building SDL Android - [$ARCH]"
    echo "============================================"
    echo

    cd SDL || exit

    [[ -d "build-android-$ARCH" ]] && rm -rf "build-android-$ARCH"
    [[ -d "install_android-$ARCH" ]] && rm -rf "install_android-$ARCH"
    mkdir -p "install_android-$ARCH" "build-android-$ARCH"
    cd "build-android-$ARCH" || exit

    cmake .. -G Ninja -Wno-dev \
        -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
        -DANDROID_ABI=$ARCH \
        -DANDROID_PLATFORM=android-21 \
        -DSDL_SHARED=ON \
        -DSDL_STATIC=OFF \
	-DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
	-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    	-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_INSTALL_PREFIX=../install_android-$ARCH

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 Image Android - [$ARCH]"
    echo "============================================"
    echo

    cd IMAGE || exit
    [[ -d "build-android-$ARCH" ]] && rm -rf "build-android-$ARCH"
    [[ -d "install_android-$ARCH" ]] && rm -rf "install_android-$ARCH"
    mkdir -p "install_android-$ARCH" "build-android-$ARCH"
    cd "build-android-$ARCH" || exit

    cmake .. -G Ninja -Wno-dev \
        -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
        -DANDROID_ABI=$ARCH \
        -DANDROID_PLATFORM=android-21 \
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
	-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    	-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_INSTALL_PREFIX=../install_android-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_android-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_android-"$ARCH"/lib/libSDL2.so

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 Mixer Android - [$ARCH]"
    echo "============================================"
    echo

    cd MIXER || exit
    [[ -d "build-android-$ARCH" ]] && rm -rf "build-android-$ARCH"
    [[ -d "install_android-$ARCH" ]] && rm -rf "install_android-$ARCH"
    mkdir -p "install_android-$ARCH" "build-android-$ARCH"
    cd "build-android-$ARCH" || exit

    cmake .. -G Ninja -Wno-dev \
        -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
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
        -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
	-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    	-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_INSTALL_PREFIX=../install_android-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_android-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_android-"$ARCH"/lib/libSDL2.so

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

    echo
    echo "============================================"
    echo "Building SDL2 TTF Android - [$ARCH]"
    echo "============================================"
    echo

    cd TTF || exit
    [[ -d "build-android-$ARCH" ]] && rm -rf "build-android-$ARCH"
    [[ -d "install_android-$ARCH" ]] && rm -rf "install_android-$ARCH"
    mkdir -p "install_android-$ARCH" "build-android-$ARCH"
    cd "build-android-$ARCH" || exit

    cmake .. -G Ninja -Wno-dev \
        -DCMAKE_TOOLCHAIN_FILE="$ANDROID_NDK/build/cmake/android.toolchain.cmake" \
        -DANDROID_ABI=$ARCH \
        -DANDROID_PLATFORM=android-21 \
        -DBUILD_SHARED_LIBS=ON \
        -DSDL2TTF_SAMPLES=OFF \
        -DCMAKE_POLICY_VERSION_MINIMUM=3.5 \
	-DCMAKE_C_FLAGS="-Wno-deprecated-declarations" \
    	-DCMAKE_CXX_FLAGS="-Wno-deprecated-declarations" \
        -DCMAKE_INSTALL_PREFIX=../install_android-"$ARCH" \
        -DSDL2_INCLUDE_DIR=../../SDL/install_android-"$ARCH"/include/SDL2 \
        -DSDL2_LIBRARY=../../SDL/install_android-"$ARCH"/lib/libSDL2.so

    cmake --build . --config Release
    cmake --install . --config Release
    cd ../..

done




# Build SDLActivity.jar
export PATH="$PATH:/c/Program Files/Android/Android Studio/jbr/bin"
ANDROID_JAR="$HOME/AppData/Local/Android/Sdk/platforms/android-36/android.jar"
cd SDL/android-project/app/src/main/java || exit 1
mkdir -p out
JAVA_FILES=$(find . -name "*.java")
javac -source 1.8 -target 1.8 -classpath "$ANDROID_JAR" -d out $JAVA_FILES
jar cf SDLActivity.jar -C out .
jar tf SDLActivity.jar



# Move Files
mkdir -p "$BASE_DIR/../Natives/Android"
cp SDLActivity.jar "$BASE_DIR/../Natives/Android/"

declare -A ARCH_MAP=( [armeabi-v7a]=android-armeabi-v7a [arm64-v8a]=android-arm64-v8a [x86]=android-x86 [x86_64]=android-x86_64 )

for ARCH in "${ARCHS[@]}"; do
    DEST_SUBDIR="${ARCH_MAP[$ARCH]}"
    [[ -n "$DEST_SUBDIR" ]] || { echo "Unknown arch $ARCH"; continue; }

    DEST_DIR="$BASE_DIR/../Natives/Android/$DEST_SUBDIR"
    mkdir -p "$DEST_DIR"
    echo "Copying files for $ARCH to $DEST_DIR"

    for MODULE in SDL IMAGE MIXER TTF; do
        MOD_SRC="$BASE_DIR/$MODULE/install_android-$ARCH/lib/"
        [[ -d "$MOD_SRC" ]] || continue
        cp "$MOD_SRC"/*.so "$DEST_DIR"/ 2>/dev/null || true
    done
done


# Complete
read -p "Build complete."

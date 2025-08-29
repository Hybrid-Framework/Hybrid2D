#!/bin/bash
set -e

# Base
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"


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
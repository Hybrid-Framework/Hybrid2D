#Android.sh

#!/usr/bin/env bash
set -euo pipefail

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

# Build SDLActivity.jar
export PATH="$PATH:/c/Program Files/Android/Android Studio/jbr/bin"
ANDROID_JAR="$HOME/AppData/Local/Android/Sdk/platforms/android-36/android.jar"
cd $MODULES_DIR/SDL2/android-project/app/src/main/java || exit 1
mkdir -p out
JAVA_FILES=$(find . -name "*.java")
javac -source 1.8 -target 1.8 -classpath "$ANDROID_JAR" -d out $JAVA_FILES
jar cf SDLActivity.jar -C out .
jar tf SDLActivity.jar

# Move Files
mkdir -p "$BASE_DIR/../Platforms/Android/Jars"
cp SDLActivity.jar "$BASE_DIR/../Platforms/Android/Jars"

read -p "Build complete."
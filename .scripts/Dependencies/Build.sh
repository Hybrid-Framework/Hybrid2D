#!/usr/bin/env bash
set -euo pipefail

# Build
for i in "${!ARCHS[@]}"; do
    ARCH="${ARCHS[$i]}"
    RID="${RIDS[$i]}"

    for MODULE in "${MODULES[@]}"; do
        declare -n MOD="$MODULE"

        echo
        echo "$MODULE [$PLATFORM $ARCH]"
        echo

        # Download module if not found
        if [ ! -d "$BASE_DIR/$MODULE" ]; then
            echo "$MODULE ${MOD[VERSION]} [Downloading]"
            git clone "${MOD[GITHUB]}" "$BASE_DIR/$MODULE"
            cd "$BASE_DIR/$MODULE"
            git checkout "${MOD[VERSION]}"
            git submodule update --init --recursive
        else
            echo "$MODULE ${MOD[VERSION]} [Found]"
        fi

        # Directories
        cd "$BASE_DIR/$MODULE"
        BUILDPATH="$BASE_DIR/$MODULE/build_${PLATFORM}-$ARCH"
        INSTALLPATH="$BASE_DIR/$MODULE/install_${PLATFORM}-$ARCH"
        rm -rf "$BUILDPATH" "$INSTALLPATH"
        mkdir -p "$BUILDPATH" "$INSTALLPATH"
        cd "$BUILDPATH"

        # Build
        eval "${MOD[CMAKE]} -DCMAKE_INSTALL_PREFIX=$INSTALLPATH"
        cmake --build . --config Release
        cmake --install . --config Release
    done
done

# Transfer
for i in "${!ARCHS[@]}"; do
    ARCH="${ARCHS[$i]}"
    RID="${RIDS[$i]}"

    DEST_DIR="$BASE_DIR/../Natives/$PLATFORM/$RID"
    mkdir -p "$DEST_DIR"

    for MODULE in "${MODULES[@]}"; do
        declare -n MOD="$MODULE"

        LIB_SRC="$BASE_DIR/$MODULE/install_${PLATFORM}-$ARCH/$LOCATION"

        if [ -f "$LIB_SRC/${MOD[LIB]}" ]; then
            echo "Copying ${MOD[LIB]} from $LIB_SRC to $DEST_DIR"
            cp "$LIB_SRC/${MOD[LIB]}" "$DEST_DIR/"
        else
            echo "Warning: ${MOD[LIB]} not found in $LIB_SRC"
        fi
    done
done

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

        # DOWNLOAD
        if [ ! -d "$MODULES_DIR/$MODULE" ]; then
          
            # CLONE
            echo "$MODULE ${MOD[VERSION]} [Downloading]"
            git clone "${MOD[GITHUB]}" "$MODULES_DIR/$MODULE"
            cd "$MODULES_DIR/$MODULE"
            
            # CHECKOUT
            if [ -n "${MOD[VERSION]}" ]; then
                git checkout "${MOD[VERSION]}"
            fi
            
            # SUB MODULES
            git submodule update --init --recursive
        else
            echo "$MODULE ${MOD[VERSION]} [Found]"
        fi

        # REQUIREMENTS
        cd "$MODULES_DIR/$MODULE"
        BUILDPATH="$MODULES_DIR/$MODULE/build_${PLATFORM}-$ARCH"
        INSTALLPATH="$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH"
        rm -rf "$BUILDPATH" "$INSTALLPATH"
        mkdir -p "$BUILDPATH" "$INSTALLPATH"
        cd "$BUILDPATH"

        # GENERATE
        if [ -n "${MOD[CMAKE]}" ]; then
            eval "${MOD[CMAKE]} -DCMAKE_INSTALL_PREFIX=$INSTALLPATH"
        fi
        
        # BUILD
        if [ -n "${MOD[BUILD]}" ]; then
            eval "${MOD[BUILD]}"
        fi
        
        # INSTALL
        if [ -n "${MOD[INSTALL]}" ]; then
            eval "${MOD[INSTALL]}"
        fi

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

        LIB_SRC="$MODULES_DIR/$MODULE/install_${PLATFORM}-$ARCH/$LOCATION"

        if [ -f "$LIB_SRC/${MOD[LIB]}" ]; then
            echo "Copying ${MOD[LIB]} from $LIB_SRC to $DEST_DIR"
            cp "$LIB_SRC/${MOD[LIB]}" "$DEST_DIR/"
        else
            echo "Warning: ${MOD[LIB]} not found in $LIB_SRC"
        fi
    done
done

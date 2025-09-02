#!/bin/bash
set -e

# Install
source "$BASE_DIR/Dependencies/Install.sh"

## Architectures
for ai in "${!ARCHS[@]}"; do

  ARCH="${ARCHS[$ai]}"
  
  # Modules
  for MODULE in "${MODULES[@]}"; do

    echo
    echo "Building $MODULE $PLATFORM [$ARCH]"
    echo

    # Directory
    cd "$BASE_DIR/$MODULE" || exit
    BUILDPATH="$BASE_DIR/$MODULE/build_$PLATFORM-$ARCH"
    INSTALLPATH="$BASE_DIR/$MODULE/install_$PLATFORM-$ARCH"
    rm -rf "$BUILDPATH" "$INSTALLPATH"
    mkdir -p "$BUILDPATH" "$INSTALLPATH"
    cd "$BUILDPATH" || exit

    # Run Module Commands
    if declare -f "$MODULE" > /dev/null; then
      "$MODULE"
    fi

  done

done

# Transfer
for ai in "${!ARCHS[@]}"; do
    ARCH="${ARCHS[$ai]}"
    RID="${RIDS[$ai]}"

    DEST_DIR="$BASE_DIR/../Natives/$PLATFORM/$RID"
    mkdir -p "$DEST_DIR"

    for mi in "${!MODULES[@]}"; do
        MODULE="${MODULES[$mi]}"
        LIB_NAME="${LIB_NAMES[$mi]}"

        LIB_SRC="$BASE_DIR/$MODULE/install_$PLATFORM-$ARCH/$LIB_LOCATION"
        
        if [ -d "$LIB_SRC" ]; then
            echo "Copying files for $LIB_SRC to $DEST_DIR"
            cp "$LIB_SRC/$LIB_NAME" "$DEST_DIR"/ 2>/dev/null || true
        fi
    done
done

# Complete
read -p "Build complete."


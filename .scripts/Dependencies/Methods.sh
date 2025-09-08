# Install.sh

#!/usr/bin/env bash
set -euo pipefail

Install()
{
    local NAME="$1"
    local GITHUB="${2:-}"
    local VERSION="${3:-}"
    local MODULE_DIR="$MODULES_DIR/$NAME"

    if [ ! -d "$MODULE_DIR" ]; then
      
        if [ -n "$GITHUB" ]; then
          
            # GITHUB
            echo "$NAME $VERSION [Downloading from $GITHUB]"
            git clone "$GITHUB" "$MODULE_DIR"
            cd "$MODULE_DIR"

            # CHECKOUT
            if [ -n "$VERSION" ]; then
                git checkout "$VERSION"
            fi

            # MODULES
            git submodule update --init --recursive
        else
            echo "Error: No GitHub URL provided for $NAME"
            return 1
        fi
    else
        # ALREADY FOUND
        echo "$NAME $VERSION [Already Installed]"
    fi
}

Transfer()
{
    local SRC="$1"
    local DEST="$2"

    if [ -f "$SRC" ]; then
        # SRC is a file
        mkdir -p "$DEST"
        echo "Copying file $SRC → $DEST/"
        cp "$SRC" "$DEST/"

    elif [ -d "$SRC" ]; then
        # SRC is a directory
        mkdir -p "$DEST"
        echo "Copying directory $SRC → $DEST/"
        cp -r "$SRC/." "$DEST/"

    else
        echo "Warning: Source $SRC does not exist"
        return 1
    fi
}

Rename()
{
    local PATTERN="$1"
    local DEST="$2"

    shopt -s nullglob
    local FILES=($PATTERN)

    if [[ ${#FILES[@]} -eq 0 ]]; then
        echo "Warning: No files match $PATTERN — skipping"
        return 0
    fi

    for SRC in "${FILES[@]}"; do
        echo "Renaming $SRC → $DEST"
        mv "$SRC" "$DEST"
        break
    done
}
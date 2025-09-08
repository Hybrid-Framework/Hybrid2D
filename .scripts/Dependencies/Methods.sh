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

    # Ensure SRC exists
    if [ ! -e "$SRC" ]; then
        echo "Error: Source $SRC does not exist"
        return 1
    fi

    if [ -d "$DEST" ]; then
        # If DEST is a directory, append filename
        mkdir -p "$DEST"
        DEST="$DEST/$(basename "$SRC")"
    else
        # Ensure parent directory exists
        mkdir -p "$(dirname "$DEST")"
    fi

    echo "Moving $SRC → $DEST"
    mv "$SRC" "$DEST"
}






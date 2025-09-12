#!/usr/bin/env bash
set +e

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

Transfer() {
    local SRC="${1:-}"   # default empty string if undefined
    local DEST="${2:-}"  # default empty string if undefined

    # Check if SRC is non-empty
    if [[ -z "$SRC" || -z "$DEST" ]]; then
        echo "Skipping transfer: Source or destination is empty"
        return 0
    fi

    if [[ -f "$SRC" ]]; then
        mkdir -p "$DEST"
        echo "Copying file $SRC → $DEST/"
        cp "$SRC" "$DEST/"
    elif [[ -d "$SRC" ]]; then
        mkdir -p "$DEST"
        echo "Copying directory $SRC → $DEST/"
        cp -r "$SRC/." "$DEST/"
    else
        echo "Skipping transfer: Source $SRC does not exist"
    fi
}


Rename() {
    local PATTERN="${1:-}"  # default empty string if undefined
    local DEST="${2:-}"     # default empty string if undefined

    # Skip if PATTERN or DEST is empty
    if [[ -z "$PATTERN" || -z "$DEST" ]]; then
        echo "Skipping rename: Pattern or destination is empty"
        return 0
    fi

    shopt -s nullglob
    local FILES=($PATTERN)
    shopt -u nullglob

    if [[ ${#FILES[@]} -eq 0 ]]; then
        echo "Skipping rename: No files match $PATTERN"
        return 0
    fi

    mkdir -p "$(dirname "$DEST")"  # ensure destination directory exists
    echo "Renaming ${FILES[0]} → $DEST"
    mv "${FILES[0]}" "$DEST"
}



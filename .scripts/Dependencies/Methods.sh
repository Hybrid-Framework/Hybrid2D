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
          
            echo "$NAME $VERSION [Downloading from $GITHUB]"
            git clone "$GITHUB" "$MODULE_DIR"
            cd "$MODULE_DIR"

            if [ -n "$VERSION" ]; then
                git checkout "$VERSION"
            fi

            git submodule update --init --recursive
        else
            echo "Error: No GitHub URL provided for $NAME"
            return 1
        fi
    else
        
        echo "$NAME $VERSION [Already Installed]"
    fi
}

Transfer()
{
    local SRC="${1:-}"
    local DEST="${2:-}"

    if [[ -z "$SRC" || -z "$DEST" ]]; then
        echo "Skipping transfer: Source or destination is empty"
        return 0
    fi

    if [[ ! -e "$SRC" ]]; then
        echo "Skipping transfer: Source does not exist: $SRC"
        return 0
    fi

    # Determine if DEST is a directory (ends with /) or a file
    local DEST_DIR
    local DEST_FILE
    if [[ -d "$DEST" || "${DEST: -1}" == "/" ]]; then
        DEST_DIR="$DEST"
        DEST_FILE=""
    else
        DEST_DIR=$(dirname "$DEST")
        DEST_FILE=$(basename "$DEST")
    fi

    mkdir -p "$DEST_DIR"

    if [[ -f "$SRC" ]]; then
        if [[ -n "$DEST_FILE" ]]; then
            echo "Copying file $SRC → $DEST_DIR/$DEST_FILE"
            cp "$SRC" "$DEST_DIR/$DEST_FILE"
        else
            echo "Copying file $SRC → $DEST_DIR/"
            cp "$SRC" "$DEST_DIR/"
        fi
    elif [[ -d "$SRC" ]]; then
        echo "Copying directory $SRC → $DEST_DIR/"
        cp -r "$SRC/." "$DEST_DIR/"
    fi
}

Rename()
{
    local PATTERN="${1:-}"
    local DEST="${2:-}"

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

    mkdir -p "$(dirname "$DEST")"
    echo "Renaming ${FILES[0]} → $DEST"
    mv "${FILES[0]}" "$DEST"
}

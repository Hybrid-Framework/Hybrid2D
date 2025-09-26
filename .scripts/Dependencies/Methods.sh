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

Transfer() {
    local SRC_PATTERN="${1:-}"
    local DEST="${2:-}"

    if [[ -z "$SRC_PATTERN" || -z "$DEST" ]]; then
        echo "Skipping transfer: Source or destination is empty"
        return 0
    fi

    # Expand wildcard pattern
    shopt -s nullglob
    local FILES=($SRC_PATTERN)
    shopt -u nullglob

    if [[ ${#FILES[@]} -eq 0 ]]; then
        echo "Skipping transfer: No files match $SRC_PATTERN"
        return 0
    fi

    # Determine if DEST is a directory (ends with / or exists as a dir) or a file
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

    if [[ -n "$DEST_FILE" ]]; then
        # DEST is a specific file
        echo "Copying ${FILES[0]} → $DEST_DIR/$DEST_FILE"
        cp "${FILES[0]}" "$DEST_DIR/$DEST_FILE"
        if [[ ${#FILES[@]} -gt 1 ]]; then
            echo "Warning: Multiple files match $SRC_PATTERN but only the first was copied to $DEST"
        fi
    else
        # DEST is a folder, copy all files
        for f in "${FILES[@]}"; do
            if [[ -f "$f" ]]; then
                echo "Copying file $f → $DEST_DIR/"
                cp "$f" "$DEST_DIR/"
            elif [[ -d "$f" ]]; then
                echo "Copying directory $f → $DEST_DIR/"
                cp -r "$f/." "$DEST_DIR/"
            fi
        done
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

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

    shopt -s nullglob
    local FILES=($SRC)
    shopt -u nullglob

    if [[ ${#FILES[@]} -eq 0 ]]; then
        echo "Skipping transfer: No files match $SRC"
        return 0
    fi

    mkdir -p "$DEST"
    for FILE in "${FILES[@]}"; do
        if [[ -f "$FILE" ]]; then
            echo "Copying file $FILE → $DEST/"
            cp "$FILE" "$DEST/"
        elif [[ -d "$FILE" ]]; then
            echo "Copying directory $FILE → $DEST/"
            cp -r "$FILE/." "$DEST/"
        fi
    done
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

Hash()
{
    local URL="$1"
    local VERSION="$2"
    local ZIPFILE

    if [[ -z "$URL" ]]; then
        echo "Error: URL is required for Hash()"
        return 1
    fi

    # Replace {VERSION} placeholder in URL if present
    if [[ -n "$VERSION" ]]; then
        URL="${URL//\{VERSION\}/$VERSION}"
        ZIPFILE="$(basename "$URL")"
    else
        ZIPFILE="$(basename "$URL")"
    fi

    echo "Downloading $ZIPFILE from $URL..."
    curl -L -o "$ZIPFILE" "$URL"

    if [[ ! -f "$ZIPFILE" ]]; then
        echo "Error: Failed to download $ZIPFILE"
        return 1
    fi

    echo "Computing SHA-512 hash for $ZIPFILE..."

    local HASH=""
    if command -v sha512sum >/dev/null 2>&1; then
        HASH=$(sha512sum "$ZIPFILE" | awk '{print $1}')
    elif command -v openssl >/dev/null 2>&1; then
        HASH=$(openssl dgst -sha512 "$ZIPFILE" | awk '{print $2}')
    else
        echo "Error: Neither sha512sum nor openssl found."
        return 1
    fi

    echo 
    echo "SHA-512 hash for $ZIPFILE:"
    echo "$HASH"
    echo 
}



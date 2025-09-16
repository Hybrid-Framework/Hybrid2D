#!/usr/bin/env bash
set +e

echo "Enter the zip file URL:"
read -r URL

if [[ -z "$URL" ]]; then
    echo "Error: No URL provided."
    exit 1
fi

ZIPFILE="$(basename "$URL")"

echo "Downloading $ZIPFILE from $URL..."
curl -L -o "$ZIPFILE" "$URL"

if [[ ! -f "$ZIPFILE" ]]; then
    echo "Error: Failed to download $ZIPFILE"
    exit 1
fi

echo "Computing SHA-512 hash for $ZIPFILE..."

HASH=""
if command -v sha512sum >/dev/null 2>&1; then
    HASH=$(sha512sum "$ZIPFILE" | awk '{print $1}')
elif command -v openssl >/dev/null 2>&1; then
    HASH=$(openssl dgst -sha512 "$ZIPFILE" | awk '{print $2}')
else
    echo "Error: Neither sha512sum nor openssl found."
    rm -f "$ZIPFILE"
    exit 1
fi

echo
echo "SHA-512 hash for $ZIPFILE:"
echo "$HASH"
echo

rm -f "$ZIPFILE"
read -p "Hash calculation complete."

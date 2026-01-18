#!/usr/bin/env bash
set -e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
FRAMEWORK_DIR="$BASE_DIR/../../../Engine/Framework/"
DOC_FILE="$BASE_DIR/../../../docs/Documentation.md"
echo "Building docs..."

# ------ MAIN PAGE ------------------------------------------------------------------------------------------------
echo "# Documentation" > "$DOC_FILE"
echo "This Documentation is designed for quick reference." >> "$DOC_FILE"
echo >> "$DOC_FILE"


# ------ MODULES --------------------------------------------------------------------------------------------------
FIND_CMD=(find "$FRAMEWORK_DIR" -type f -name "*.cs")

IGNORE_FOLDERS=(
    "*/SDL3/*"
    "*/SDL3.Image/*"
    "*/SDL3.Mixer/*"
    "*/SDL3.Ttf/*"
    "*/Internal/*"
    "*/Types/*"
)
IGNORE_FILES=(
    "*/App.cs"
)

for folder in "${IGNORE_FOLDERS[@]}"; do
    FIND_CMD+=(! -path "$folder")
done

for file in "${IGNORE_FILES[@]}"; do
    FIND_CMD+=(! -name "$(basename "$file")")
done

CS_FILES=$("${FIND_CMD[@]}")

for file in $CS_FILES; do
    class_name=$(basename "$file")
    echo "---" >> "$DOC_FILE"
    echo "### $class_name" >> "$DOC_FILE"
    echo '```csharp' >> "$DOC_FILE"

    awk '
      # Capture comment lines starting with //
      /^\s*\/\/ / {
        comment = $0
        gsub(/^\s*\/\/\s*/, "", comment)  # Remove the leading "// "
        next
      }

      # Skip any line that declares a class
      / class / { next }

      # Capture public static method lines
      /^\s*public static/ {
        method_line = $0
        gsub(/\{.*/, "", method_line)            # Remove opening brace
        gsub(/\s*$/, "", method_line)            # Trim trailing space
        gsub(/^[ \t]+/, "", method_line)
        gsub(/public static\s+/, "", method_line)  # Remove "public static"

        # Print method + full comment
        printf "%s // %s\n", method_line, comment
        comment=""
      }
    ' "$file" >> "$DOC_FILE"

    echo '```' >> "$DOC_FILE"
    echo >> "$DOC_FILE"
done


# ------ Types ---------------------------------------------------------------------------------------------------
echo "---" >> "$DOC_FILE"
echo "## Types" >> "$DOC_FILE"
echo >> "$DOC_FILE"

# Table of folders/files to ignore inside Types (or anywhere)
IGNORE_FOLDERS=(
    "*/Internal/*"
    "*/Obsolete/*"
)
IGNORE_FILES=(
    "*/App.cs"
    "*/Example.cs"
)

# Build find command for Types folder
FIND_CMD=(find "$FRAMEWORK_DIR" -type f -path "*/Types/*.cs")

# Append ignore folders
for folder in "${IGNORE_FOLDERS[@]}"; do
    FIND_CMD+=(! -path "$folder")
done

# Append ignore files
for file in "${IGNORE_FILES[@]}"; do
    FIND_CMD+=(! -name "$(basename "$file")")
done

# Execute find
TYPE_FILES=$("${FIND_CMD[@]}")

for file in $TYPE_FILES; do
    type_name=$(basename "$file")
    echo "### $type_name" >> "$DOC_FILE"
    echo '```csharp' >> "$DOC_FILE"

    echo 'Information' >> "$DOC_FILE"

    echo '```' >> "$DOC_FILE"
    echo >> "$DOC_FILE"
done



# ------ MAIN PAGE ------------------------------------------------------------------------------------------------



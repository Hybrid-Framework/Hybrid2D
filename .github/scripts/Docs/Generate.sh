#!/usr/bin/env bash
set -e

# ------ PATHS ----------------------------------------------------------------------------------------------------
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
FRAMEWORK_DIR="$BASE_DIR/../../../Engine/Framework"
DOC_FILE="$BASE_DIR/../../../docs/Documentation.md"
echo "Building docs..."


# ------ MAIN PAGE ------------------------------------------------------------------------------------------------
echo "# Documentation" > "$DOC_FILE"
echo "This Documentation is designed for quick reference." >> "$DOC_FILE"

echo >> "$DOC_FILE"


# ------ Classes --------------------------------------------------------------------------------------------------
CLASS_FILES=(
    "$FRAMEWORK_DIR/Window/Window.cs"
    "$FRAMEWORK_DIR/Graphics/Graphics.cs"
    "$FRAMEWORK_DIR/Graphics/Texture.cs"
    "$FRAMEWORK_DIR/Graphics/Font.cs"
    "$FRAMEWORK_DIR/Inputs/Input.cs"
    "$FRAMEWORK_DIR/Audio/Audio.cs"
    "$FRAMEWORK_DIR/Storage/Storage.cs"
    "$FRAMEWORK_DIR/System/Device.cs"
    "$FRAMEWORK_DIR/Utility/Time.cs"
    "$FRAMEWORK_DIR/Utility/Debug.cs"
    "$FRAMEWORK_DIR/Utility/Maths.cs"
)
  
for file in "${CLASS_FILES[@]}"; do
    class_name=$(basename "$file")
    echo "---" >> "$DOC_FILE"
    echo "### $class_name" >> "$DOC_FILE"
    echo '```csharp' >> "$DOC_FILE"

    awk '
      /^\s*\/\/ / {
        comment = $0
        gsub(/^\s*\/\/\s*/, "", comment)
        next
      }

      / class / { next }

      /^\s*public static/ {
        method_line = $0
        gsub(/\{.*/, "", method_line)
        gsub(/\s*$/, "", method_line)
        gsub(/^[ \t]+/, "", method_line)
        gsub(/public static\s+/, "", method_line)
        printf "%s // %s\n", method_line, comment
        comment=""
      }
    ' "$file" >> "$DOC_FILE"

    echo '```' >> "$DOC_FILE"
    echo >> "$DOC_FILE"
done


# ------ Structs --------------------------------------------------------------------------------------------------
STRUCT_FILES=(
    "$FRAMEWORK_DIR/Types/Structs/Color.cs"
    "$FRAMEWORK_DIR/Types/Structs/Point.cs"
    "$FRAMEWORK_DIR/Types/Structs/Rect.cs"
)
  
for file in "${STRUCT_FILES[@]}"; do
    class_name=$(basename "$file")
    echo "---" >> "$DOC_FILE"
    echo "### $class_name" >> "$DOC_FILE"
    echo '```csharp' >> "$DOC_FILE"
    
    echo 'Information' >> "$DOC_FILE"
    
    echo '```' >> "$DOC_FILE"
    echo >> "$DOC_FILE"
done


# ------ Enums --------------------------------------------------------------------------------------------------
ENUM_FILES=(
    "$FRAMEWORK_DIR/Types/Enums/Axis.cs"
    "$FRAMEWORK_DIR/Types/Enums/Button.cs"
    "$FRAMEWORK_DIR/Types/Enums/Key.cs"
)
  
for file in "${ENUM_FILES[@]}"; do
    class_name=$(basename "$file")
    echo "---" >> "$DOC_FILE"
    echo "### $class_name" >> "$DOC_FILE"
    echo '```csharp' >> "$DOC_FILE"
    
    echo 'Information' >> "$DOC_FILE"
    
    echo '```' >> "$DOC_FILE"
    echo >> "$DOC_FILE"
done


# ------ Complete --------------------------------------------------------------------------------------------------
echo "Documentation generated successfully."
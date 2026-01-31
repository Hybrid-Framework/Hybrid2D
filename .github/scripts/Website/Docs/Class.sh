#!/usr/bin/env bash

generate_classes()
{
    CLASS_FILES=(
        "$FRAMEWORK_DIR/Window/Window.cs"
        "$FRAMEWORK_DIR/Graphics/Graphics.cs"
        "$FRAMEWORK_DIR/Graphics/Texture.cs"
        "$FRAMEWORK_DIR/Graphics/Font.cs"
        "$FRAMEWORK_DIR/Inputs/Keyboard/Keyboard.cs"
        "$FRAMEWORK_DIR/Inputs/Mouse/Mouse.cs"
        "$FRAMEWORK_DIR/Inputs/Gamepad/Gamepad.cs"
        "$FRAMEWORK_DIR/Inputs/Touch/Touch.cs"
        "$FRAMEWORK_DIR/Inputs/Touch/TouchKeyboard.cs"
        "$FRAMEWORK_DIR/Utility/Clipboard.cs"
        "$FRAMEWORK_DIR/Audio/Audio.cs"
        "$FRAMEWORK_DIR/Storage/Storage.cs"
        "$FRAMEWORK_DIR/Utility/Misc.cs"
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
    
          /^\s*public/ {
            method_line = $0
            gsub(/\{.*/, "", method_line)
            gsub(/\s*$/, "", method_line)
            gsub(/^[ \t]+/, "", method_line)
            printf "%s // %s\n", method_line, comment
            comment=""
          }
        ' "$file" >> "$DOC_FILE"
    
        echo '```' >> "$DOC_FILE"
        echo >> "$DOC_FILE"
    done
}

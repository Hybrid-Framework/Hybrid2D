#!/usr/bin/env bash

generate_structs()
{
    STRUCT_FILES=(
        "$FRAMEWORK_DIR/Types/Structs/Color.cs"
        "$FRAMEWORK_DIR/Types/Structs/Point.cs"
        "$FRAMEWORK_DIR/Types/Structs/Rect.cs"
    )

    for file in "${STRUCT_FILES[@]}"; do
        struct_name=$(basename "$file")
        echo "---" >> "$DOC_FILE"
        echo "### $struct_name" >> "$DOC_FILE"
        echo '```csharp' >> "$DOC_FILE"
    
        awk '
          /^\s*\/\/ / {
            comment = $0
            gsub(/^\s*\/\/\s*/, "", comment)
            next
          }
    
          / struct / { next }
    
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

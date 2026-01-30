#!/usr/bin/env bash

generate_enums()
{
    ENUM_FILES=(
        "$FRAMEWORK_DIR/Types/Enums/Axis.cs"
        "$FRAMEWORK_DIR/Types/Enums/Button.cs"
        "$FRAMEWORK_DIR/Types/Enums/Key.cs"
    )

    for file in "${ENUM_FILES[@]}"; do
        enum_file=$(basename "$file")
        echo "---" >> "$DOC_FILE"
        echo "### $enum_file" >> "$DOC_FILE"
        echo '```csharp' >> "$DOC_FILE"

        awk '
          # Only lines ending with a comma
          /^[ \t]*[A-Za-z0-9_]+[ \t]*,?[ \t]*$/ {
            # remove trailing comma and spaces
            gsub(/,/, "")
            gsub(/^\s+|\s+$/, "", $0)
            
            # skip unwanted values
            if ($0 == "Unknown" || $0 == "None") next
            
            if (length($0) > 0) print $0
          }
        ' "$file" >> "$DOC_FILE"

        echo '```' >> "$DOC_FILE"
        echo >> "$DOC_FILE"
    done
}

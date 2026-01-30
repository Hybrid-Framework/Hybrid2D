#!/usr/bin/env bash
set -e

# ------ PATHS ----------------------------------------------------------------------------------------------------
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SAMPLE_FILE="$BASE_DIR/../../../../docs/Samples.md"
SAMPLE_PROJECTS="$BASE_DIR/../../../../Samples"
OUTPUT_DIR="$BASE_DIR/../../../../docs/Samples"
DOCS_DIR="$BASE_DIR/../../../../docs"
echo "Building samples..."
mkdir -p "$OUTPUT_DIR"

# ------ MAIN PAGE ------------------------------------------------------------------------------------------------
{
  echo "# Samples"
  echo
  echo "These samples are designed for quick reference and live preview in the browser"
  echo
  echo "Version: $HYBRID_VERSION"
  echo
} > "$SAMPLE_FILE"


# ------ BUILD SAMPLES --------------------------------------------------------------------------------------------
for sample_folder in "$SAMPLE_PROJECTS"/*/; do
    
    # Build sample
    sample_name=$(basename "$sample_folder")
    sample_csproj="$sample_folder/$sample_name.csproj"
    
    if [ ! -f "$sample_csproj" ]; then
      echo "Skipping $sample_name (no csproj found)"
      continue
    fi
      
    sample_slug=$(echo "$sample_name" | tr '[:upper:]' '[:lower:]' | tr ' ' '-')
    sample_output="$OUTPUT_DIR/$sample_slug"
    mkdir -p "$sample_output"
    
    echo "Publishing project $sample_name..."
    dotnet publish "$sample_csproj" -c Release -o "$sample_output"
    
    # Generate sample page
    sample_md="$OUTPUT_DIR/$sample_slug.md"
    game_cs="$sample_folder/Game.cs"
    {
      echo "# $sample_name"
      echo
      echo "<iframe src=\"./wwwroot/index.html\" width=\"610\" height=\"410\"></iframe>"
      echo
      if [ -f "$game_cs" ]; then
          echo '```csharp'
          while IFS= read -r line; do
              echo "$line"
          done < "$game_cs"
          echo '```'
          echo
      fi
    } > "$sample_md"

    
    # Link sample page
    {
      echo "## $sample_name"
      echo
      echo "[▶ Open](./$sample_slug)"
      echo
    } >> "$SAMPLE_FILE"
    
done

# ------ Complete -------------------------------------------------------------------------------------------------
echo "Samples generated successfully."

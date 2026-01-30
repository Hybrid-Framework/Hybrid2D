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
  echo "### Version: $HYBRID_VERSION"
  echo
  echo "These samples are designed for quick reference and can be run live in the browser."
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
    {
      echo "# $sample_name"
      echo
      echo "<iframe src="/Samples/$sample_slug/wwwroot/index.html" width="610" height="410"></iframe>"
      echo
    } > "$sample_md"

    # Link sample page
    {
      echo "## $sample_name"
      echo
      echo "[▶ Open Sample Page](samples/$sample_slug.md)"
      echo
    } >> "$SAMPLE_FILE"
    
    # Source Code
    game_cs="$sample_folder/Game.cs"
    if [ -f "$game_cs" ]; then
        echo '' >> "$sample_md"
        echo '```csharp' >> "$sample_md"
        cat "$game_cs" >> "$sample_md"
        echo '' >> "$sample_md"
        echo '```' >> "$sample_md"
        echo '' >> "$sample_md"
    fi
    
done

# ------ Complete -------------------------------------------------------------------------------------------------
echo "Samples generated successfully."

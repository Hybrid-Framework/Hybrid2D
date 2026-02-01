#!/usr/bin/env bash
set -e

# ------ PATHS ----------------------------------------------------------------------------------------------------
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$BASE_DIR/../../../../"
SOURCE_FILE="$BASE_DIR/../../../../App/App/Samples"
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


# ------ BUILD ENTIRE SOLUTION ----------------------------------------------------------------------------------

echo "Building entire solution..."
dotnet clean "$REPO_ROOT"
dotnet build "$REPO_ROOT" -c Release

# ------ BUILD SAMPLES ------------------------------------------------------------------------------------------

for sample_folder in "$SAMPLE_PROJECTS"/*/; do
    
    sample_name=$(basename "$sample_folder")
    sample_csproj="$sample_folder/$sample_name.csproj"

    if [ ! -f "$sample_csproj" ]; then
      echo "Skipping $sample_name (no csproj found)"
      continue
    fi
    
    sample_slug=$(echo "$sample_name" | tr '[:upper:]' '[:lower:]' | tr ' ' '_')
    sample_output="$OUTPUT_DIR/$sample_slug"
    mkdir -p "$sample_output"

    # Find the target framework folder inside bin/Release
    bin_release="$sample_folder/bin/Release"
    tfm_folder=$(find "$bin_release" -mindepth 1 -maxdepth 1 -type d | head -n 1)
    
    wwwroot_dir="$tfm_folder/wwwroot"
    if [ -d "$wwwroot_dir" ]; then
        echo "Copying wwwroot for $sample_name from $tfm_folder..."
        cp -r "$wwwroot_dir" "$sample_output"/
    else
        echo "No wwwroot found for $sample_name in $tfm_folder, skipping copy."
    fi
    
    # Generate sample page
    sample_md="$OUTPUT_DIR/$sample_slug.md"
    game_cs="$SOURCE_FILE/$sample_slug.cs"
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

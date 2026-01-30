#!/usr/bin/env bash
set -e

# ------ PATHS ----------------------------------------------------------------------------------------------------
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
FRAMEWORK_DIR="$BASE_DIR/../../../../Hybrid/Hybrid/Framework"
DOC_FILE="$BASE_DIR/../../../../docs/Documentation.md"
echo "Building docs..."

# ------ MAIN PAGE ------------------------------------------------------------------------------------------------
{
  echo "# Documentation"
  echo
  echo "This documentation is designed for quick reference"
  echo
  echo "Version: $HYBRID_VERSION"
  echo
} > "$DOC_FILE"

# ------ CLASSES --------------------------------------------------------------------------------------------------
source "$BASE_DIR/Class.sh"
generate_classes

# ------ STRUCTS --------------------------------------------------------------------------------------------------
source "$BASE_DIR/Struct.sh"
generate_structs

# ------ ENUMS ----------------------------------------------------------------------------------------------------
source "$BASE_DIR/Enum.sh"
generate_enums

# ------ Complete -------------------------------------------------------------------------------------------------
echo "Documentation generated successfully."
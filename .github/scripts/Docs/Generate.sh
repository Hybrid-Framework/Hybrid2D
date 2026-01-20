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
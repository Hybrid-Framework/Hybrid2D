# Dependencies
# Cmake
# XCode

#!/bin/bash
set -e
shopt -s extglob


# Base
BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"

# Install
source ./Dependencies/Install.sh


# Errors
error_handler() {
    echo
    echo "An error occurred. Press Enter to exit..."
    read -r
}
trap error_handler ERR


# Complete
read -p "Build complete."

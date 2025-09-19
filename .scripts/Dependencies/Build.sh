#!/usr/bin/env bash
set -euo pipefail

for MODULE in "${MODULES[@]}"; do
    echo
    echo "Running $MODULE $PLATFORM"
    echo
    
    if declare -p ARCHS &>/dev/null && ((${#ARCHS[@]} > 0)); then
        for ai in "${!ARCHS[@]}"; do
            echo
            echo "[${ARCHS[$ai]}]"
            echo

            if declare -f "$MODULE" > /dev/null; then
                "$MODULE" "$ai"
            fi
        done
    else
        if declare -f "$MODULE" > /dev/null; then
            "$MODULE"
        fi
    fi
done

COMPLETE

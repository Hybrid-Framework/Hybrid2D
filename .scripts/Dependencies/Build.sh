#!/usr/bin/env bash
set -euo pipefail

for ai in "${!ARCHS[@]}"; do
    for MODULE in "${MODULES[@]}"; do
        echo
        echo "Running $MODULE $PLATFORM [${ARCHS[$ai]}]"
        echo

        if declare -f "$MODULE" > /dev/null; then
            "$MODULE" "$ai"
        fi
    done
done

COMPLETE

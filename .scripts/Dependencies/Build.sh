#!/usr/bin/env bash
set -e

for MODULE in "${MODULES[@]}"; do
  for i in "${!ARCHS[@]}"; do
    echo "Running $MODULE $PLATFORM [${ARCHS[$i]}]"
    "$MODULE" "$i"
  done
done

if declare -f COMPLETE > /dev/null; then
  COMPLETE
fi

#!/usr/bin/env bash

# Call Environment
if declare -f ENVIRONMENT > /dev/null; then
  ENVIRONMENT
fi

# Call Modules
for MODULE in "${MODULES[@]}"; do
  echo "Running $MODULE $PLATFORM"
  "$MODULE"
done

# Call Complete
if declare -f COMPLETE > /dev/null; then
  COMPLETE
fi

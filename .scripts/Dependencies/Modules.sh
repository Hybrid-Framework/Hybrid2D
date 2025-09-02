#!/usr/bin/env bash
set -euo pipefail


MODULES_DIR="$BASE_DIR/Dependencies/Modules"

if [[ ! -d "$MODULES_DIR" ]]; then
    mkdir -p "$MODULES_DIR"
fi

MODULES=()

module() {
    local name="$1"
    shift
    declare -g -A "$name"

    while (( "$#" )); do
        local kv="$1"
        shift
        eval "$name[${kv%%=*}]='${kv#*=}'"
    done

    MODULES+=("$name")
}
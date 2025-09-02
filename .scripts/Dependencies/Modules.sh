#!/usr/bin/env bash
set -euo pipefail

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
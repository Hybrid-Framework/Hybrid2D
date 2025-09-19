#!/usr/bin/env bash
set +e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/Dependencies"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Bindings"
MODULES=("CLANG" "SDL2")

CLANG()
{
  Install "Clang" "https://github.com/dotnet/ClangSharp.git" "v20.1.2.1"
  
  if [[ ! -d "$MODULES_DIR/Clang/artifacts/bin/sources/ClangSharpPInvokeGenerator/Release" ]]; then
      cd "$MODULES_DIR/Clang/sources/ClangSharpPInvokeGenerator"
      dotnet build -c Release
  fi
  
  CLANGSHARP=$(find "$MODULES_DIR/Clang/artifacts/bin/sources/ClangSharpPInvokeGenerator/Release" -type f -name "ClangSharpPInvokeGenerator.exe" | head -n 1)

  if [[ -z "$CLANGSHARP" ]]; then
      echo "ERROR: ClangSharpPInvokeGenerator not found"
      exit 1
  fi
}

SDL2()
{
  Install "SDL2" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  local INCLUDE="$MODULES_DIR/$MODULE/Include"
  
  local FILES=(
    SDL.h
  )
  
  for file in "${FILES[@]}"; do
    
      local EXEC=(
          "$CLANGSHARP"
          -l SDL
          -n SDL
          -m SDL
          -I "$INCLUDE"
          -f "$INCLUDE/$file"
          -o "$BASE_DIR/Generated/$MODULE/${file%.h}.cs"
      )
  
      echo "Generating bindings for $file..."
      output=$("${EXEC[@]}" 2>&1) || true
  
      if echo "$output" | grep -q "Unsupported"; then
          continue
      fi
  
      "${EXEC[@]}"
      
  done

}

COMPLETE()
{
  read -p "Bindings Generated."
}

source "$BASE_DIR/Dependencies/Build.sh"
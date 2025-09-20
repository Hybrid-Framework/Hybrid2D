#!/usr/bin/env bash
set +e

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/../Dependencies/Modules"
DEPENDENCIES_DIR="$BASE_DIR/../Dependencies"
PROJECT_DIR="$BASE_DIR/Bindings"
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Bindings"
MODULES=("CLANG" "SDL2" "SDL2_image" "SDL2_mixer" "SDL2_ttf")
SDLINCLUDE="$MODULES_DIR/SDL2/Include"

rm -rf "$PROJECT_DIR/Include"
mkdir -p "$PROJECT_DIR/Include"

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
  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  local INCLUDE="$MODULES_DIR/$MODULE/Include"
  
  local FILES=(
    SDL.h
    SDL_main.h
    SDL_video.h
    SDL_audio.h
    SDL_rect.h
    SDL_render.h
    SDL_surface.h
    SDL_blendmode.h
    SDL_pixels.h
    SDL_scancode.h
    SDL_keycode.h
    SDL_keyboard.h
    SDL_mouse.h
    SDL_touch.h
    SDL_joystick.h
    SDL_gamecontroller.h
    SDL_filesystem.h
    SDL_clipboard.h
    SDL_events.h
    SDL_stdinc.h
    SDL_timer.h
    SDL_hints.h
    SDL_misc.h
    SDL_error.h
    SDL_log.h
  )
  
  for file in "${FILES[@]}"; do
    
      local EXEC=(
          "$CLANGSHARP"
          -l SDL
          -n SDL
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$PROJECT_DIR/Include/$MODULE/${file%.h}.h"
      )
  
      echo "Generating bindings for $file..."
      output=$("${EXEC[@]}" 2>&1) || true
  
      if echo "$output" | grep -q "Unsupported"; then
          continue
      fi
  
      "${EXEC[@]}"
      
  done
}

SDL2_image()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_image.git" "release-2.8.8"
  local INCLUDE="$MODULES_DIR/$MODULE/Include"
  
  local FILES=(
    SDL_image.h
  )
  
  for file in "${FILES[@]}"; do
    
      local EXEC=(
          "$CLANGSHARP"
          -l SDL
          -n SDL
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$PROJECT_DIR/Include/$MODULE/${file%.h}.h"
      )
  
      echo "Generating bindings for $file..."
      output=$("${EXEC[@]}" 2>&1) || true
  
      if echo "$output" | grep -q "Unsupported"; then
          continue
      fi
  
      "${EXEC[@]}"
      
  done
}

SDL2_mixer()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_mixer.git" "release-2.8.1"
  local INCLUDE="$MODULES_DIR/$MODULE/Include"
  
  local FILES=(
    SDL_mixer.h
  )
  
  for file in "${FILES[@]}"; do
    
      local EXEC=(
          "$CLANGSHARP"
          -l SDL
          -n SDL
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$PROJECT_DIR/Include/$MODULE/${file%.h}.h"
      )
  
      echo "Generating bindings for $file..."
      output=$("${EXEC[@]}" 2>&1) || true
  
      if echo "$output" | grep -q "Unsupported"; then
          continue
      fi
  
      "${EXEC[@]}"
      
  done
}

SDL2_ttf()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL_ttf.git" "release-2.24.0"
  local INCLUDE="$MODULES_DIR/$MODULE"
  
  local FILES=(
    SDL_ttf.h
  )
  
  for file in "${FILES[@]}"; do
    
      local EXEC=(
          "$CLANGSHARP"
          -l SDL
          -n SDL
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$PROJECT_DIR/Include/$MODULE/${file%.h}.h"
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
  echo
  echo "Running C to C# Parsing"
  echo
  
  dotnet run --project "$PROJECT_DIR/Bindings.csproj"
  
  echo
  read -p "Bindings Generated."
  echo
}

source "$DEPENDENCIES_DIR/Build.sh"
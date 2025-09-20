#!/usr/bin/env bash
set +e

# dotnet new tool-manifest
# dotnet tool install -g ClangSharpPInvokeGenerator --version 20.1.2.1

BASE_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MODULES_DIR="$BASE_DIR/../Modules"
DEPENDENCIES_DIR="$BASE_DIR/.."
source "$DEPENDENCIES_DIR/Methods.sh"

PLATFORM="Bindings"
MODULES=("SDL2" "SDL2_image" "SDL2_mixer" "SDL2_ttf")
OUTPUT="$BASE_DIR/Generated"
EXTENSION=".cs"

rm -rf "$OUTPUT"
mkdir -p "$OUTPUT"

BASE_COMMANDS=(
  ClangSharpPInvokeGenerator
  
  --namespace SDL2
  --config latest-codegen
  
  --remap "void*=IntPtr"
  --remap "char=byte"
  --remap "wchar_t *=IntPtr"
  --remap "bool=SDLBool"
  --remap "__va_list=byte*"
  --remap "__va_list_tag=byte"
  --remap "Sint64=long"
  --remap "Uint64=ulong"
  
  --with-type "*=int"
  --nativeTypeNamesToStrip "unsigned int"
)

SDL2()
{
  Install "$MODULE" "https://github.com/libsdl-org/SDL.git" "release-2.32.10"
  local INCLUDE="$MODULES_DIR/$MODULE/Include"
  SDLINCLUDE=$INCLUDE
  
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
          "${BASE_COMMANDS[@]}"
          -l $MODULE
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$OUTPUT/$MODULE/${file%.h}$EXTENSION"
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
          "${BASE_COMMANDS[@]}"
          -l $MODULE
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$OUTPUT/$MODULE/${file%.h}$EXTENSION"
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
          "${BASE_COMMANDS[@]}"
          -l $MODULE
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$OUTPUT/$MODULE/${file%.h}$EXTENSION"
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
          "${BASE_COMMANDS[@]}"
          -l $MODULE
          -m $MODULE
          -I "$SDLINCLUDE"
          -f "$INCLUDE/$file"
          -o "$OUTPUT/$MODULE/${file%.h}$EXTENSION"
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
  read -p "Bindings Generated."
  echo
}

source "$DEPENDENCIES_DIR/Build.sh"
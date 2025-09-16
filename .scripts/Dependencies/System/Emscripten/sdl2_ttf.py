# Copyright 2015 The Emscripten Authors.  All rights reserved.
# Emscripten is available under two separate licenses, the MIT license and the
# University of Illinois/NCSA Open Source License.  Both these licenses can be
# found in the LICENSE file.

import os

TAG = 'release-2.24.0' # Latest as of 21 February 2023
HASH = 'fd7c3ae30764a5382fc64385c36899bcba860de1a204a1bf5e5cb2e19c2338c38432cfa9a0f9fad4b4917a368ad55eae0026e1d73b8b5424091745f7668202b3'

deps = ['freetype', 'sdl2']


def needed(settings):
  return settings.USE_SDL_TTF == 2


def get(ports, settings, shared):
  ports.fetch_project('sdl2_ttf', f'https://github.com/libsdl-org/SDL_ttf/archive/{TAG}.zip', sha512hash=HASH)

  def create(final):
    src_root = os.path.join(ports.get_dir(), 'sdl2_ttf', 'SDL_ttf-' + TAG)
    ports.install_headers(src_root, target='SDL2')
    flags = ['-DTTF_USE_HARFBUZZ=0', '-sUSE_SDL=2', '-sUSE_FREETYPE']
    ports.build_port(src_root, final, 'sdl2_ttf', flags=flags, srcs=['SDL_ttf.c'])

  return [shared.cache.get_lib('libSDL2_ttf.a', create, what='port')]


def clear(ports, settings, shared):
  shared.cache.erase_lib('libSDL2_ttf.a')


def process_dependencies(settings):
  settings.USE_SDL = 2
  settings.USE_FREETYPE = 1
  settings.USE_HARFBUZZ = 0


def process_args(ports):
  return ['-DTTF_USE_HARFBUZZ=0']


def show():
  return 'SDL2_ttf (-sUSE_SDL_TTF=2; zlib license)'

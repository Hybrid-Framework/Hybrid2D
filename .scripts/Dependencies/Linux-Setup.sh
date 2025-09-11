#!/usr/bin/env bash
set +e

sudo apt update -y
sudo apt upgrade -y

CORE_TOOLS=(cmake git pkg-config curl wget unzip ninja-build)
MISSING_TOOLS=()
for pkg in "${CORE_TOOLS[@]}"; do
    if ! dpkg -s "$pkg" >/dev/null 2>&1; then
        MISSING_TOOLS+=("$pkg")
    fi
done
if [ ${#MISSING_TOOLS[@]} -gt 0 ]; then
    echo "Installing missing core tools: ${MISSING_TOOLS[*]}"
    sudo apt install -y "${MISSING_TOOLS[@]}"
else
    echo "All core tools already installed."
fi

SOURCES_FILE="/etc/apt/sources.list"
BACKUP_FILE="/etc/apt/sources.list.backup.$(date +%Y%m%d-%H%M%S)"

echo
echo "📋 Creating backup of $SOURCES_FILE at $BACKUP_FILE"
sudo cp "$SOURCES_FILE" "$BACKUP_FILE"
echo "✅ Backup created."
echo

LINES=(
"deb http://gb.archive.ubuntu.com/ubuntu/ jammy main restricted"
"deb [arch=amd64,i386] http://archive.ubuntu.com/ubuntu/ jammy main restricted universe multiverse"
"deb [arch=amd64,i386] http://archive.ubuntu.com/ubuntu/ jammy-updates main restricted universe multiverse"
"deb [arch=amd64,i386] http://archive.ubuntu.com/ubuntu/ jammy-backports main restricted universe multiverse"
"deb [arch=amd64,i386] http://security.ubuntu.com/ubuntu/ jammy-security main restricted universe multiverse"
"deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy main restricted universe multiverse"
"deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy-updates main restricted universe multiverse"
"deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy-backports main restricted universe multiverse"
"deb [arch=arm64] http://security.ubuntu.com/ubuntu/ jammy-security main restricted universe multiverse"
)

UPDATED_SOURCES=false
for line in "${LINES[@]}"; do
    if ! grep -Fxq "$line" "$SOURCES_FILE"; then
        echo "$line" | sudo tee -a "$SOURCES_FILE" > /dev/null
        UPDATED_SOURCES=true
        echo "Added text to /etc/apt/sources.list: $line"
    fi
done

for arch in amd64 i386 arm64; do
    if ! dpkg --print-foreign-architectures | grep -q "^$arch$"; then
        sudo dpkg --add-architecture "$arch"
        UPDATED_SOURCES=true
        echo "Added architecture: $arch"
    fi
done

if [ "$UPDATED_SOURCES" = true ]; then
    echo "Running apt update due to new sources or architectures..."
    sudo apt update -y
fi

CROSS_COMPILERS=(
    gcc-aarch64-linux-gnu g++-aarch64-linux-gnu
    gcc-x86-64-linux-gnu g++-x86-64-linux-gnu
    gcc-i686-linux-gnu g++-i686-linux-gnu
)

MISSING_COMPILERS=()
for pkg in "${CROSS_COMPILERS[@]}"; do
    if ! dpkg -s "$pkg" >/dev/null 2>&1; then
        MISSING_COMPILERS+=("$pkg")
    fi
done

if [ ${#MISSING_COMPILERS[@]} -gt 0 ]; then
    echo "Installing missing cross-compilers: ${MISSING_COMPILERS[*]}"
    sudo apt install -y "${MISSING_COMPILERS[@]}"
else
    echo "All cross-compilers already installed."
fi

sudo apt install -y \
libx11-dev:amd64 \
libxext-dev:amd64 \
libxrandr-dev:amd64 \
libxcursor-dev:amd64 \
libxinerama-dev:amd64 \
libxfixes-dev:amd64 \
libxi-dev:amd64 \
libxss-dev:amd64 \
libxrender-dev:amd64 \
libwayland-dev:amd64 \
libwayland-client0:amd64 \
libwayland-cursor0:amd64 \
libwayland-egl1-mesa:amd64 \
libxkbcommon-dev:amd64 \
libpng-dev:amd64 \
libjpeg-dev:amd64 \
libjpeg-turbo8-dev:amd64 \
libsndfile1-dev:amd64 \
libmpg123-dev:amd64 \
libvorbis-dev:amd64 \
libogg-dev:amd64 \
libfreetype6-dev:amd64 \
libasound2-dev:amd64 \
libharfbuzz-dev:amd64

sudo apt install -y \
libx11-dev:i386 \
libxext-dev:i386 \
libxrandr-dev:i386 \
libxcursor-dev:i386 \
libxinerama-dev:i386 \
libxfixes-dev:i386 \
libxi-dev:i386 \
libxss-dev:i386 \
libxrender-dev:i386 \
libwayland-dev:i386 \
libwayland-client0:i386 \
libwayland-cursor0:i386 \
libwayland-egl1-mesa:i386 \
libxkbcommon-dev:i386 \
libpng-dev:i386 \
libjpeg-dev:i386 \
libjpeg-turbo8-dev:i386 \
libsndfile1-dev:i386 \
libmpg123-dev:i386 \
libvorbis-dev:i386 \
libogg-dev:i386 \
libfreetype6-dev:i386 \
libasound2-dev:i386 \
libharfbuzz-dev:i386

sudo apt install -y \
libx11-dev:arm64 \
libxext-dev:arm64 \
libxrandr-dev:arm64 \
libxcursor-dev:arm64 \
libxinerama-dev:arm64 \
libxfixes-dev:arm64 \
libxi-dev:arm64 \
libxss-dev:arm64 \
libxrender-dev:arm64 \
libwayland-dev:arm64 \
libwayland-client0:arm64 \
libwayland-cursor0:arm64 \
libwayland-egl1-mesa:arm64 \
libxkbcommon-dev:arm64 \
libpng-dev:arm64 \
libjpeg-dev:arm64 \
libjpeg-turbo8-dev:arm64 \
libsndfile1-dev:arm64 \
libmpg123-dev:arm64 \
libvorbis-dev:arm64 \
libogg-dev:arm64 \
libfreetype6-dev:arm64 \
libasound2-dev:arm64 \
libharfbuzz-dev:arm64

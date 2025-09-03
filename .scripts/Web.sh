# Dependencies

#!/bin/bash
set -e

echo
echo "As of right now there is no automated script for Web"
echo
echo "Web uses Emscripten to build the libraries. Due to WebAssembly using the "Microsoft.NET.Runtime.Emscripten.3.1.34.Sdk.win-x64" pack we are unable to support higher versions as of right now until dotnet update to a higher version or we modify the local pack however this unstable and not future proof. Therefore we are currently on the latest stable versions of the libraries as of right now."
echo
echo "Possible workflows could be to include a modified "Microsoft.NET.Runtime.Emscripten.3.1.34.Sdk.win-x64" pack with the project and redirect our builds to use that instead giving a constant result across all development environments. However this isn't something I will be working on as of right now."
echo

# Complete
read -p "Build complete."

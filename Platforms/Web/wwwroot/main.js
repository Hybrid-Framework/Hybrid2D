import { dotnet } from './_framework/dotnet.js';

// Settings
const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

// Exports
const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

// Canvas
var canvas = document.getElementById("canvas");
dotnet.instance.Module.canvas = canvas;

// Run App
await exports.Activity.Main();

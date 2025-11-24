import { dotnet } from './_framework/dotnet.js';

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

// Debugging
dotnet.instance.Module.print = console.log;
dotnet.instance.Module.printErr = console.error;
dotnet.instance.Module.onAbort = (msg) => console.error("Exception:", msg);

// Run App
await exports.Program.Main();

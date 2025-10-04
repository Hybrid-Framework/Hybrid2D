import { dotnet } from './_framework/dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const entry = exports.Program.Main;

var canvas = document.getElementById("canvas");
dotnet.instance.Module.canvas = canvas;

dotnet.instance.Module.setMainLoop(entry);

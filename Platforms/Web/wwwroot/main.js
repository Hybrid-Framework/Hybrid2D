import { dotnet } from './_framework/dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const entry = exports.Program.Entry;

var playButton = document.getElementById("playButton");
var canvas = document.getElementById("canvas");
dotnet.instance.Module.canvas = canvas;

playButton.addEventListener("click", async () =>
{
    playButton.style.display = "none";
    dotnet.instance.Module.setMainLoop(entry);
});

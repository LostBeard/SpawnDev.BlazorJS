using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SpawnDev.BlazorJS.WebWorkers.Build.Tasks
{
    public class ImportShimBlazorWASM : Microsoft.Build.Utilities.Task
    {

        [Required]
        public ITaskItem[] StaticWebAsset { get; set; }

        [Required]
        public string ProjectDir { get; set; }

        [Required]
        public string OutputPath { get; set; }

        [Required]
        public string BasePath { get; set; }

        [Required]
        public string IntermediateOutputPath { get; set; }

        [Required]
        public bool PatchFramework { get; set; }

        [Required]
        public string PackageContentDir { get; set; }

        [Required]
        public bool DebugSpawnDevWebWorkersBuildTasks { get; set; }

        [Required]
        public bool PublishMode { get; set; }

        public string OutputWwwroot { get; set; }

        public override bool Execute()
        {
            // Log.LogWarning($"**********************************  ImportShimBlazorWASM.Execute  **********************************");
            if (DebugSpawnDevWebWorkersBuildTasks)
            {
                System.Diagnostics.Debugger.Launch();
            }
            if (!PatchFramework)
            {
                return true;
            }
            OutputWwwroot = Path.GetFullPath(Path.Combine(OutputPath, "wwwroot"));
            PackageContentDir = Path.GetFullPath(PackageContentDir);
            var patcher = new BlazorWASMFrameworkTool(OutputWwwroot, PackageContentDir);
            patcher.ImportPatch();
            return true;
        }
    }
}

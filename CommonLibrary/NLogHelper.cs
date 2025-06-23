using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BossInfo.Dms.CommonLibrary;

public static class NLogHelper
{
    public static void EnsureNLogDirectoryExists()
    {
        var logFileTarget = LogManager.Configuration?.FindTargetByName<NLog.Targets.FileTarget>("logfile");
        string logFileName = logFileTarget?.FileName.Render(LogEventInfo.CreateNullEvent());
        Directory.CreateDirectory(Path.GetDirectoryName(logFileName));
    }

    public static List<string> GetTargetPaths()
    {
        var targetPaths = new List<string>();

        // Get the current NLog configuration
        var config = LogManager.Configuration;

        // Find all file targets
        var fileTargets = config.AllTargets
            .OfType<FileTarget>();

        foreach (var fileTarget in fileTargets)
        {
            // Render the file name (handles variables/layouts)
            var logEventInfo = new LogEventInfo { TimeStamp = DateTime.Now };
            string filePath = fileTarget.FileName.Render(logEventInfo);
            targetPaths.Add(filePath);
        }

        return targetPaths;
    }
}
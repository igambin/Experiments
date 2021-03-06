﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Toolbox.Core;
using static System.Console;

namespace Toolbox.Console
{
    public class MultiDirsToSingleDirCopy : IConsoleTool
    {
        string sourceDirectory;
        string destinationDirectory;
        Regex directoryFilter = null;
        Regex fileFilter = null;
        bool overwrite = false;

        public MultiDirsToSingleDirCopy()
        {

        }

        public Categories Category => Categories.FileTool;

        public string Name => "FileCollector";

        public string Description => "Starting in the sourceDirectory the FileCollector will search for directories matching an optional filter. Then it will search for files within matching directories again using an optional filter. All matching files will be copied to the destination directory.";

        public void Run()
        {

            sourceDirectory      = ConsoleInput.GetDirectory("Source Directory     "  , "The path which will be searched for sub-directories");
            destinationDirectory = ConsoleInput.GetDirectory("Destination Directory"  , "The path into which all found files will be copied");
            directoryFilter      =     ConsoleInput.GetRegex("Directory Filter     "  , "an optional filter for sub-directory-selection");
            fileFilter           =     ConsoleInput.GetRegex("File Filter          "  , "an optional filter for file-selection");

            if (Directory.Exists(sourceDirectory))
            {

                if (Directory.Exists(destinationDirectory))
                {
                    
                    var dirs = Directory.GetDirectories(sourceDirectory);
                    
                    if(directoryFilter != null) {
                        dirs = dirs.Where(x => directoryFilter.IsMatch(x)).ToArray();
                    }
                        
                    dirs.ToList()
                        .ForEach( x =>
                        {
                            var fpath = Path.Combine(sourceDirectory, x);
                            var files = Directory.GetFiles(fpath);

                            if (fileFilter != null)
                            {
                                files = files.Where(y => fileFilter.IsMatch(y)).ToArray();
                            }
                                
                            files.ToList()
                                 .ForEach( z =>
                                 {
                                     var file = new FileInfo(z);
                                     var sFilename = Path.Combine(fpath, z);
                                     var dFilename = Path.Combine(destinationDirectory, file.Name);
                                 
                                     File.Copy(sFilename, dFilename, overwrite);
                                 });
                        });


                }
                else
                {
                    WriteLine("Destination Directory not found.");
                }
            }
            else
            {
                WriteLine("SourceDirectory not found.");
            }
            ReadLine();

        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyHelper_DirRemover
{
    public class Mp3TagWriter : IConsoleTool
    {
        string sourceDirectory;
        string albumName;
        string artistName;
        Regex fileFilter = null;
        bool overwrite = false;

        public Mp3TagWriter()
        {

        }

        public Categories Category => Categories.Mp3Tool;

        public string Name => "Mp3TagWriter";

        public string Description => "Schreibt Mp3 ID3-Informationen. Verzeichnisname als Album, führende Nummer einer Datei als Track-Nr, Rest des Dateinamens als Title";

        public void Run()
        {

            sourceDirectory      = ConsoleInput.GetDirectory("Mp3-Directory                                ", "The path in which MP3-Files will be located");
            albumName            = ConsoleInput.GetString(   "Album-Name      [none]                       ", "Name of the album");
            artistName           = ConsoleInput.GetString(   "Album-Artists (separate by comma) [none]     ", "Name of the artist or the band");
            bool replaceTrackArtists = ConsoleInput.GetBool("Replace Track-Artists by Album-Artists (y/n)  ", "(y)es or (n)o");
            bool recountTrackIds     = ConsoleInput.GetBool("Reset Track-Numbers of Filelist sorted by name", "Set a new Track-Id based on a files position after ordering the whole list of files by name");

            if(string.IsNullOrEmpty(albumName))
            {
                albumName = "none";
            }

            if (string.IsNullOrEmpty(artistName))
            {
                artistName = "none";
            }


            if (Directory.Exists(sourceDirectory))
            {
                var files = Directory.GetFiles(sourceDirectory, "*.mp3").OrderBy(x => new FileInfo(x).Name).ToList();

                uint fileCount = 0;

                foreach(var z in files) {
                    fileCount++;

                    var file = new FileInfo(z);    
                    TagLib.File mp3 = TagLib.File.Create(z);

                    var tag = mp3.Tag;
                    tag.Album = albumName;
                    tag.AlbumArtists = artistName.Split(',').Select(x => x.Trim()).ToArray();

                    var getFileInfo = new Regex(@"(\d+)[-\s._]*(.+)\.mp3");

                    var match = getFileInfo.Match(file.Name);

                    if(match.Success && match.Groups.Count>=3) {
                        tag.Track = recountTrackIds ? fileCount : uint.Parse(match.Groups[1].Value);
                        var title = match.Groups[2].Value.Replace('_', ' ');

                        var titleArtistPattern = new Regex(@"(.+)\((.+)\)");
                        var match2 = titleArtistPattern.Match(title);

                        if (match2.Success && match2.Groups.Count == 3)
                        {
                            tag.Title = match2.Groups[1].Value.Trim();
                            tag.Performers = match2.Groups[2].Value.Split(',').Select(x => x.Trim()).ToArray();
                        } else {
                            tag.Title = title.Trim();
                            if (replaceTrackArtists)
                            {
                                tag.Performers = tag.AlbumArtists;
                            }
                        }

                    }

                    mp3.Save();

                }

            }
            else
            {
                Console.WriteLine("SourceDirectory not found.");
            }

        }

    }
}

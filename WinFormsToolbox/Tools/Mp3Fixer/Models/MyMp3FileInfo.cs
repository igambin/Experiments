using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Mp3Tag = TagLib.Tag;
using Mp3Info = TagLib.File;
using System.Windows.Forms;

namespace WinFormsToolbox.Mp3Fixer.Models
{
    internal class MyMp3FileInfo : IComparable
    {
        public string FileName { get; set; }
        private FileInfo fi { get; }
        private Mp3Info mp3Info { get; }
        private Mp3Tag mp3Tag { get; }

        private List<string> _composers { get; set; }
        private List<string> _albumPerformers { get; set; }
        private List<string> _trackPerformers { get; set; }
        private List<string> _genres { get; set; }

        public string Conductor { get; set; }
        public string AlbumName { get; set; }
        public string TrackName { get; set; }
        private uint NewTrackNo { get; }
        private uint NewTrackCount { get; }
        public uint TrackNo { get; set; }
        public uint TrackCount { get; set; }
        public uint DiscNo { get; set; }
        public uint DiscCount { get; set; }
        public uint Year { get; set; }
        public string Genres
        {
            get
            {
                return string.Join(", ", _genres);
            }
            set
            {
                _genres = value.Split(',').Select(x => x.Trim()).ToList();
            }
        }
        public string AlbumArtists
        {
            get
            {
                return string.Join(", ", _albumPerformers);
            }
            set
            {
                _albumPerformers = value.Split(',').Select(x => x.Trim()).ToList();
            }
        }
        public string TrackArtists
        {
            get
            {
                return string.Join(", ", _trackPerformers);
            }
            set
            {
                _trackPerformers = value.Split(',').Select(x => x.Trim()).ToList();
            }
        }
        public string Composers
        {
            get
            {
                return string.Join(", ", _composers);
            }
            set
            {
                _composers = value.Split(',').Select(x => x.Trim()).ToList();
            }
        }

        public static MyMp3FileInfo Create(FileInfo f, uint position, uint trackCount)
        {
            MyMp3FileInfo newInstance = null;
            try
            {
                newInstance = new MyMp3FileInfo(f, position, trackCount);
            } catch (Exception)
            {
                MessageBox.Show($"Fehler beim Auslesen des MP3-Tags der Datei '{f.Name}'", @"Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newInstance;
        }

        private MyMp3FileInfo(FileInfo f, uint position, uint trackCount)
        {
            fi = f;
            SetShortName();

            mp3Info = Mp3Info.Create(f.FullName);
            mp3Tag = mp3Info.Tag;

            NewTrackNo = position;
            NewTrackCount = trackCount;

            ResetDiscNo();
            ResetDiscCount();
            ResetYear();
            ResetTrackNo();
            ResetTrackCount();
            ResetTrackName();
            ResetAlbumName();
            ResetAlbumArtists();
            ResetTrackArtists();
            ResetConductor();
            ResetComposers();
            ResetGenres();
        }

        private void ResetConductor()
        {
            Conductor = mp3Tag?.Conductor ?? string.Empty;
        }

        public void SetFullPath()
        {
            FileName = fi.FullName;
        }

        public void SetShortName()
        {
            FileName = fi.Name;
        }
        public void ResetYear()
        {
            Year = mp3Tag?.Year ?? 0;
        }
        public void ResetDiscNo()
        {
            DiscNo = mp3Tag?.Disc ?? 1;
        }
        public void ResetDiscCount()
        {
            DiscCount = mp3Tag?.DiscCount ?? 1;
        }
        public void ResetTrackCount()
        {
            TrackCount = mp3Tag?.TrackCount ?? NewTrackCount;
        }
        public void ResetTrackNo()
        {
            TrackNo = mp3Tag?.Track ?? NewTrackNo;
        }
        public void ResetTrackName()
        {
            TrackName = mp3Tag?.Title ?? string.Empty;
        }
        public void ResetAlbumName()
        {
            AlbumName = mp3Tag?.Album ?? string.Empty;
        }
        public void ResetAlbumArtists()
        {
            _albumPerformers = mp3Tag?.AlbumArtists?.ToList() ?? new List<string>();
        }
        public void ResetComposers()
        {
            _composers = mp3Tag?.Composers?.ToList() ?? new List<string>();
        }
        public void ResetTrackArtists()
        {
            _trackPerformers = mp3Tag?.Performers?.ToList() ?? new List<string>();
        }
        public void ResetGenres()
        {
            _genres = mp3Tag?.Genres?.ToList() ?? new List<string>();
        }

        public FileInfo getFileInfo() => fi;

        public Mp3Info getMp3Info() => mp3Info;

        public void UpdateMp3Tag()
        {
            mp3Tag.Title = TrackName;
            mp3Tag.Performers = _trackPerformers.ToArray();
            mp3Tag.Track = TrackNo;
            mp3Tag.TrackCount = TrackCount;

            mp3Tag.Album = AlbumName;
            mp3Tag.AlbumArtists = _albumPerformers.ToArray();

            mp3Tag.Composers = _composers.ToArray();
            mp3Tag.Conductor = Conductor;

            mp3Tag.Year = Year;
            mp3Tag.Disc = DiscNo;
            mp3Tag.DiscCount = DiscCount;

            mp3Tag.Genres = _genres.ToArray();

            mp3Info.Save();
        }

        public int CompareTo(object obj)
        {
            MyMp3FileInfo mfi = obj as MyMp3FileInfo;
            if (mfi != null)
            {
                return fi.Name.CompareTo(mfi.fi.Name);
            }
            throw new InvalidCastException("Can't compare MyMp3FileInfo objects to other object types!");
        }

    }
}

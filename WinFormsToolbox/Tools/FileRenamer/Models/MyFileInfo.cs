using System;
using System.IO;

namespace WinFormsToolbox.FileRenamer.Models
{
    class MyFileInfo : IComparable
    {
        public string oldfilename { get; set; }
        public string newfilename { get; set; }
        private FileInfo fi { get; }

        private MyFileInfo() : this(string.Empty) { }

        private MyFileInfo(string filename) {
            oldfilename = newfilename = filename;
        }

        public MyFileInfo(FileInfo f)
            : this(f.Name)
        {
            fi = f;
        }

        public FileInfo getFileInfo() => fi;

        public void Rename() {
            fi.MoveTo(Path.Combine(fi.DirectoryName, newfilename));
        }

        public int CompareTo(object obj)
        {
            MyFileInfo mfi = obj as MyFileInfo;
            if (mfi != null)
            {
                return fi.Name.CompareTo(mfi.fi.Name);
            }
            throw new InvalidCastException("Can't compare MyFileInfo objects to other object types!");
        }

    }
}

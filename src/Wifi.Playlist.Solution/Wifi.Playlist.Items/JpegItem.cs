using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    public class JpegItem : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagfile;

        public JpegItem(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            _filePath = filePath;
            _tagfile = TagLib.File.Create(_filePath);
        }
        public string Title => Path.GetFileNameWithoutExtension(_tagfile.Name);

        public string Author
        {
            get
            {
                FileInfo fi = new FileInfo(_filePath);
                string user = fi.GetAccessControl().GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();

                return user;
            }
        }
        public TimeSpan Duration => TimeSpan.FromSeconds(10);

        public string FilePath => _filePath;

        public Image Thumbnail
        {
            get
            {
                Image image = null;

                image = Image.FromFile(_filePath);
                image = image.GetThumbnailImage(128, 128, null, IntPtr.Zero);

                return image;
            }
        }

        public string Description => "Jpeg picture file";

        public string Extension => ".jpeg";

        public override string ToString()
        {
            return $"{Title} [{Author}]";
        }
    }
}

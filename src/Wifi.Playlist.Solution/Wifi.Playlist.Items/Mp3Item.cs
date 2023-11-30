using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using System.Drawing;
using TagLib;
using System.IO;
using File = TagLib.File;

namespace Wifi.Playlist.Items
{
    public class Mp3Item : IPlaylistItem
    {
        private readonly string _filePath;
        private readonly File _tagfile;

        public Mp3Item(string filePath)
        {
            _filePath = filePath;
            _tagfile = TagLib.File.Create(_filePath);
        }
        public string Title => _tagfile.Tag.Title;

        public string Author => _tagfile.Tag.FirstPerformer;

        public TimeSpan Duration => _tagfile.Properties.Duration;

        public string FilePath => _filePath;

        public Image Thumbnail
        {
            get
            {
                Image image = null;

                if (_tagfile.Tag.Pictures != null && _tagfile.Tag.Pictures.Length > 0)
                {
                    image = Image.FromStream(new MemoryStream(_tagfile.Tag.Pictures[0].Data.Data));
                    image = image.GetThumbnailImage(128, 128, null, IntPtr.Zero);
                }

                return image;
            }
        }

        public string Description => "MP3 music file";

        public string Extension => ".mp3";

        public override string ToString()
        {
            return $"{Title} [{Author}]";
        }
    }
}

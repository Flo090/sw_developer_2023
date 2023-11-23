using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes
{
    public interface IPlaylistItem
    {
        string Title {  get; }
        string Author { get; }
        TimeSpan Duration { get; }
        string FilePath { get; }
        Image Thumbnail { get; }
    }
}

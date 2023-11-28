using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.Playlist.FormsUI
{
    public interface INewPlaylistDataProvider
    {
        string PlaylistAuthor { get; }
        string PlaylistName { get; }

        DialogResult ShowEditor();
    }
}

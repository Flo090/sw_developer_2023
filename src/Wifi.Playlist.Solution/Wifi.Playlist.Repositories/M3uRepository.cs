using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;

namespace Wifi.Playlist.Repositories
{
    public class M3uRepository : IPlaylistRepository
    {
        public string Description => "M3U file";

        public string Extension => ".m3u";

        public IPlaylist Load(string filePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string filePath)
        {
            M3uPlaylist m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            foreach (IPlaylistItem item in playlist.Items)
            {
                m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {
                    Title = item.Title,
                    AlbumArtist = item.Author,
                    Duration = item.Duration,
                    Path = item.FilePath
                });
            }
            M3uContent content = new M3uContent();
            string text = content.ToText(m3uPlaylist);

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }
    }
}

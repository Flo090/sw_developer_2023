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
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public string Description => "M3U file";

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
        }
        public string Extension => ".m3u";

        public IPlaylist Load(string filePath)
        {
            string title = string.Empty;
            string author = string.Empty;
            string createAt = string.Empty;

            IPlaylist domainPlaylist = null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            StreamReader sr = new StreamReader(filePath);
            

            var content = new M3uContent();
            var playlistEntity = content.GetFromStream(sr.BaseStream);

            //read meta data first
            foreach (var entry in playlistEntity.PlaylistEntries)
            {
                if (entry.Comments.Count > 0)
                {
                    title = GetCommentValue(entry.Comments, "#Title:");
                    author = GetCommentValue(entry.Comments, "#Author:");
                    createAt = GetCommentValue(entry.Comments, "#CreatedAt:");

                    break;
                }
            }

            domainPlaylist = new Playlist.CoreTypes.Playlist(title, author, DateTime.Parse(createAt));
            foreach (var entry in playlistEntity.PlaylistEntries)
            {
                var playlistItem = _playlistItemFactory.Create(entry.Path);
                if (playlistItem != null)
                {
                    domainPlaylist.Add(playlistItem);
                }
            }
            return domainPlaylist;
        }

        private string GetCommentValue(IEnumerable<string> commentList, string valueKey)
        {
            var valueLine = commentList.Where(x => x.StartsWith(valueKey)).FirstOrDefault();

            return valueLine.Replace(valueKey, string.Empty);
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

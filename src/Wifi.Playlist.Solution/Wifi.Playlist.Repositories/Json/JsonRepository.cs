using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.Playlist.CoreTypes;
using System.IO.Abstractions;

namespace Wifi.Playlist.Repositories.Json
{
    public class JsonRepository : IPlaylistRepository
    {
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public JsonRepository(IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistItemFactory) { }
        
        public JsonRepository(IFileSystem fileSystem,IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
            _playlistItemFactory = playlistItemFactory;
        }
        public string Description => "Wifi Playlist Format";

        public string Extension => ".wifi";

        public IPlaylist Load(string filePath)
        {
            var content = _fileSystem.File.ReadAllText(filePath);

            var entity = JsonConvert.DeserializeObject<PlaylistEntity>(content);

            return entity.ToDomain(_playlistItemFactory);
        }

        public void Save(IPlaylist playList, string filePath)
        {
            var entity = playList.ToEntity();

            string json = JsonConvert.SerializeObject(entity);
            _fileSystem.File.WriteAllText(filePath, json);
        }
    }
}

using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Playlist.CoreTypes.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;
        private Playlist _fixture2;

        [SetUp]
        public void Init()
        {
            _fixture = new Playlist("TopHits 2023", "Gandalf", new DateTime(2023, 11, 24, 11, 59, 30));
            _fixture2 = new Playlist("TopHits 2023", "Gandalf");
        }

        [Test]
        public void Name_get()
        {
            //Arrange

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("TopHits 2023"));
        }

        [Test]
        public void Name_set()
        {
            //Arrange
            _fixture.Name = "Superhits 1980";

            //Act
            var erg = _fixture.Name;

            //Assert
            Assert.That(erg, Is.EqualTo("Superhits 1980"));
        }

        [Test]
        public void Author_get()
        {
            //Arrange

            //Act
            var erg = _fixture.Author;

            //Assert
            Assert.That(erg, Is.EqualTo("Gandalf"));
        }

        [Test]
        public void Author_set()
        {
            //Arrange
            _fixture.Author = "Max";

            //Act
            var erg = _fixture.Author;

            //Assert
            Assert.That(erg, Is.EqualTo("Max"));
        }

        [Test]
        public void CreatedAt_get()
        {
            //Arrange

            //Act
            var erg = _fixture.CreatedAt;

            //Assert
            Assert.That(erg, Is.EqualTo(new DateTime(2023, 11, 24, 11, 59, 30)));
        }

        [Test]
        public void Items_get()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            List<IPlaylistItem> items = new List<IPlaylistItem>();
            items.Add(item1.Object);

            _fixture.Add(item1.Object);

            //Act
            var erg = _fixture.Items;

            //Assert
            Assert.AreEqual(erg, items);
        }

        [Test]
        public void Duration_get()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            item1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(80));
            item2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(200));

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.FromSeconds(280)));
        }

        [Test]
        public void Duration_get_NoItems()
        {
            // Arrange

            //Act
            var duration = _fixture.Duration;

            //Assert
            Assert.That(duration, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void Add_InvalidItem()
        {
            //Arrange
            IPlaylistItem item1 = null;
            var item2 = new Mock<IPlaylistItem>();

            _fixture.Add(item2.Object);
            var oldCount = _fixture.Items.Count();
            _fixture.Add(item1);

            //Act
            var count = _fixture.Items.Count();

            //Assert
            Assert.That(oldCount, Is.EqualTo(count));
        }

        [Test]
        public void Add_Item()
        {
            // Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            //Act
            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Assert
            Assert.That(_fixture.Items.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Remove_InvalidItem()
        {
            //Arrange
            IPlaylistItem item1 = null;
            var item2 = new Mock<IPlaylistItem>();

            _fixture.Add(item2.Object);
            var oldCount = _fixture.Items.Count();
            _fixture.Remove(item1);

            //Act
            var count = _fixture.Items.Count();

            //Assert
            Assert.That(oldCount, Is.EqualTo(count));
        }

        [Test]
        public void Remove_Item()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            var item2 = new Mock<IPlaylistItem>();

            _fixture.Add(item1.Object);
            _fixture.Add(item2.Object);

            //Act
            _fixture.Remove(item2.Object);

            //Assert
            Assert.That(false, Is.EqualTo(_fixture.Items.Contains(item2.Object)));
        }

        [Test]
        public void Clear_List()
        {
            //Arrange
            var item1 = new Mock<IPlaylistItem>();
            _fixture.Add(item1.Object);

            List<IPlaylistItem> list = new List<IPlaylistItem>();

            //Act
            _fixture.Clear();

            //Assert
            Assert.That(list, Is.EqualTo(_fixture.Items));
        }

        [Test]
        public void BasicTest()
        {
            //Arrange
            int zahl = 4;
            int erg = 0;

            //Act
            erg = zahl * 2;

            //Assert
            Assert.That(erg, Is.EqualTo(8));
        }
    }
}

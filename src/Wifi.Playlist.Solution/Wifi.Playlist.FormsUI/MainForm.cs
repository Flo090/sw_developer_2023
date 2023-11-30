﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.Playlist.CoreTypes;
using Wifi.Playlist.FormsUI.Properties;

namespace Wifi.Playlist.FormsUI
{
    public partial class MainForm : Form
    {
        private CoreTypes.Playlist _playlist;
        private readonly INewPlaylistDataProvider _newPlaylistDataProvider;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public MainForm(INewPlaylistDataProvider newPlaylistDataProvider,
                        IPlaylistItemFactory playlistItemFactory)
        {
            InitializeComponent();
            this._newPlaylistDataProvider = newPlaylistDataProvider;
            _playlistItemFactory = playlistItemFactory;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_playlistName.Text = string.Empty;
            lbl_itemDetails.Text = string.Empty;
            lbl_playlistDetails.Text = string.Empty;

            EnableEditControls(false);
        }

        private void EnableEditControls(bool controlsEnabled)
        {
            addToolStripMenuItem.Enabled = controlsEnabled;
            removeToolStripMenuItem.Enabled = controlsEnabled;
            clearToolStripMenuItem.Enabled = controlsEnabled;
            saveToolStripMenuItem.Enabled = controlsEnabled;
        }

        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var newForm = new NewPlaylistForm();

            if (_newPlaylistDataProvider.ShowEditor() != DialogResult.OK)
            {
                return;
            }
            //HACK: Wird verbessert!!
            _playlist = new CoreTypes.Playlist(_newPlaylistDataProvider.PlaylistName, _newPlaylistDataProvider.PlaylistAuthor);
            
            // Update view
            EnableEditControls(true);
            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void ShowPlaylistItems()
        {
            int imageIndex = 0;

            lst_itemsView.Items.Clear();
            imageList.Images.Clear();

            foreach (var item in _playlist.Items)
            {
                var listViewItem = new ListViewItem(item.ToString());
                listViewItem.Tag = item;

                if (item.Thumbnail != null)
                {
                    imageList.Images.Add(item.Thumbnail);
                }
                else
                {
                    imageList.Images.Add(Resource.noImage);
                }

                listViewItem.ImageIndex = imageIndex++;
                lst_itemsView.Items.Add(listViewItem);
            }

            lst_itemsView.LargeImageList = imageList;
        }

        private void ShowPlaylistDetails()
        {
            lbl_playlistName.Text = _playlist.Name;
            lbl_playlistDetails.Text = $"Gesamtspieldauer: {_playlist.Duration.ToString("hh\\:mm\\:ss")} Autor: {_playlist.Author}";
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var fileName in openFileDialog.FileNames)
            {
                var newItem = _playlistItemFactory.Create(fileName);
                if (newItem == null)
                {
                    return;
                }
                _playlist.Add(newItem);
            }

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void lst_itemsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = GetSelectedPlaylistItem(sender);

            if (item == null)
            { 
                return; 
            }

            ShowPlaylistItemDetails(item);
        }

        private void ShowPlaylistItemDetails(IPlaylistItem item)
        {
            if (item == null)
            {
                return;
            }
            lbl_itemDetails.Text = $"Pfad: {item.FilePath} {Environment.NewLine}Dauer: {item.Duration.ToString("hh\\:mm\\:ss")}";
        }

        private IPlaylistItem GetSelectedPlaylistItem(object sender)
        {
            var listView = sender as ListView;
            if (listView == null || listView.SelectedItems.Count != 1)
            {
                return null;
            }

            var selectedItem = listView.SelectedItems[0];
            var playlistItem = selectedItem.Tag as IPlaylistItem;
            if (playlistItem == null)
            {
                return null;
            }

            return playlistItem;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = GetSelectedPlaylistItem(lst_itemsView);
            if (item == null)
            {
                return;
            }

            _playlist.Remove(item);

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlist.Clear();

            ShowPlaylistDetails();
            ShowPlaylistItems();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
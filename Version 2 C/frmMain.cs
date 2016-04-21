using System;
using System.Windows.Forms;

namespace Version_2_C
{
    public sealed partial class frmMain : Form
    {
        private frmMain()
        {
            //private constructor. now following the Singleton pattern
            InitializeComponent();
        }

        private static frmMain _instance = new frmMain();
        //public static readonly frmMain _instance = new frmMain(); //this would crash the program if made public -- see Program.cs 

        public delegate void Notify(string prGalleryName); //public delegate to change the Gallery Name in clsArtist
        public event Notify GalleryNameChanged;            //public event - tell everyone!
        private clsArtistList _ArtistList = new clsArtistList();

        public static frmMain Instance
        {
            //Public Property for the Form to Instantiate
            //this is added as the constructor was made private
            get { return _instance; }
        }

        private void UpdateTitle(string prGalleryName)
        {
            if (!string.IsNullOrEmpty(prGalleryName))
                Text = "Gallery - " + prGalleryName;
        }

        public void UpdateDisplay()
        {
            lstArtists.DataSource = null;
            string[] lcDisplayList = new string[_ArtistList.Count];
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmArtist.Run(new clsArtist(_ArtistList));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmArtist.Run((_ArtistList[lcKey]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                _ArtistList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    _ArtistList.Remove(lcKey);
                    lstArtists.ClearSelected();
                    UpdateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleing artist");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _ArtistList = clsArtistList.RetrieveArtistList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File retrieve error");
            }
            GalleryNameChanged += new Notify(UpdateTitle);
            GalleryNameChanged(_ArtistList.GalleryName); //event raising :)
            UpdateDisplay();
        }

        private void btnGalleryName_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox("Change the gallery name:   " + _ArtistList.GalleryName).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _ArtistList.GalleryName = lcReply;
                GalleryNameChanged(lcReply);
            }

        }

        private void btnGalleryName_Click_1(object sender, EventArgs e)
        {

        }
    }
}
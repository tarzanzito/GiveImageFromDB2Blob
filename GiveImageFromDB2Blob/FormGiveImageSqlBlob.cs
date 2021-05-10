using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public partial class FormGiveImageSqlBlob : Form
    {
        //Common.DB2AccessODBC _DB2Access = null;
        Common.DB2Access _DB2Access = null;

        string[] imagesFile = new string[3] { "", "", "" };
        int currentImage = 0;

        public FormGiveImageSqlBlob()
        {
            InitializeComponent();
            Text = Text + " - Version:" + Application.ProductVersion.ToString();
        }

        private void FormGiveImageSqlBlob_Load(object sender, EventArgs e)
        {
            panelTop.Dock = DockStyle.Top;
            panelFill.Dock = DockStyle.Fill;

            FieldsLock(true);
            FieldsImageLock(true);
            FieldsClear(true);

            ReadConfigFile();
        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _DB2Access = new Common.DB2Access();
                //_DB2Access = new Common.DB2AccessODBC();
                _DB2Access.ConnectingString = textBoxConnString.Text;
                _DB2Access.Open();

                FieldsLock(false);
                FieldsImageLock(true);
                FieldsClear(false);
                
                textBoxImageID.Focus();
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (_DB2Access == null)
                return;

             try
             {
                _DB2Access.Close();
                _DB2Access = null;

                FieldsLock(true);
                FieldsImageLock(true);
                FieldsClear(false);
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (_DB2Access != null)
            {
                try
                {
                    _DB2Access.Close();
                    _DB2Access = null;
                }
                catch
                {
                }
            }
            
            Close();
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            if (_DB2Access == null)
                return;

            try
            {
                pictureBox1.Image = null;
                currentImage = 0;

                imagesFile = _DB2Access.GetAllImages(this.textBoxImageID.Text.Trim());

                ShowImageJPG(imagesFile[0]);

                FieldsImageLock(false);
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }
        }
        

        private void buttonImg1_Click(object sender, EventArgs e)
        {
            if (currentImage == 0)
                return;

            try
            {
                ShowImageJPG(imagesFile[0]);
                currentImage = 0;
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }
        }

        private void buttonImg2_Click(object sender, EventArgs e)
        {
            if (currentImage == 1)
                return;

            try
            {
                ShowImageJPG(imagesFile[1]);
                currentImage = 1;
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }

        }

        private void buttonImg3_Click(object sender, EventArgs e)
        {
            if (currentImage == 2)
                return;

            try
            {
                ShowImageTIFF(imagesFile[2]);
                currentImage = 2;
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }

        }

        private void buttonImg3Previous_Click(object sender, EventArgs e)
        {
            if (currentImage != 2)
                return;

        }

        private void buttonImg3Next_Click(object sender, EventArgs e)
        {
            if (currentImage != 2)
                return;

            try
            {
                this.ShowImageTIFF(imagesFile[2]); //TODO: control frames of TIFF
                currentImage = 2; 
            }
            catch (System.Exception ex)
            {
                this.labelMsg.Text = ex.Message;
            }
        }

 // // // // // // 

        private void FieldsLock(bool lockIt)
        {
            textBoxConnString.Enabled = lockIt;
            textBoxImageID.Enabled = !lockIt;

            buttonConnect.Enabled = lockIt;
            buttonDisconnect.Enabled = !lockIt;
            buttonGet.Enabled = !lockIt;
        }

        private void FieldsImageLock(bool lockIt)
        {
            buttonImg1.Enabled = !lockIt && (imagesFile[0].Length > 0);
            buttonImg2.Enabled = !lockIt && (imagesFile[1].Length > 0); ;
            buttonImg3.Enabled = !lockIt && (imagesFile[2].Length > 0); ;
            buttonImg3Previous.Enabled = false; // !lockIt && (imagesFile[2].Length > 0); ;
            buttonImg3Next.Enabled = false; // !lockIt && (imagesFile[2].Length > 0); ;
        }

        private void FieldsClear(bool clearAll)
        {
            if (clearAll)
            {
                textBoxConnString.Text = "";
            }

            textBoxImageID.Text = "";
            labelMsg.Text = "";
            this.pictureBox1.Image = null;
                                                //Test textBoxImageID.Text = "16180006400013";
        }


        private void ShowImageJPG(string fileName)
        {
            this.pictureBox1.Image = null;

            if (fileName.Length == 0)
                return;

            try
            {
                System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                System.Drawing.Image img = Image.FromStream(stream);
                stream.Close();
                //System.Drawing.Image img = Image.FromFile(images[0]); //lock the physic file for rewrite

                this.pictureBox1.Width = img.Width;
                this.pictureBox1.Height = img.Height;
                this.pictureBox1.Image = img;


            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //Need System.Windows DLL & PresentationCore DLL & PresentationFramework & System.xaml & System.windows.presentation
        private void ShowImageTIFF(string fileName)
        {
            this.pictureBox1.Image = null;

            if (fileName.Length == 0)
                return;

            try
            {
                // Open a Stream and decode a TIFF image
                System.IO.Stream imageStreamSource = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);

                System.Windows.Media.Imaging.TiffBitmapDecoder decoder = 
                    new System.Windows.Media.Imaging.TiffBitmapDecoder(imageStreamSource, System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat,
                        System.Windows.Media.Imaging.BitmapCacheOption.Default);

                int xx = 0;
                System.Windows.Media.Imaging.BitmapSource bitmapSource = decoder.Frames[xx];

                //// Draw the Image
                System.Drawing.Bitmap bitMap = BitmapSourceToBitmap(bitmapSource);
                this.pictureBox1.Width = bitMap.Width;
                this.pictureBox1.Height = bitMap.Height;
                this.pictureBox1.Image = bitMap;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //Need System.Windows DLL & PresentationCore DLL & PresentationFramework & System.xaml & System.windows.presentation
        private System.Drawing.Bitmap BitmapSourceToBitmap(System.Windows.Media.Imaging.BitmapSource bitmapsource)
        {
            System.Drawing.Bitmap bitmap;
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            
            System.Windows.Media.Imaging.BitmapEncoder enc = new System.Windows.Media.Imaging.BmpBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmapsource));
            enc.Save(outStream);
            bitmap = new System.Drawing.Bitmap(outStream);
            
            return bitmap;
        }

        private void ReadConfigFile()
        {
            textBoxConnString.Text = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vaja1_rv_wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region ReadColorPalete
            byte[,] barve_img = new byte[256, 3];
            BinaryReader br = new BinaryReader(File.Open(@"D:\Sola\3. letnik\racunalniska vecpredstavnost\vaja1\vaja1_rv_wf\res\BarvnePalete\topography.lut", FileMode.Open));

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    barve_img[i, j] = br.ReadByte();
                }
            }
            #endregion

            #region ReadCT
            short[,] slika_img = new short[512, 512];
            BinaryReader br2 = new BinaryReader(File.Open(@"D:\Sola\3. letnik\racunalniska vecpredstavnost\vaja1\vaja1_rv_wf\res\CT\0219.img", FileMode.Open));
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    slika_img[i, j] = br2.ReadInt16();
                }
            }
            #endregion

            #region CombineCTwithColorPalete
            Bitmap pic = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format48bppRgb);
            int color = 0;
            for (int i = 0; i < 512; i++)
            {
                for (int j = 0; j < 512; j++)
                {
                    color = Convert.ToInt32((((double)slika_img[i, j] + 2048) / 4095) * 255);
                    int r = barve_img[(int)color, 0];
                    int g = barve_img[(int)color, 1];
                    int b = barve_img[(int)color, 2];
                    Color barva = Color.FromArgb(r, g, b);
                    pic.SetPixel(i, j, barva);
                }
            }
            #endregion

            ctPictureBox.Image = pic;

            #region Test


            int[,] imgR = {
                { 127, 127, 0, 0, 195, 0, 255, 255 },
                { 127, 127, 0, 0, 0, 127, 0, 0 },
                { 0, 0, 0, 0, 79, 79, 0, 0 },
                { 0, 0, 0, 0, 79, 79, 0, 0 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 }
            };

            string rezultat = "";

            int prelomnica = Convert.ToInt32(Math.Sqrt(imgR.Length)) / 2;
            
            DelSlike prviDel = new DelSlike(imgR,Convert.ToInt32(Math.Sqrt(imgR.Length)));
            prviDel.DivideImage();
            foreach(var item in prviDel.Children)
            {
                rezultat += item.checkDel();
            }

            #endregion
        }
    }
}

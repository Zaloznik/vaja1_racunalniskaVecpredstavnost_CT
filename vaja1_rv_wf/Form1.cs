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
            BinaryReader br = new BinaryReader(File.Open(@"D:\Sola\3. letnik\racunalniska vecpredstavnost\vaja1\vaja1_rv\vaja1_rv\bin\Debug\barvnePalete\topography.lut", FileMode.Open));

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
            BinaryReader br2 = new BinaryReader(File.Open(@"D:\Sola\3. letnik\racunalniska vecpredstavnost\vaja1\vaja1_rv\vaja1_rv\bin\Debug\ctPosnetek\0219.img", FileMode.Open));
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


            //------------------------------------------------------------------------------------------------ OVU JE TEST
            #region test


            int[,] img = {
                { 127, 127, 0, 0, 195, 0, 255, 255 },
                { 127, 127, 0, 0, 0, 127, 0, 0 },
                { 0, 0, 0, 0, 79, 79, 0, 0 },
                { 0, 0, 0, 0, 79, 79, 0, 0 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 },
                { 0, 0, 0, 0, 255, 255, 255, 255 }
            };

            List<int> prviDel, drugiDel, tretjiDel, cetrtiDel;
            prviDel = new List<int>();

            bool allesGut = true;
            int barvaInt = -1;
            for(int i=0;i<4;i++)
            {
                for(int j=0;j<3;j++)
                {
                    if (img[i,j] != img[i,j+1])
                    {
                        allesGut = false;
                        break;
                    }
                    else
                    {
                        barvaInt = img[i,j];
                    }
                    Console.Write(img[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

            if(allesGut)
            {
                prviDel.Add(0);
                string bit = Convert.ToString(barvaInt, 2).PadLeft(8, '0'); ;
                for (int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                    {
                        prviDel.Add(1);
                    }
                    else
                    {
                        prviDel.Add(0);
                    }
                }
            }
            else
            {
                prviDel.Add(1);
            }

            drugiDel = new List<int>();
            allesGut = true;
            for(int i=4;i<8;i++)
            {
                for (int j =0;j<3;j++)
                {
                    if (img[i, j] != img[i, j + 1])
                    {
                        allesGut=false;
                        break;
                    }
                    else
                    {
                        barvaInt = img[i, j];
                    }
                    Console.Write(img[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            if (allesGut)
            {
                drugiDel.Add(0);
                string bit = Convert.ToString(barvaInt, 2).PadLeft(8,'0');
                for (int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                    {
                        drugiDel.Add(1);
                    }
                    else
                    {
                        drugiDel.Add(0);
                    }
                }
            }
            else
            {
                drugiDel.Add(1);
            }

            tretjiDel = new List<int>();
            allesGut = true;
            for(int i=0;i<4;i++)
            {
                for(int j=4;j<7;j++)
                {
                    if (img[i, j] != img[i, j + 1])
                    {
                        allesGut = false;
                        break;
                    }
                    else
                    {
                        barvaInt = img[i, j];
                    }
                    Console.Write(img[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            if (allesGut)
            {
                tretjiDel.Add(0);
                string bit = Convert.ToString(barvaInt, 2).PadLeft(8, '0');
                for (int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                    {
                        tretjiDel.Add(1);
                    }
                    else
                    {
                        tretjiDel.Add(0);
                    }
                }
            }
            else
            {
                tretjiDel.Add(1);
            }

            cetrtiDel = new List<int>();
            allesGut = true;
            for (int i = 4; i < 8; i++)
            {
                for(int j=4;j<7;j++)
                {
                    if (img[i, j] != img[i, j + 1])
                    {
                        allesGut = false;
                        break;
                    }
                    else
                    {
                        barvaInt = img[i, j];
                    }
                    Console.Write(img[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            if (allesGut)
            {
                cetrtiDel.Add(0);
                string bit = Convert.ToString(barvaInt, 2).PadLeft(8, '0');
                for(int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                    {
                        cetrtiDel.Add(1);
                    }
                    else
                    {
                        cetrtiDel.Add(0);
                    }
                }
            }
            else
            {
                cetrtiDel.Add(1);
            }

            List<int> together = new List<int>();
            together.AddRange(prviDel);
            together.AddRange(drugiDel);
            together.AddRange(tretjiDel);
            together.AddRange(cetrtiDel);
            string stop = ";";
            #endregion
        }
    }
}

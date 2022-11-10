using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaja1_rv_wf
{
    public class DelSlike
    {
        #region Constructor
        public DelSlike()
        {

        }
        public DelSlike(int[,] sivinska, int width)
        {
            Sivinska = sivinska;
            Width = width;
        }
        #endregion

        #region Properties

        public int[,] Sivinska;
        public int Width;
        public bool hasChild;
        public List<DelSlike> Children = new List<DelSlike>();

        #endregion


        #region Methods

        #region CheckColors
        public string checkDel()
        {
            for(int i=0;i<Width;i++)
            {
               for(int j=0;j<Width-1;j++)
               {
                    if (Sivinska[i,j] != Sivinska[i,j+1])
                    {
                        hasChild = true;
                        return "1";
                        break;
                    }
               }
            }

            return "0" + Convert.ToString(Sivinska[0,0],2).PadLeft(8,'0');
        }
        #endregion

        #region DivideImage
        public void DivideImage()
        {
            int prelomnica = Width / 2;
            int[,] delSlike = new int[prelomnica, prelomnica];
            for (int i = 0; i < 4; i++)
            {
                // 1.DEL
                if (i == 0)
                {
                    for (int x = 0; x < prelomnica; x++)
                    {
                        for (int y = 0; y < prelomnica; y++)
                        {
                            delSlike[x, y] = Sivinska[x, y];
                        }
                    }
                    Children.Add(new DelSlike(delSlike, prelomnica));
                }
                //2.DEL
                if (i == 1)
                {
                    for (int x = 0; x < prelomnica; x++)
                    {
                        for (int y = prelomnica; y < prelomnica * 2; y++)
                        {
                            delSlike[x, y] = Sivinska[x, y];
                        }
                    }
                    Children.Add(new DelSlike(delSlike, prelomnica));
                }
                //3.DEL
                if (i == 2)
                {
                    for (int x = prelomnica; x < prelomnica * 2; x++)
                    {
                        for (int y = 0; y < prelomnica; y++)
                        {
                            delSlike[x, y] = Sivinska[x, y];
                        }
                    }
                    Children.Add(new DelSlike(delSlike, prelomnica));
                }
                //4.DEL
                if (i == 3)
                {
                    for (int x = prelomnica; x < prelomnica * 2; x++)
                    {
                        for (int y = prelomnica; y < prelomnica * 2; y++)
                        {
                            delSlike[x, y] = Sivinska[x, y];
                        }
                    }
                    Children.Add(new DelSlike(delSlike, prelomnica));
                }
            }
        }
        #endregion

        #endregion
    }
}

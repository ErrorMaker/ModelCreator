using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelCreator.Environment;
using System.Threading;

namespace ModelCreator.Environment
{
    class Model
    {
        public static Form frm1;
        public static Panel panel1;
        public static List<Tile> tiles = new List<Tile>();
        public static string model;
        public static int X_coord;
        public static int Y_coord;
        public static int OffsetX;
        public static int OffsetY = 40;
        public static Graphics offGraph;
        public static Image normal = ModelCreator.Properties.Resources.on;
        public static Image delete = ModelCreator.Properties.Resources.del;
        public static Image add = ModelCreator.Properties.Resources.add;
        public static bool IsOn;
        public static bool ClearPanel;
        public static bool zoomout = false;
        public static string createModel(int y, int x)
        {
            IsOn = false;
            tiles.Clear();
            String Output = "";
            Y_coord = y;
            X_coord = x;
            OffsetX = ((Y_coord * 32)) + 20;

            resize();

                for (int Y = 0; Y < y; Y++)
                {
                    for (int X = 0; X < x; X++)
                    {
                        Tile asdf = new Tile(X,Y);
                        tiles.Add(asdf);
                        Output = Output + "0";
                        
                    }
                    Output = Output + "\n";
                }
                drawImage();
            return Output;
        }
        public static void resize()
        {
            int Width = ((X_coord * 32) + (Y_coord * 32) + 50) + 50;
            Width = zoomout ? Width / 2 + 50 : Width;
            int height = ((X_coord * 16) + (Y_coord * 16) + 50 + 8) + 90;
            height = zoomout ? height / 2 + 90 : height;
            if (Width > 430 && height > 309)
            {
                frm1.Size = new Size(Width, height);
            }
            else
            {
                frm1.Size = new Size(430, 309);
            }

            offGraph = panel1.CreateGraphics();
        }
        public static string getModel()
        {
            string Output = "";
            for (int Y = 0; Y < Y_coord; Y++)
            {
                for (int X = 0; X < X_coord; X++)
                {
                    if (getTile(Y, X).isUsed)
                    {
                        Output = Output + "0";
                    }
                    else
                    {
                        Output = Output + "X";
                    }

                }
                Output = Output + "\n";
            }
            return Output;
        }
        public static void drawImage()
        {
                        offGraph.Clear(Color.Black);

                    for (int Y = 0; Y < Y_coord; Y++)
                    {
                        for (int X = 0; X < X_coord; X++)
                        {
                            var _x = ((X * 32) + (Y * -32) + OffsetX);
                            var _y = ((X * 16) + (Y * 16) + OffsetY);
                            Tile asdf = getTile(Y, X);
                            asdf.Height = zoomout ? _y / 2 : _y;
                            asdf.Width = zoomout ? _x / 2 : _x;
                          
                                if (getTile(Y, X).isUsed)
                                {
                                    if (zoomout)
                                        offGraph.DrawImage(normal, _x /2 , _y /2, 32, 20);
                                    else
                                        offGraph.DrawImage(normal, _x, _y, 64, 40);
                                }
                           
                        }
                    }
            
        }
        public static Tile getTile(int y, int x)
        {
            foreach(Tile t in tiles)
            {
                if (t.X == x && t.Y == y)
                    return t;
            }
            return null;
        }
        public static void HandleClick(int x, int y)
        {
            foreach(Tile t in tiles)
            {
                if (zoomout &&(t.Width + 4) < x && (t.Width + 13) > x && (t.Height + 3) < y && (t.Height + 8) > y || (t.Width + 16) < x && (t.Width + 54) > x && (t.Height + 10) < y && (t.Height + 31) > y)
                {
                    ClearPanel = true;
                    t.isUsed = t.isUsed ? false : true;
                    drawImage();
                    return;
                }
                
            }
            
        }
    }
}

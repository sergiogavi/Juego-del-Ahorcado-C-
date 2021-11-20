using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JocPenjat
{
    class dibujoConsola
    {

        public static void start(int intentos)
        {

            Console.WriteLine("Pulsa INTRO para continuar...");

            if (intentos==2)
            {
                ScreenText stHorca = new ScreenText(90, 0, "|-'");
                ScreenText stCabeza = new ScreenText(93, 0, "0");
  
                stHorca.Display();
                stCabeza.Display();
            }
            else if (intentos==1)
            {
                ScreenText stHorca = new ScreenText(90, 0, "|-'");
                ScreenText stCabeza = new ScreenText(93, 0, "0");

                ScreenText stTronco = new ScreenText(92, 1, "´|`");
                stHorca.Display();
                stCabeza.Display();
                stTronco.Display();
            }
            else if (intentos == 0)
            {
                ScreenText stHorca = new ScreenText(90, 0, "|-'");
                ScreenText stCabeza = new ScreenText(93, 0, "0");

                ScreenText stTronco = new ScreenText(92, 1, "´|`");

                ScreenText stPiernas = new ScreenText(92, 2, "´ `");
                stCabeza.Display();
                stHorca.Display();
                stTronco.Display();
                stPiernas.Display();
            }
            //ScreenText st = new ScreenText(50, 5, "0");
            //sts.Display();
           
            Console.ReadLine();
            Console.Clear();

           /* CenteredText ct = new CenteredText(10, "Missatge de prova centrat. Ara prem \"enter\".");
            ct.Display();
            Console.ReadLine();
            Console.Clear();

            FramedText ft = new FramedText(8, "Missatge emmarcat. Ara prem \"enter\".", 6);
            ft.Display();
            Console.ReadLine();
            Console.Clear();
           */
           
        }
    }

    class ScreenText
    {
        protected int nX;
        protected int nY;
        protected string toDisplay;

        public ScreenText(int x, int y, string text)
        {
            nX = x;
            nY = y;
            toDisplay = text;
        }

        public ScreenText(int y, string text)
        {
            nY = y;
            toDisplay = text;
        }

        public virtual void Display()
        {
            //Console.Clear();
            Console.CursorLeft = nX;
            Console.CursorTop = nY;
            Console.Write(toDisplay);
        }

        public virtual int NX
        {
            get { return nX; }
            set { nX = value; }
        }

        public int NY
        {
            get { return nY; }
            set { nY = value; }
        }

        public string Text
        {
            get { return toDisplay; }
            set { toDisplay = value; }
        }
    }

    class CenteredText : ScreenText
    {
        public CenteredText(int y, string text) : base(y, text)
        {
            nX = (Console.BufferWidth / 2) - (text.Length / 2);
        }

        public override int NX
        {
            get { return nX; }
        }
    }

    class FramedText : CenteredText
    {
        private int padding;
        private int lineWidth;
        private int totalLines;

        public FramedText(int y, string text, int Padding) : base(y, text)
        {
            padding = (Padding > y) ? y - 1 : Padding;
            lineWidth = (padding * 2) + text.Length + 2;
            totalLines = (padding * 2) + 3;
        }

        public override void Display()
        {
            Console.Clear();
            Console.CursorLeft = (nX + toDisplay.Length / 2) - ((lineWidth - 1) / 2);
            Console.CursorTop = nY;
            for (int i = 0; i < totalLines; i++)
            {
                for (int j = 0; j < lineWidth; j++)
                {
                    if (i == 0 || i == totalLines - 1)
                    {
                        Console.Write("-");
                    }
                    else if (i < (totalLines - 1) / 2 || i > (totalLines - 1) / 2)
                    {
                        if (j == 0 || j == lineWidth - 1)
                            Console.Write("|");
                        else
                            Console.Write(" ");
                    }
                    else if (i == (totalLines - 1) / 2)
                    {
                        if (j == 0 || j == lineWidth - 1)
                            Console.Write("|");
                        else if ((j > 0 && j < padding + 1) || (j > padding + 1 + toDisplay.Length - 1 && j < lineWidth - 1))
                            Console.Write(" ");
                        else
                        {
                            Console.Write(toDisplay);
                            j += toDisplay.Length - 1;
                        }
                    }
                }
                Console.CursorLeft = (nX + toDisplay.Length / 2) - ((lineWidth - 1) / 2);
                Console.CursorTop = nY + i + 1;
            }
        }
    }

 

}


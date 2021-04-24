using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace VSIndicator
{
    public class ColourDecoder
    {
        // colours
        private Color32 Red;
        private Color32 Orange;
        private Color32 Yellow;
        private Color32 Cyan;
        private Color32 Blue;
        private Color32 Magenta;
        private Color32 Pink;
        private Color32 White;


        public ColourDecoder()
        {
            SetColours();
        }

        private void SetColours()
        {
            // colours as RGBA
            Red = new Color32(255, 0, 0, 255);
            Orange = new Color32(255, 128, 0, 255);
            Yellow = new Color32(255, 255, 0, 255);
            Cyan = new Color32(0, 255, 255, 255);
            Blue = new Color32(0, 128, 255, 255);
            Magenta = new Color32(255, 0, 255, 255);
            Pink = new Color32(255, 0, 127, 255);
            White = new Color32(255, 255, 255, 255);

        }

        public string DecipherCode(int code)
        {
            switch (code)
            {
                case 0:
                    return "Green (Stock)";
                case 1:
                    return "Red";
                case 2:
                    return "Orange";
                case 3:
                    return "Yellow";
                case 4:
                    return "Cyan";
                case 5:
                    return "Blue";
                case 6:
                    return "Cerise";
                case 7:
                    return "Pink";
                case 8:
                    return "White";
                default:
                    return "Green (Stock)";
        }
            





        }

        public Color32 GetColour(string _color)
        {
            //return the RGBA to the main class

            switch (_color)
            {
                case nameof(Red):
                    return Red;
                case nameof(Orange):
                    return Orange;
                case nameof(Yellow):
                    return Yellow;
                case nameof(Cyan):
                    return Cyan;
                case nameof(Blue):
                    return Blue;
                case nameof(Magenta):
                    return Magenta;
                case nameof(Pink):
                    return Pink;
                case nameof(White):
                    return White;
                default:
                    return Color.green;
            }


        }





    }
}

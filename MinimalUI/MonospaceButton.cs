using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MinimalUI
{
    public partial class MonospaceButton : Control
    {
        string text;
        int scale = 10;
        int minscale = 10;
        string padl = string.Empty;
        string padr = string.Empty;
        bool enter = false;
        bool down = false;
        object ax = Accent.All;
        int coldiff = 30;

        #region Proprieties

        [Category(" Button")]
        override public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (scale < text.Length)
                    scale = text.Length;
                Application.DoEvents();
                Refresh();
            }
        }

        [Category(" Button")]
        public int ButtonScale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value < minscale ? minscale : value;
                Application.DoEvents();
                Refresh();
            }
        }

        Font _defaultFont = new Font("Lucida Console", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        [Category(" Button")]
        public override Font Font
        {
            get
            {
                return (base.Font);
            }
            set
            {
                if (value == null)
                    base.Font = _defaultFont;
                else
                {
                    if (value == DefaultFont)
                        base.Font = _defaultFont;
                    else
                        base.Font = value;
                }
            }
        }

        [Category(" Button")]
        [DefaultValue(Accent.All)]
        public Accent PressedAccentColour
        {
            get
            {
                return (Accent)ax;
            }
            set
            {
                ax = value;
            }
        }

        //[Category(" Button")]
        //[DefaultValue(30)]
        //public int PressedAccentDiff
        //{
        //    get
        //    {
        //        return coldiff;
        //    }
        //    set
        //    {
        //        coldiff = value;
        //    }
        //}

        public override void ResetFont()
        {
            Font = null;
        }

        private bool ShouldSerializeFont()
        {
            return (!Font.Equals(_defaultFont));
        }

        #endregion

        public MonospaceButton()
        {
            InitializeComponent();
            text = Name;
            Font = new Font("Lucida Console", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gs = pe.Graphics;
            padl = string.Empty;
            padr = padl;
            int pad = scale - text.Length;
            bool even = true;

            if (pad > 0)
            {
                if (pad % 2 != 0) even = false;
                for (int i = 0; i < pad / 2; i++)
                {
                    padl += " ";
                }
                padr = padl;
                if (!even) padr += " ";
            }

            String display = "[" + padl + text + padr + "]";
            minscale = text.Length;
            if (minscale > scale) ButtonScale = minscale;

            if (enter) display = display.ToUpper();

            var br = new SolidBrush(ForeColor);

            if (down)
            {
                display = display.ToUpper();
                int r = br.Color.R;
                int g = br.Color.G;
                int b = br.Color.B;

                switch (PressedAccentColour)
                {
                    case Accent.All:
                        r = (r >= (255 + coldiff) ? r = 255 : r += coldiff);
                        g = (g >= (255 + coldiff) ? g = 255 : g += coldiff);
                        b = (b >= (255 + coldiff) ? b = 255 : b += coldiff);
                        break;
                    case Accent.Red:
                        r = (r >= (255 + coldiff) ? r = 255 : r += coldiff);
                        break;
                    case Accent.Green:
                        g = (g >= (255 + coldiff) ? g = 255 : g += coldiff);
                        break;
                    case Accent.Blue:
                        b = (b >= (255 + coldiff) ? b = 255 : b += coldiff);
                        break;
                }

                br.Color = Color.FromArgb(r, g, b);
            }
            Point pt = new Point(0, 0);
            Size = gs.MeasureString(display, Font).ToSize();
            gs.DrawString(display, Font, br, pt);
            base.OnPaint(pe);
        }

        private void MonospaceButton_MouseEnter(object sender, EventArgs e)
        {
            enter = true;
            this.Refresh();
        }

        private void MonospaceButton_MouseLeave(object sender, EventArgs e)
        {
            enter = false;
            this.Refresh();
        }

        private void MonospaceButton_MouseDown(object sender, MouseEventArgs e)
        {
            down = true;
            this.Refresh();
        }

        private void MonospaceButton_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
            this.Refresh();
        }
        public enum Accent
        {
            Red, Green, Blue, All
        }
    }
}

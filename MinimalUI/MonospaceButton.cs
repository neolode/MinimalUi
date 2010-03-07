using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MinimalUI
{
    public partial class MonospaceButton : Control
    {
        string _text;
        int _scale = 10;
        int _minscale = 10;
        string _padl = string.Empty;
        string _padr = string.Empty;
        bool _enter;
        bool _down;
        object _ax = Accent.All;
        const int Coldiff = 30;

        #region Proprieties

        [Category(" Button")]
        override public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                if (_scale < _text.Length)
                    _scale = _text.Length;
                Application.DoEvents();
                Refresh();
            }
        }

        [Category(" Button")]
        public int ButtonScale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value < _minscale ? _minscale : value;
                Application.DoEvents();
                Refresh();
            }
        }

        readonly Font _defaultFont = new Font("Lucida Console", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
                return (Accent)_ax;
            }
            set
            {
                _ax = value;
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
            _text = Name;
            Font = new Font("Lucida Console", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gs = pe.Graphics;
            _padl = string.Empty;
            _padr = _padl;
            int pad = _scale - _text.Length;
            bool even = true;

            if (pad > 0)
            {
                if (pad % 2 != 0) even = false;
                for (int i = 0; i < pad / 2; i++)
                {
                    _padl += " ";
                }
                _padr = _padl;
                if (!even) _padr += " ";
            }

            String display = "[" + _padl + _text + _padr + "]";
            _minscale = _text.Length;
            if (_minscale > _scale) ButtonScale = _minscale;

            if (_enter) display = display.ToUpper();

            var br = new SolidBrush(ForeColor);

            if (_down)
            {
                display = display.ToUpper();
                int r = br.Color.R;
                int g = br.Color.G;
                int b = br.Color.B;

                switch (PressedAccentColour)
                {
                    case Accent.All:
                        if (r >= (255 + Coldiff)) r = 255; else r += Coldiff;
                        if (g >= (255 + Coldiff)) g = 255; else g += Coldiff;
                        if (b >= (255 + Coldiff)) b = 255; else b += Coldiff;
                        break;
                    case Accent.Red:
                        if (r >= (255 + Coldiff)) r = 255; else r += Coldiff;
                        break;
                    case Accent.Green:
                        if (g >= (255 + Coldiff)) g = 255; else g += Coldiff;
                        break;
                    case Accent.Blue:
                        if (b >= (255 + Coldiff)) b = 255; else b += Coldiff;
                        break;
                }

                br.Color = Color.FromArgb(r, g, b);
            }
            var pt = new Point(0, 0);
            Size = gs.MeasureString(display, Font).ToSize();
            gs.DrawString(display, Font, br, pt);
            base.OnPaint(pe);
        }

        private void MonospaceButton_MouseEnter(object sender, EventArgs e)
        {
            _enter = true;
            Refresh();
        }

        private void MonospaceButton_MouseLeave(object sender, EventArgs e)
        {
            _enter = false;
            Refresh();
        }

        private void MonospaceButton_MouseDown(object sender, MouseEventArgs e)
        {
            _down = true;
            Refresh();
        }

        private void MonospaceButton_MouseUp(object sender, MouseEventArgs e)
        {
            _down = false;
            Refresh();
        }
        public enum Accent
        {
            Red, Green, Blue, All
        }
    }
}

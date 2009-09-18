using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MinimalUI
{
    [ToolboxBitmap(typeof(MonospaceProgressBar), "MinimalUI.MonospaceProgressBar.bmp")]
    public partial class MonospaceProgressBar : Control
    {
        int max_val = 100;
        int scale = 10;
        int current_val = 0;
        int normal_val = 0;
        char fill_char = '|';
        char empty_char = '-';

        #region Proprieties
        [Category(" ProgressBar")]
        [DefaultValue(100)]
        public int MaxValue
        {
            get
            {
                return max_val;
            }
            set
            {
                max_val = value;
                Application.DoEvents();
                this.Refresh();
            }
        }

        [Category(" ProgressBar")]
        [DefaultValue(10)]
        public int BarScale
        {
            get
            {
                return scale;
            }
            set
            {
                scale = value;
                Application.DoEvents();
                this.Refresh();
            }
        }

        [Category(" ProgressBar")]
        public int Value
        {
            get
            {
                return current_val;
            }
            set
            {
                if (value > max_val) return;
                current_val = value;
                Application.DoEvents();
                this.Refresh();
            }
        }

        [Category(" ProgressBar")]
        [DefaultValue('|')]
        public char FillCharFull
        {
            get
            {
                return fill_char;
            }
            set
            {
                fill_char = value;
                Application.DoEvents();
                this.Refresh();
            }
        }

        [Category(" ProgressBar")]
        [DefaultValue('-')]
        public char FillCharEmpty
        {
            get
            {
                return empty_char;
            }
            set
            {
                empty_char = value;
                Application.DoEvents();
                this.Refresh();
            }
        }

        Font _defaultFont = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        [Category(" ProgressBar")]
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
                    if (value == System.Windows.Forms.Control.DefaultFont)
                        base.Font = _defaultFont;
                    else
                        base.Font = value;
                }
            }
        }

        public override void ResetFont()
        {
            Font = null;
        }

        private bool ShouldSerializeFont()
        {
            return (!Font.Equals(_defaultFont));
        }

        #endregion

        #region HiddenProprieties

        [Browsable(false)]
        override public Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; }
        }

        [Browsable(false)]
        override public ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; }
        }

        [Browsable(false)]
        override public bool AllowDrop
        {
            get { return base.AllowDrop; }
            set { base.AllowDrop = value; }
        }

        //[Browsable(false)]
        //override public AutoValidate AutoValidate
        //{
        //    get { return base.AutoValidate; }
        //    set { base.AutoValidate = value; }
        //}

        [Browsable(false)]
        [DefaultValue(false)]
        new public bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        [Browsable(false)]
        [DefaultValue(false)]
        new public bool CausesValidation
        {
            get { return base.CausesValidation; }
            set { base.CausesValidation = value; }
        }
        #endregion

        public MonospaceProgressBar()
        {
            InitializeComponent();
            TabStop = false;
            CausesValidation = false;
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics gs = pe.Graphics;

            int tmp1 = (int)Math.Ceiling(((float)current_val / (float)max_val) * 100);
            string tmp2 = string.Empty;
            if (tmp1 < 10)
                tmp2 = "00";
            else
                if (tmp1 < 100)
                    tmp2 = "0";

            normal_val = (int)Math.Ceiling(((float)tmp1 / 100) * (float)scale);

            String display = "[";

            for (int i = 0; i < scale; i++)
            {
                if (i < normal_val)
                    display += fill_char;
                else
                    display += empty_char;
            }

            display += "]" + tmp2 + tmp1 + "%";

            SolidBrush br = new SolidBrush(this.ForeColor);
            Point pt = new Point(0, 0);
            this.Size = gs.MeasureString(display, this.Font).ToSize();
            gs.DrawString(display, this.Font, br, pt);
            base.OnPaint(pe);
        }

        private void MonospaceProgressBar_BackColorChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MonospaceProgressBar_ForeColorChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void MonospaceProgressBar_FontChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}

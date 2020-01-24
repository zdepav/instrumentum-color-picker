using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace InstrumentumColorPicker {

    internal partial class ColorPicker : UserControl {

        public const byte Primary = 0, Secondary = 1;

        private enum ColorWheelMode {
            HS,
            HV
        }

        private ColorWheelMode colorWheelMode;

        private uint selectedColorId;

        private readonly Font colorLabelFont, colorLabelFontBold;

        /// <summary>
        /// Primary or Secondary
        /// </summary>
        private uint SelectedColorId {
            set => selectedColorId = value > 1 ? 1 : value;
        }

        public CustomColor SelectedColor {
            get => colors[selectedColorId];
            set => colors[selectedColorId] = value;
        }

        private readonly CustomColor[] colors;

        private bool colorEventsAllowed;

        public delegate void RefreshMethod();

        private event RefreshMethod RefreshColorPbs;

        public ColorPicker() {
            colorWheelMode = ColorWheelMode.HV;
            InitializeComponent();
            RefreshColorPbs = RefreshColorPbs + colorPbR.Refresh + colorPbG.Refresh + colorPbB.Refresh;
            RefreshColorPbs = RefreshColorPbs + colorPbH.Refresh + colorPbS.Refresh + colorPbV.Refresh;
            RefreshColorPbs = RefreshColorPbs + colorPbA.Refresh + colorPbWheel.Refresh + colorPri.Refresh;
            RefreshColorPbs += colorSec.Refresh;
            SelectedColorId = Primary;
            colorEventsAllowed = true;
            colors = new[] { new CustomColor(Color.Black), new CustomColor(Color.White) };
            editingColor = EditingColor.No;
            colorLabelFont = labelPri.Font;
            colorLabelFontBold = new Font(colorLabelFont, FontStyle.Bold);
            RefreshColor(Exclude.None);
        }

        public CustomColor PrimaryColor {
            get => colors[Primary];
            set => colors[Primary] = value;
        }

        public CustomColor SecondaryColor => colors[Secondary];

        private static readonly Color errorColor = Color.FromArgb(255, 128, 96);

        public enum Exclude {
            None,
            Hex,
            RGB,
            HSV,
            A
        }

        private void RefreshColor(Exclude ex) {
            colorEventsAllowed = false;
            var cc = SelectedColor;
            if (ex != Exclude.A)
                colorNudA.Value = cc.A;
            if (ex != Exclude.RGB) {
                colorNudR.Value = cc.R;
                colorNudG.Value = cc.G;
                colorNudB.Value = cc.B;
            }
            if (ex != Exclude.HSV) {
                colorNudH.Value = cc.H;
                colorNudS.Value = (int)Math.Round(cc.S * 100);
                colorNudV.Value = (int)Math.Round(cc.V * 100);
            }
            if (ex != Exclude.Hex)
                colorHex.Text = cc.ToHex(colorHex.Text);
            RefreshColorPbs?.Invoke();
            colorEventsAllowed = true;
        }

        private void color_HexChanged(object sender, EventArgs e) {
            if (colorEventsAllowed) {
                var c = CustomColor.FromHex(colorHex.Text.ToLower(), (int)colorNudA.Value);
                if (c != null) {
                    colorHex.BackColor = Color.White;
                    colors[selectedColorId] = c;
                    RefreshColor(Exclude.Hex);
                } else colorHex.BackColor = errorColor;
            }
        }

        private void color_RGBChanged(object sender, EventArgs e) {
            if (colorEventsAllowed) {
                colors[selectedColorId] = CustomColor.FromRGBA((int)colorNudR.Value, (int)colorNudG.Value,
                    (int)colorNudB.Value, (int)colorNudA.Value);
                RefreshColor(Exclude.RGB);
            }
        }

        private void color_HSVChanged(object sender, EventArgs e) {
            if (colorEventsAllowed) {
                colors[selectedColorId] = new CustomColor((double)colorNudH.Value, (double)colorNudS.Value / 100.0,
                    (double)colorNudV.Value / 100.0, (int)colorNudA.Value);
                RefreshColor(Exclude.HSV);
            }
        }

        private void color_AlphaChanged(object sender, EventArgs e) {
            if (colorEventsAllowed) {
                colors[selectedColorId].A = (byte)colorNudA.Value;
                RefreshColor(Exclude.A);
            }
        }

        private void colorPri_Click(object sender, EventArgs e) {
            SelectedColorId = Primary;
            labelPri.Font = colorLabelFontBold;
            labelSec.Font = colorLabelFont;
            RefreshColor(Exclude.None);
        }

        private void colorSec_Click(object sender, EventArgs e) {
            SelectedColorId = Secondary;
            labelPri.Font = colorLabelFont;
            labelSec.Font = colorLabelFontBold;
            RefreshColor(Exclude.None);
        }

        public enum EditingColor {
            No,
            R,
            G,
            B,
            A,
            H,
            S,
            V,
            Wheel
        }

        private void colorPb_MouseUp(object sender, MouseEventArgs e) => editingColor = EditingColor.No;

        private void colorPb_MouseMove(object sender, MouseEventArgs e) {
            if (editingColor == EditingColor.No) return;
            if (editingColor == EditingColor.Wheel) {
                int x = e.X - 93, y = e.Y - 93;
                colorEventsAllowed = false;
                colorNudH.Value = (int)Math.Round((Math.Atan2(y, x) - Math.Atan2(0, 100)) / Math.PI * 180 + 360) % 360;
                colorEventsAllowed = true;
                switch (colorWheelMode) {
                    case ColorWheelMode.HV:
                        colorNudV.Value = Utils.Clamp((int)Math.Round(Math.Sqrt(x * x + y * y) / 0.93), 0, 100);
                        break;
                    case ColorWheelMode.HS:
                        colorNudS.Value = Utils.Clamp((int)Math.Round(Math.Sqrt(x * x + y * y) / 0.93), 0, 100);
                        break;
                }
                return;
            }
            var coef = Utils.Clamp((e.X - 1) / 110d, 0, 1);
            switch (editingColor) {
                case EditingColor.R:
                    colorNudR.Value = (int)Math.Round(coef * 255);
                    break;
                case EditingColor.G:
                    colorNudG.Value = (int)Math.Round(coef * 255);
                    break;
                case EditingColor.B:
                    colorNudB.Value = (int)Math.Round(coef * 255);
                    break;
                case EditingColor.A:
                    colorNudA.Value = (int)Math.Round(coef * 255);
                    break;
                case EditingColor.H:
                    colorNudH.Value = (int)Math.Round(coef * 359);
                    break;
                case EditingColor.S:
                    colorNudS.Value = (int)Math.Round(coef * 100);
                    break;
                case EditingColor.V:
                    colorNudV.Value = (int)Math.Round(coef * 100);
                    break;
            }
        }

        private void colorPb_MouseDown(object sender, MouseEventArgs e) {
            if (sender == colorPbWheel)
                editingColor = EditingColor.Wheel;
            else if (sender == colorPbR)
                editingColor = EditingColor.R;
            else if (sender == colorPbG)
                editingColor = EditingColor.G;
            else if (sender == colorPbB)
                editingColor = EditingColor.B;
            else if (sender == colorPbH)
                editingColor = EditingColor.H;
            else if (sender == colorPbS)
                editingColor = EditingColor.S;
            else if (sender == colorPbV)
                editingColor = EditingColor.V;
            else if (sender == colorPbA)
                editingColor = EditingColor.A;
            colorPb_MouseMove(sender, e);
        }

        private void colorNudH_ValueChanged(object sender, EventArgs e) {
            if (colorNudH.Value < 0)
                colorNudH.Value = 359;
            else if (colorNudH.Value > 359)
                colorNudH.Value = 0;
            color_HSVChanged(sender, e);
        }

        private void radioButtonHSxV_CheckedChanged(object sender, EventArgs e) {
            colorWheelMode = radioButtonHS.Checked ? ColorWheelMode.HS : ColorWheelMode.HV;
            colorPbWheel.Refresh();
        }

        private void colorSwapPb_Click(object sender, EventArgs e) {
            var cc = colors[0];
            colors[0] = colors[1];
            colors[1] = cc;
            RefreshColor(Exclude.None);
        }

        #region Drawing

        /***\
         ***   ███     ████       █      █         █   ███   █     █    █████
         ***   █  █    █   █     █ █     █         █    █    ██    █   █     █
         ***   █   █   █   █     █ █      █   █   █     █    █ █   █   █
         ***   █   █   ████     █   █     █   █   █     █    █  █  █   █
         ***   █   █   █ █      █████      █ █ █ █      █    █   █ █   █   ███
         ***   █  █    █  █    █     █     █ █ █ █      █    █    ██   █     █
         ***   ███     █   █   █     █      █   █      ███   █     █    █████
        \***/

        private EditingColor editingColor;

        private void colorPri_Paint(object sender, PaintEventArgs e) {
            if (selectedColorId == Primary)
                e.Graphics.DrawImage(Properties.Resources.color_border_active, 0, 0);
            e.Graphics.FillRectangle(colors[Primary].Brush, 2, 2, 28, 28);
        }

        private void colorSec_Paint(object sender, PaintEventArgs e) {
            if (selectedColorId == Secondary)
                e.Graphics.DrawImage(Properties.Resources.color_border_active, 0, 0);
            e.Graphics.FillRectangle(colors[Secondary].Brush, 2, 2, 28, 28);
        }

        private void colorPbR_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.FromArgb(0, cc.G, cc.B), Color.FromArgb(255, cc.G, cc.B));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.R / 255d * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbG_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.FromArgb(cc.R, 0, cc.B), Color.FromArgb(cc.R, 255, cc.B));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.G / 255d * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbB_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.FromArgb(cc.R, cc.G, 0), Color.FromArgb(cc.R, cc.G, 255));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.B / 255d * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbH_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var x = (int)Math.Round(cc.H / 359d * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbS_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var cc2 = new CustomColor(cc.H, 1, cc.V, 255);
            var cf = (int)Math.Round(cc.V * 255);
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.FromArgb(cf, cf, cf), Color.FromArgb(cc2.R, cc2.G, cc2.B));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.S * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbV_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            var cc2 = new CustomColor(cc.H, cc.S, 1, 255);
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.Black, Color.FromArgb(cc2.R, cc2.G, cc2.B));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.V * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbA_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            g.DrawImageUnscaled(Properties.Resources.alpha, 0, 0);
            var cc = SelectedColor;
            var lgb = new LinearGradientBrush(new Point(0, 0), new Point(112, 0),
                Color.FromArgb(0, cc.Color), Color.FromArgb(255, cc.Color));
            g.FillRectangle(lgb, 0, 0, 200, 20);
            lgb.Dispose();
            var x = (int)Math.Round(cc.A / 255d * 109);
            g.DrawRectangle(cc.BWInvertedPen, x, 0, 2, 19);
            g.DrawLine(cc.BWPen, x + 1, 1, x + 1, 18);
        }

        private void colorPbWheel_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;
            var cc = SelectedColor;
            int x = -5, y = -5;
            var rad = cc.Hrad;
            var path = new GraphicsPath();
            path.AddEllipse(0, 0, 186, 186);
            PathGradientBrush pgb;
            switch (colorWheelMode) {
                case ColorWheelMode.HV:
                    float s = (float)cc.S, coef = 1 - s;
                    var sat = new ImageAttributes().SetColorMatrixC(new ColorMatrix(
                        new[] {
                            new[] { s, 0, 0, 0, 0 },
                            new[] { 0, s, 0, 0, 0 },
                            new[] { 0, 0, s, 0, 0 },
                            new[] { 0f, 0, 0, 1, 0 },
                            new[] { coef, coef, coef, 0, 1 }
                        }));
                    g.DrawImage(Properties.Resources.hue2, new Rectangle(0, 0, 186, 186), 0, 0, 186, 186, GraphicsUnit.Pixel, sat);
                    pgb = new PathGradientBrush(path) {
                        CenterColor = Color.Black,
                        CenterPoint = new PointF(93, 93),
                        SurroundColors = new[] { Color.FromArgb(0, 0, 0, 0) }
                    };
                    g.FillRectangle(pgb, 0, 0, 186, 186);
                    pgb.Dispose();
                    x = 93 + (int)Math.Round(Math.Cos(rad) * cc.V * 93);
                    y = 93 + (int)Math.Round(Math.Sin(rad) * cc.V * 93);
                    break;
                case ColorWheelMode.HS:
                    var v = (float)cc.V;
                    var cf = (int)Math.Round(cc.V * 255);
                    var val = new ImageAttributes().SetColorMatrixC(new ColorMatrix(
                        new[] {
                            new[] { v, 0, 0, 0, 0 },
                            new[] { 0, v, 0, 0, 0 },
                            new[] { 0, 0, v, 0, 0 },
                            new[] { 0f, 0, 0, 1, 0 },
                            new[] { 0f, 0, 0, 0, 1 }
                        }
                    ));
                    g.DrawImage(Properties.Resources.hue2, new Rectangle(0, 0, 186, 186), 0, 0, 186, 186, GraphicsUnit.Pixel, val);
                    pgb = new PathGradientBrush(path) {
                        CenterColor = Color.FromArgb(cf, cf, cf),
                        CenterPoint = new PointF(93, 93),
                        SurroundColors = new[] { Color.FromArgb(0, cf, cf, cf) }
                    };
                    g.FillRectangle(pgb, 0, 0, 186, 186);
                    pgb.Dispose();
                    x = 93 + (int)Math.Round(Math.Cos(rad) * cc.S * 93);
                    y = 93 + (int)Math.Round(Math.Sin(rad) * cc.S * 93);
                    break;
            }
            var sm = e.Graphics.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillCircle(cc.BWInvertedBrush, x, y, 4);
            g.FillCircle(cc.BWBrush, x, y, 2);
            g.SmoothingMode = sm;
            if (cc.A < 255) {
                var alpha = new ImageAttributes().SetColorMatrixAlphaC((byte)(255 - cc.A));
                g.DrawImage(Properties.Resources.hue_alpha_back, new Rectangle(0, 0, 186, 186), 0, 0, 186, 186, GraphicsUnit.Pixel, alpha);
            }
        }

        #endregion

    }
}

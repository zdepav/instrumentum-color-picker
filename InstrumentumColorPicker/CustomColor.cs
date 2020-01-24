using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace InstrumentumColorPicker {

    internal class CustomColor {

        private Color color;

        /// <summary>RGBA Color</summary>
        public Color Color {
            get => color;
            set {
                color = value;
                ToHSV(out h, out s, out v);
                Brush = new SolidBrush(color);
                if (0.3f * R / 255f + 0.59f * G / 255f + 0.11f * B / 255f > 0.5f) {
                    BWInvertedPen = Pens.Black;
                    BWPen = Pens.White;
                    BWInvertedBrush = Brushes.Black;
                    BWBrush = Brushes.White;
                } else {
                    BWInvertedPen = Pens.White;
                    BWPen = Pens.Black;
                    BWInvertedBrush = Brushes.White;
                    BWBrush = Brushes.Black;
                }
            }
        }

        /// <summary>Brush with this color</summary>
        public Brush Brush { get; private set; }

        public Pen BWInvertedPen { get; private set; }
        public Pen BWPen { get; private set; }

        public Brush BWInvertedBrush { get; private set; }
        public Brush BWBrush { get; private set; }

        private int h;
        private double s, v;

        /// <summary>Red</summary>
        public byte R {
            get => Color.R;
            set => Color = Color.FromArgb(A, value, G, B);
        }

        /// <summary>Green</summary>
        public byte G {
            get => Color.G;
            set => Color = Color.FromArgb(A, R, value, B);
        }

        /// <summary>Blue</summary>
        public byte B {
            get => Color.B;
            set => Color = Color.FromArgb(A, R, G, value);
        }

        /// <summary>Alpha</summary>
        public byte A {
            get => Color.A;
            set => Color = Color.FromArgb(value, color);
        }

        /// <summary>Hue in degrees</summary>
        public int H {
            get => h;
            set {
                value = value < 0 ? -value % 360 + 360 : (value > 359 ? value % 360 : value);
                h = value;
                color = FromHSVA(h, s, v, A);
            }
        }

        /// <summary>Hue in radians</summary>
        public double Hrad {
            get => h / 180d * Math.PI;
            set => H = (int)Math.Round(value / Math.PI * 180);
        }

        /// <summary>Saturation</summary>
        public double S {
            get => s;
            set {
                value = Utils.Clamp(value, 0, 1);
                s = value;
                color = FromHSVA(h, s, v, A);
            }
        }

        /// <summary>Value</summary>
        public double V {
            get => v;
            set {
                value = Utils.Clamp(value, 0, 1);
                v = value;
                color = FromHSVA(h, s, v, A);
            }
        }

        public CustomColor(Color color) { Color = color; }

        /// <param name="H">0 ≤ Hue &lt; 360</param>
        /// <param name="S">Saturation, 0 ≤ S ≤ 1</param>
        /// <param name="V">Value, 0 ≤ V ≤ 1</param>
        /// <param name="A">Alphy, 0 ≤ A ≤ 255</param>
        public CustomColor(double H, double S, double V, int A) {
            H = H < 0 ? 0 : (H >= 360 ? H % 360 : H);
            S = Utils.Clamp(S, 0, 1);
            V = Utils.Clamp(V, 0, 1);
            A = Utils.Clamp(A, 0, 255);
            color = FromHSVA(H, S, V, A);
            h = (int)Math.Round(H);
            s = S;
            v = V;
            Brush = new SolidBrush(color);
            if (0.3f * R / 255f + 0.59f * G / 255f + 0.11f * B / 255f > 0.5f) {
                BWInvertedPen = Pens.Black;
                BWPen = Pens.White;
                BWInvertedBrush = Brushes.Black;
                BWBrush = Brushes.White;
            } else {
                BWInvertedPen = Pens.White;
                BWPen = Pens.Black;
                BWInvertedBrush = Brushes.White;
                BWBrush = Brushes.Black;
            }
        }

        public static implicit operator Color(CustomColor cc) => cc?.color ?? Color.Black;

        /// <summary>
        /// converts HSVA to RGBA
        /// formula taken from http://www.rapidtables.com/
        /// </summary>
        /// <param name="_H">Hue [0°, 360°]</param>
        /// <param name="_S">Saturation [0%, 100%]</param>
        /// <param name="_V">Value [0%, 100%]</param>
        /// <param name="_A">Alpha [0, 255]</param>
        private static Color FromHSVA(double _H, double _S, double _V, int _A) {
            var C = _V * _S;
            var X = C * (1 - Math.Abs(_H / 60 % 2 - 1));
            var m = _V - C;
            double _R = 0, _G = 0, _B = 0;
            switch ((int)_H / 60) {
                case 0:
                    _R = C;
                    _G = X;
                    _B = 0;
                    break;
                case 1:
                    _R = X;
                    _G = C;
                    _B = 0;
                    break;
                case 2:
                    _R = 0;
                    _G = C;
                    _B = X;
                    break;
                case 3:
                    _R = 0;
                    _G = X;
                    _B = C;
                    break;
                case 4:
                    _R = X;
                    _G = 0;
                    _B = C;
                    break;
                case 5:
                    _R = C;
                    _G = 0;
                    _B = X;
                    break;
            }
            return Color.FromArgb(_A, (int)((_R + m) * 255), (int)((_G + m) * 255), (int)((_B + m) * 255));
        }

        public static CustomColor FromRGBA(int R, int G, int B, int A) {
            A = Utils.Clamp(A, 0, 255);
            R = Utils.Clamp(R, 0, 255);
            G = Utils.Clamp(G, 0, 255);
            B = Utils.Clamp(B, 0, 255);
            return new CustomColor(Color.FromArgb(A, R, G, B));
        }

        private static readonly Regex hexRegex = new Regex("^[0-9a-fA-F]{3,8}$");

        /// <param name="hex">hexadecimal string</param>
        /// <param name="A">Alpha [0, 255]</param>
        /// <returns>CustomColor if hex is valid, null otherwise</returns>
        public static CustomColor FromHex(string hex, int A) {
            if (!hexRegex.IsMatch(hex)) return null;
            switch (hex.Length) {
                case 3:
                    return new CustomColor(
                        Color.FromArgb(
                            Utils.Clamp(A, 0, 255),
                            HexToByte(hex[0]),
                            HexToByte(hex[1]),
                            HexToByte(hex[2])
                        )
                    );
                case 4:
                    return new CustomColor(
                        Color.FromArgb(
                            HexToByte(hex[3]),
                            HexToByte(hex[0]),
                            HexToByte(hex[1]),
                            HexToByte(hex[2])
                        )
                    );
                case 6:
                    return new CustomColor(
                        Color.FromArgb(
                            Utils.Clamp(A, 0, 255),
                            HexToByte(hex[0], hex[1]),
                            HexToByte(hex[2], hex[3]),
                            HexToByte(hex[4], hex[5])
                        )
                    );
                case 8:
                    return new CustomColor(
                        Color.FromArgb(
                            HexToByte(hex[6], hex[7]),
                            HexToByte(hex[0], hex[1]),
                            HexToByte(hex[2], hex[3]),
                            HexToByte(hex[4], hex[5])
                        )
                    );
                default:
                    return null;
            }
        }

        public static bool ParseHex(string hex, out Color col) {
            var cc = FromHex(hex, 255);
            if (cc == null) {
                col = Color.Black;
                return false;
            } else {
                col = cc;
                return true;
            }
        }

        /// <summary>
        /// converts to HSV
        /// formula taken from http://www.rapidtables.com/
        /// </summary>
        /// <param name="_H">Hue [0°, 360°]</param>
        /// <param name="_S">Saturation [0%, 100%]</param>
        /// <param name="_V">Value [0%, 100%]</param>
        private void ToHSV(out int _H, out double _S, out double _V) {
            double _R = R / 255.0, _G = G / 255.0, _B = B / 255.0;
            var Cmax = Utils.Max(_R, _G, _B);
            var Cmin = Utils.Min(_R, _G, _B);
            var Δ = Cmax - Cmin;
            if (Math.Abs(Δ) < 0.001) {
                _H = 0;
            } else if (Math.Abs(Cmax - _R) < 0.001) {
                _H = (int)((_G - _B) / Δ % 6 * 60);
                if (_G < _B) _H += 360;
            } else if (Math.Abs(Cmax - _G) < 0.001) {
                _H = (int)(((_B - _R) / Δ + 2) * 60);
            } else /*Cmax == B*/ {
                _H = (int)(((_R - _G) / Δ + 4) * 60);
            }
            _S = Math.Abs(Cmax) < 0.001 ? 0 : Δ / Cmax;
            _V = Cmax;
        }

        // if possible, returned string will be in the same format as oldHex
        public string ToHex(string oldHex) {
            var format = 6;
            if (oldHex != null) {
                if (oldHex.Length == 3 && R % 17 == 0 && G % 17 == 0 && B % 17 == 0) {
                    format = 3;
                } else if (oldHex.Length == 4) {
                    format = R % 17 == 0 && G % 17 == 0 && B % 17 == 0 && A % 17 == 0 ? 4 : 8;
                } else if (oldHex.Length == 8) {
                    format = 8;
                }
            }
            switch (format) {
                case 3: return $"{R / 17:x}{G / 17:x}{B / 17:x}";
                case 4: return $"{R / 17:x}{G / 17:x}{B / 17:x}{A / 17:x}";
                case 8: return $"{R:x2}{G:x2}{B:x2}{A:x2}";
                default: return $"{R:x2}{G:x2}{B:x2}";
            }
        }

        private const string hexChars = "0123456789abcdef";

        private static int HexToByte(char h1, char h2) =>
            hexChars.IndexOf(h1) * 16 + hexChars.IndexOf(h2);

        private static int HexToByte(char h) =>
            hexChars.IndexOf(h) * 17;

    }

}

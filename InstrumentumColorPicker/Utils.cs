using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace InstrumentumColorPicker {

    internal static class Utils {

        public const float π = (float)Math.PI;

        /// <param name="v">value</param>
        /// <param name="min">lower interval boundary (min &lt; max)</param>
        /// <param name="max">upper interval boundary (max &gt; min)</param>
        /// <returns>v if v is between min and max, boundary closer to v otherwise</returns>
        public static double Clamp(double v, double min, double max) =>
            v > max ? max : (v < min ? min : v);

        /// <param name="v">value</param>
        /// <param name="min">lower interval boundary (min &lt; max)</param>
        /// <param name="max">upper interval boundary (max &gt; min)</param>
        /// <returns>v if v is between min and max, boundary closer to v otherwise</returns>
        public static float Clamp(float v, float min, float max) =>
            v > max ? max : (v < min ? min : v);

        /// <param name="v">value</param>
        /// <param name="min">lower interval boundary (min &lt; max)</param>
        /// <param name="max">upper interval boundary (max &gt; min)</param>
        /// <returns>v if v is between min and max, boundary closer to v otherwise</returns>
        public static int Clamp(int v, int min, int max) =>
            v > max ? max : (v < min ? min : v);

        /// <typeparam name="T">numeric type</typeparam>
        /// <param name="values"></param>
        /// <returns>maximal value in ds</returns>
        public static T Max<T>(params T[] values) {
            if (values == null) throw new ArgumentException($"{nameof(values)} can't be null", nameof(values));
            switch (values.Length) {
                case 0:  throw new ArgumentException($"{nameof(values)} must contain at least one element", nameof(values));
                case 1:  return values[0];
                default: return values.Max();
            }
        }

        /// <typeparam name="T">numeric type</typeparam>
        /// <param name="values"></param>
        /// <returns>minimal value in ds</returns>
        public static T Min<T>(params T[] values) {
            if (values == null) throw new ArgumentException($"{nameof(values)} can't be null", nameof(values));
            switch (values.Length) {
                case 0:  throw new ArgumentException($"{nameof(values)} must contain at least one element", nameof(values));
                case 1:  return values[0];
                default: return values.Min();
            }
        }

        public static IEnumerable<T> Subsequence<T>(IEnumerable<T> sequence, int start) {
            if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
            foreach (var t in sequence) {
                if (start > 0) {
                    --start;
                } else yield return t;
            }
        }

        public static IEnumerable<T> Subsequence<T>(IEnumerable<T> sequence, int start, int length) {
            if (start < 0) throw new ArgumentOutOfRangeException(nameof(start));
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            if (length == 0) yield break;
            foreach (var t in sequence) {
                if (start > 0) {
                    --start;
                } else if (length > 0) {
                    --length;
                    yield return t;
                } else yield break;
            }
        }

        public static void DrawTriangle(this Graphics g, Pen p, Point p1, Point p2, Point p3) =>
            DrawTriangle(g, p, p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);

        public static void DrawTriangle(this Graphics g, Pen p, int p1x, int p1y, int p2x, int p2y, int p3x, int p3y) {
            g.DrawLine(p, p1x, p1y, p2x, p2y);
            g.DrawLine(p, p2x, p2y, p3x, p3y);
            g.DrawLine(p, p3x, p3y, p1x, p1y);
        }

        public static void FillTriangle(this Graphics g, Brush b, Point p1, Point p2, Point p3) =>
            g.FillPolygon(b, new[] { p1, p2, p3 });

        public static void FillTriangle(this Graphics g, Brush b, int p1x, int p1y, int p2x, int p2y, int p3x, int p3y) =>
            FillTriangle(g, b, new Point(p1x, p1y), new Point(p2x, p2y), new Point(p3x, p3y));

        public static void DrawCircle(this Graphics g, Pen p, Point center, int radius) =>
            g.DrawEllipse(p, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

        public static void DrawCircle(this Graphics g, Pen p, int x, int y, int radius) =>
            g.DrawEllipse(p, x - radius, y - radius, 2 * radius, 2 * radius);

        public static void FillCircle(this Graphics g, Brush b, Point center, int radius) =>
            g.FillEllipse(b, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

        public static void FillCircle(this Graphics g, Brush b, int x, int y, int radius) =>
            g.FillEllipse(b, x - radius, y - radius, 2 * radius, 2 * radius);

        public static byte[] ToAsciiBytes(this string s) =>
            s.Length == 0 ? new byte[0] : Encoding.ASCII.GetBytes(s);
        
        public static readonly Random Random = new Random();

        /// <param name="ia">this</param>
        /// <param name="cm">Color matrix<br /><code>
        /// ┌───┬─────┬─────┬─────┬─────┬─────┐
        /// │   │ R = │ G = │ B = │ A = │ 1 = │
        /// ├───┼─────┼─────┼─────┼─────┼─────┤
        /// │ R │     │     │     │     │  0  │
        /// ├ + ┼─────┼─────┼─────┼─────┼─────┤
        /// │ G │     │     │     │     │  0  │
        /// ├ + ┼─────┼─────┼─────┼─────┼─────┤
        /// │ B │     │     │     │     │  0  │
        /// ├ + ┼─────┼─────┼─────┼─────┼─────┤
        /// │ A │     │     │     │     │  0  │
        /// ├ + ┼─────┼─────┼─────┼─────┼─────┤
        /// │   │     │     │     │     │  1  │
        /// └───┴─────┴─────┴─────┴─────┴─────┘
        /// </code></param>
        /// <returns>this</returns>
        public static ImageAttributes SetColorMatrixC(this ImageAttributes ia, ColorMatrix cm) {
            ia.SetColorMatrix(cm);
            return ia;
        }

        public static ImageAttributes SetColorMatrixAlphaC(this ImageAttributes ia, byte alpha) {
            ia.SetColorMatrix(new ColorMatrix(
                new[] {
                    new[] { 1f, 0, 0, 0, 0 },
                    new[] { 0f, 1, 0, 0, 0 },
                    new[] { 0f, 0, 1, 0, 0 },
                    new[] { 0f, 0, 0, alpha / 255f, 0 },
                    new[] { 0f, 0, 0, 0, 1 }
                }));
            return ia;
        }

        /// <summary>square (2nd power)</summary>
        /// <param name="f">number</param>
        /// <returns>f²</returns>
        public static float Sqr(float f) => f * f;

        /// <summary>cube (3rd power)</summary>
        /// <param name="f">number</param>
        /// <returns>f³</returns>
        public static float Cube(float f) => f * f * f;

        /// <summary>4th power</summary>
        /// <param name="f">number</param>
        /// <returns>f⁴</returns>
        public static float Sqr2(float f) => f * f * f * f;

        /// <summary>
        /// "Wraps" value between 0 and bound.
        /// </summary>
        /// <param name="value">value to wrap</param>
        /// <param name="bound">bound &gt; 0</param>
        /// <returns>v; 0 ≤ v &lt; bound</returns>
        public static int Wrap(int value, int bound) {
            if (value >= 0) return value >= bound ? value % bound : value;
            while (value < 0) value += bound;
            return value;
        }

        public static Color MultiplyColorByFloat(Color c, float f, bool mulAlpha = false) =>
            Color.FromArgb(mulAlpha ? ColorComponent(c.A * f) : c.A,
                ColorComponent(c.R * f), ColorComponent(c.G * f), ColorComponent(c.B * f));

        public static Color MultiplyColorByInt(Color c, int i) =>
            Color.FromArgb(c.A, Clamp(c.R * i, 0, 255), Clamp(c.G * i, 0, 255), Clamp(c.B * i, 0, 255));

        public static int ColorComponent(int i) => Clamp(i, 0, 255);

        public static int ColorComponent(float f) => Clamp((int)Math.Round(f), 0, 255);

        public static int ColorComponent(double f) => Clamp((int)Math.Round(f), 0, 255);

        public static float ColorIntensity(Color c) =>
            Clamp(0.3f * c.R + 0.59f * c.G + 0.11f * c.B, 0, 255);

        public static float ColorIntensity01(Color c) =>
            Clamp((0.3f * c.R + 0.59f * c.G + 0.11f * c.B) / 255, 0, 1);

        public static int IntColorIntensity(Color c) =>
            Clamp((int)Math.Round(0.3 * c.R + 0.59 * c.G + 0.11 * c.B), 0, 255);

        public static Color ColorFromIntensity(int intensity, int alpha = 255) =>
            Color.FromArgb(
                alpha,
                ColorComponent(intensity),
                ColorComponent(intensity),
                ColorComponent(intensity));

        public static Color ColorFromIntensity(float intensity, int alpha = 255) =>
            Color.FromArgb(alpha, ColorComponent(intensity), ColorComponent(intensity), ColorComponent(intensity));

        public static Color ColorFromIntensity01(float intensity, int alpha = 255) =>
            Color.FromArgb(alpha, ColorComponent(intensity * 255f), ColorComponent(intensity * 255f), ColorComponent(intensity * 255f));

        /// <summary>Compares two colors</summary>
        public static bool ColorsEqual(Color c1, Color c2) =>
            c1.R == c2.R && c1.G == c2.G && c1.B == c2.B && c1.A == c2.A;

        /// <summary>Multiplies two colors</summary>
        public static Color MultiplyColors(Color c1, Color c2) =>
            Color.FromArgb(
                ColorComponent(c1.A * c2.A / 255f),
                ColorComponent(c1.R * c2.R / 255f),
                ColorComponent(c1.G * c2.G / 255f),
                ColorComponent(c1.B * c2.B / 255f));

        /// <summary>Multiplies two colors</summary>
        public static Color AddColors(Color c1, Color c2) =>
            Color.FromArgb(
                ColorComponent(c1.A + c2.A),
                ColorComponent(c1.R + c2.R),
                ColorComponent(c1.G + c2.G),
                ColorComponent(c1.B + c2.B));

        /// <summary>
        /// Calculates dinstance between two points
        /// </summary>
        /// <param name="x1">x-coordinate of 1st point</param>
        /// <param name="y1">y-coordinate of 1st point</param>
        /// <param name="x2">x-coordinate of 2nd point</param>
        /// <param name="y2">y-coordinate of 2nd point</param>
        /// <returns>calculated distance</returns>
        public static float Distance(int x1, int y1, int x2, int y2) =>
            (float)Math.Sqrt(Sqr(x1 - x2) + Sqr(y1 - y2));

        /// <summary>
        /// Calculates direction (in degrees) from [0,0] to given point
        /// </summary>
        /// <param name="x">x-coordinate of the point</param>
        /// <param name="y">y-coordinate of the point</param>
        /// <returns>calculated direction</returns>
        public static float Direction(float x, float y) => ((float)Math.Atan2(y, x) * 180f / π + 360f) % 360f;
        
        /// <summary>
        /// Premultiplies given color by it's alpha value
        /// </summary>
        /// <param name="c">color to be premultiplied</param>
        /// <returns>premultiplied version of c</returns>
        public static Color PremultiplyColor(Color c) {
            var a = c.A / 255f;
            return Color.FromArgb(c.A, (byte)Math.Round(a * c.R),
                (byte)Math.Round(a * c.G), (byte)Math.Round(a * c.B));
        }

        /// <summary>
        /// Combines c1 and c2 by a given amount.
        /// </summary>
        /// <param name="c1">1st combined color</param>
        /// <param name="c2">2nd combined color</param>
        /// <param name="diff">0 ≤ diff ≤ 1</param>
        /// <returns>combination of c1 and c2</returns>
        public static Color Lerp(Color c1, Color c2, float diff) {
            var rdiff = 1 - diff;
            return Color.FromArgb(
                (byte)(c2.A * diff + c1.A * rdiff),
                (byte)(c2.R * diff + c1.R * rdiff),
                (byte)(c2.G * diff + c1.G * rdiff),
                (byte)(c2.B * diff + c1.B * rdiff));
        }

        /// <summary>
        /// Combines c1 and c2 by a given amount, sets transparency to alpha.
        /// </summary>
        /// <param name="c1">1st combined color</param>
        /// <param name="c2">2nd combined color</param>
        /// <param name="diff">0 ≤ diff ≤ 1</param>
        /// <param name="alpha">transparency value</param>
        /// <returns>combination of c1 and c2</returns>
        public static Color Lerp(Color c1, Color c2, float diff, byte alpha) {
            var rdiff = 1 - diff;
            return Color.FromArgb(alpha,
                (byte)(c2.R * diff + c1.R * rdiff),
                (byte)(c2.G * diff + c1.G * rdiff),
                (byte)(c2.B * diff + c1.B * rdiff));
        }

        public static readonly ImageAttributes IATileFlipXY, IAHalfTransparent;

        static Utils() {
            IATileFlipXY = new ImageAttributes();
            IATileFlipXY.SetWrapMode(WrapMode.TileFlipXY);
            IAHalfTransparent = new ImageAttributes();
            IAHalfTransparent.SetColorMatrix(new ColorMatrix { Matrix33 = 0.5f });
        }
    }
}

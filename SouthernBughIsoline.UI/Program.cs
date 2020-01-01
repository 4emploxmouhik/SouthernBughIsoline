using Isoline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SouthernBughIsoline
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run();

            #region Points
            PointF3D a = new PointF3D(0, 0, 16);
            PointF3D b = new PointF3D(0, 0, 0);
            PointF3D c = new PointF3D(0, 0, 3);
            PointF3D d = new PointF3D(0, 0, 16);
            PointF3D e = new PointF3D(0, 0, 10);
            PointF3D f = new PointF3D(0, 0, 7);
            PointF3D g = new PointF3D(0, 0, 12);
            PointF3D h = new PointF3D(0, 0, 10);
            PointF3D i = new PointF3D(0, 0, 18);
            PointF3D j = new PointF3D(0, 0, 14);
            PointF3D k = new PointF3D(0, 0, 13);
            PointF3D l = new PointF3D(0, 0, 1);
            PointF3D m = new PointF3D(0, 0, 6);
            PointF3D n = new PointF3D(0, 0, 10);
            PointF3D o = new PointF3D(0, 0, 3);
            PointF3D p = new PointF3D(0, 0, 17);
            PointF3D q = new PointF3D(0, 0, 13);
            PointF3D r = new PointF3D(0, 0, 19);
            PointF3D s = new PointF3D(0, 0, 2);
            PointF3D t = new PointF3D(0, 0, 19);
            #endregion

            #region Segments
            Segment ab = new Segment(a, b) { Name = "AB", IsEdge = true };
            Segment af = new Segment(a, f) { Name = "AF" };
            Segment bc = new Segment(b, c) { Name = "BC", IsEdge = true };
            Segment bg = new Segment(b, g) { Name = "BG" };
            Segment cd = new Segment(c, d) { Name = "CD", IsEdge = true };
            Segment ch = new Segment(c, h) { Name = "CH" };
            Segment de = new Segment(d, e) { Name = "DE", IsEdge = true };
            Segment di = new Segment(d, i) { Name = "DI" };
            Segment ej = new Segment(e, j) { Name = "EJ", IsEdge = true };

            Segment fg = new Segment(f, g) { Name = "FG" };
            Segment fk = new Segment(f, k) { Name = "FK", IsEdge = true };
            Segment gh = new Segment(g, h) { Name = "GH" };
            Segment gl = new Segment(g, l) { Name = "GL" };
            Segment hi = new Segment(h, i) { Name = "HI" };
            Segment hm = new Segment(h, m) { Name = "HM" };
            Segment ij = new Segment(i, j) { Name = "IJ" };
            Segment _in = new Segment(i, n) { Name = "IN" };
            Segment jo = new Segment(j, o) { Name = "JO", IsEdge = true };

            Segment kl = new Segment(k, l) { Name = "KL" };
            Segment kp = new Segment(k, p) { Name = "KP", IsEdge = true };
            Segment lm = new Segment(l, m) { Name = "LM" };
            Segment lq = new Segment(l, q) { Name = "LQ" };
            Segment mn = new Segment(m, n) { Name = "MN" };
            Segment mr = new Segment(m, r) { Name = "MR" };
            Segment no = new Segment(n, o) { Name = "NO" };
            Segment ns = new Segment(n, s) { Name = "NS" };
            Segment ot = new Segment(o, t) { Name = "OT", IsEdge = true };

            Segment pq = new Segment(p, q) { Name = "PQ", IsEdge = true };
            Segment qr = new Segment(q, r) { Name = "QR", IsEdge = true };
            Segment rs = new Segment(r, s) { Name = "RS", IsEdge = true };
            Segment st = new Segment(s, t) { Name = "ST", IsEdge = true };
            #endregion

            #region Cells
            Cell abgf = new Cell(ab, af, bg, fg) { Name = "ABGF" };
            Cell bchg = new Cell(bc, bg, ch, gh) { Name = "BCHG" };
            Cell cdih = new Cell(cd, ch, di, hi) { Name = "CDIH" };
            Cell deji = new Cell(de, di, ej, ij) { Name = "DEJI" };

            Cell fglk = new Cell(fg, fk, gl, kl) { Name = "FGLK" };
            Cell ghml = new Cell(gh, gl, hm, lm) { Name = "GHML" };
            Cell hinm = new Cell(hi, hm, _in, mn) { Name = "HINM" };
            Cell ijon = new Cell(ij, _in, jo, no) { Name = "IJON" };

            Cell klqp = new Cell(kl, kp, lq, pq) { Name = "KLQP" };
            Cell lmrq = new Cell(lm, lq, mr, qr) { Name = "LMRQ" };
            Cell mnsr = new Cell(mn, mr, ns, rs) { Name = "MNSR" };
            Cell nots = new Cell(no, ns, ot, st) { Name = "NOTS" };

            #endregion 

            float level = 5;

            Grid grid = new Grid()
            {
                Nodes = { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t },
                Segments = { ab, af, bc, bg, cd, ch, de, di, ej, fg, fk, gh, gl, hi, hm, ij, _in, jo, kl, kp, lm, lq, mn, mr, no, ns, ot, pq, qr, rs, st },
                Cells = { abgf, bchg, cdih, deji, fglk, ghml, hinm, ijon, klqp, lmrq, mnsr, nots }
            };

            for (int _i = 0; _i < grid.Segments.Count; _i++)
            {
                grid.Segments[_i].Number = _i;
            }

            int x, num = 1;
            float[] lvl = { 5f, 8f };


            //for (x = 0; x < 2; x++){ 
            //    LevelLine[] levelLines = grid.FindLevelLines(lvl[x]);

            //    Console.Write("\nLevel = " + lvl[x]);

            //    foreach (var line in levelLines)
            //    {
            //        Console.Write($"\nLine #{num++}: ");

            //        foreach (var point in line.Points)
            //            Console.Write(point.Parent.Name + " ");
            //    }

            //    num = 1;
            //}

            grid.FindLevelLines(new[] { 5f, 8f });

            foreach (var lvlLine in grid.LevelLines)
            {
                Console.WriteLine("\nLevel = " + lvlLine.Level);

                for (x = 0; x < lvlLine.Lines.Length; x++)
                {
                    Console.Write($"Line #{num++}: ");

                    foreach (var point in lvlLine.Lines[x].Points)
                    {
                        Console.Write(point.Parent.Name + " ");
                    }

                    Console.WriteLine();
                }

                num = 1;
            }



        }
    }
}

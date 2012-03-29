using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.SqlServerCe;
using ZedGraph;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class ReportHtml : BaseReportDay
    {
        int Width, Height;
        int Koef = 5;
        public ReportHtml(string _fileName, DateTime _start, DateTime _end, int w, int h)
            : base(_fileName, _start, _end)
        {
            Width = w > 0 ? w : 640;
            Height = h > 0 ? h : 480;
 
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int i, n, j, m;
            string[,] table = GetTable();
            n = table.GetLength(0);
            m = table.GetLength(1);

            for (i = 0; i < n; i++)
            {
                if (ProgressTable[i] > 0) table[i, m - 1] += " <font color=\"339900\">&uarr;</font>";
                if (ProgressTable[i] < 0) table[i, m - 1] += " <font color=\"#FF0000\">&darr;</font>";
                result.AppendFormat("<tr style=\"{0}\">", GetColumnStyle());
                for (j = 0; j < m; j++)
                {
                    result.AppendFormat("<td style=\"{0}\">", GetCellStyle());
                    result.Append(table[i, j]);
                    result.Append("</td>");

                }
                //result.Append("<td>");
                //if (ProgressTable[i] > 0) result.Append("<font color=\"339900\">&uarr;</font>");
                //if (ProgressTable[i] < 0) result.Append("<font color=\"#FF0000\">&darr;</font>");
                //result.Append("</td>");
                result.Append("</tr>");
            }
            result.AppendFormat("<tr><td colspan=\"{0}\"> <hr> </td></tr>", m);
            return result.ToString();
        }
        private string GetColumnStyle()
        {
            return @"";
        }
        private string GetCellStyle()
        {
            return @"width:350px";
        }
        private string GetTableBorderStyle()
        {
            return @"
            border: 1px outset gray;
            border-collapse: separate;
            border-spacing: 2px;
            background-color: white;
            border-image: initial;
            border-width: 1px;
            border-color: gray;
            border-style: outset;
            border-bottim: none;";
        }
        protected override string GenerateHeader()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<html>");
            result.Append("<body>");

            result.AppendFormat("<table style=\"{0}\">", GetTableBorderStyle());
            return result.ToString();
        }
        protected override string GenerateFooter()
        {
            StringBuilder result = new StringBuilder();
            result.Append("</table>");


            ZedGraph.ZedGraphControl zgc = new ZedGraph.ZedGraphControl();
            //zgc.GraphPane.Rect = new RectangleF(0,0,640,480);
            zgc.Width = Width;
            zgc.Height = Height;
            //Image img = zgc.CreateImage();
            //mg.Save("asd", );
            string path = Path.GetDirectoryName(fileName) + "\\Pics";
            Directory.CreateDirectory(path);
            string imageFilePath;

           
            //myPane.Title.IsVisible = false;
            zgc.GraphPane.XAxis.Title.Text = "Date";
            zgc.GraphPane.YAxis.Title.Text = "Weight";
            zgc.GraphPane.XAxis.Type = AxisType.Date;
            result.Append("<table>");
            using (SqlCeConnection connection = new SqlCeConnection(dbBusiness.connectionString))
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    PointPairList pointWeightCount = new PointPairList();
                    // PointPairList pointBodyWeight = new PointPairList();
                    PointPairList pointWeight = new PointPairList();
                    PerfomanceDataType previous = null;
                    foreach (var exersize in TrainingBusiness.GetExersizes(cmd))
                    {
                        #region ExersizeReport
                        pointWeight.Clear();
                        pointWeightCount.Clear();
                        foreach (PerfomanceDataType p in TrainingBusiness.GetPerfomance(cmd, start, end, exersize.ExersizeID))
                        {
                            string tag = string.Format("Дата:{0} {1}x{2}={3}", p.Day.ToString("dd.MM.yyyy"), p.Weight, p.Count, p.Weight * p.Count);

                            pointWeightCount.Add(p.Day.ToOADate(), p.Weight * p.Count, tag);

                            if (previous == null || previous.Weight != p.Weight)
                                pointWeight.Add(p.Day.ToOADate(), p.Weight, tag);

                            previous = p;
                        }
                        result.Append("<tr><td>");
                        zgc.GraphPane.Title.Text = exersize.ShortName;
                        zgc.GraphPane.CurveList.Clear();
                        zgc.GraphPane.AddCurve("Вес * Повторения", pointWeightCount, Color.Red, SymbolType.Circle);
                        zgc.AxisChange();
                        zgc.Refresh();
                        using (Image img = zgc.CreateImage())
                        {
                            imageFilePath = string.Format("{0}\\{1}_{2}_WeightCount.jpg", path, exersize.ShortName, exersize.ExersizeID).
                                Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\r", string.Empty);
                            try
                            {
                                SaveBitmapByExtension(imageFilePath, img, System.Drawing.Imaging.ImageFormat.Jpeg);
                            }
                            catch (Exception e)
                            {
                                string ee = e.Message;
                            }
                        }
                        result.AppendFormat("<img src='{0}' />", imageFilePath);
                        result.Append("</td><td>");
                        
                        zgc.GraphPane.CurveList.Clear();
                        zgc.GraphPane.AddCurve("Weight", pointWeight, Color.Brown, SymbolType.Circle);
                        zgc.AxisChange();
                        zgc.Refresh();
                        using (Image img = zgc.CreateImage())
                        {

                            imageFilePath = string.Format("{0}\\{1}_{2}_Weight.jpg", path, exersize.ShortName, exersize.ExersizeID).
                                Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\r", string.Empty);
                            try
                            {
                                SaveBitmapByExtension(imageFilePath, img, System.Drawing.Imaging.ImageFormat.Jpeg);
                                //img.Save(imageFilePath, );
                            }
                            catch (Exception e)
                            {
                                string ee = e.Message;
                            }
                        }
                        result.AppendFormat("<img src='{0}' />", imageFilePath);

                        result.Append("</td></tr>");
                        #endregion


                        base.IncrementProgress(Koef);
                    }
                    connection.Close();
                }
            }
            result.Append("</table>");
            #region Weight & Measurements Report

            #endregion

            result.Append("</body>");
            result.Append("</html>");

            
            return result.ToString();
        }
        private static Bitmap ExtractBitmapFromOpenedFile(Image curentImage)
        {
            Bitmap bitmapToSave = new Bitmap(curentImage.Width, curentImage.Height, PixelFormat.Format24bppRgb);
            bitmapToSave.SetResolution(curentImage.Width, curentImage.Height);

            using (Graphics graphics = Graphics.FromImage(bitmapToSave))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.DrawImage(curentImage,
                                   new Rectangle(0, 0, curentImage.Width, curentImage.Height),
                                   0, 0, curentImage.Width, curentImage.Height,
                                   GraphicsUnit.Pixel);

            }
            return bitmapToSave;
        }

        //--------------

        private static void SaveBitmapByExtension(string fullFileName, Image curentImage, ImageFormat imageFormat)
        {
         
                using (Bitmap bitmapToSave = ExtractBitmapFromOpenedFile(curentImage))
                {

                    ///EncoderParameters encoderParameters = new EncoderParameters(1);
                    //encoderParameters.Param[0] =
                    //    new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, imageQuality);
                    // bitmapToSave.Save(fullFileName, GetEncoder(imageFormat), encoderParameters);
                    bitmapToSave.Save(fullFileName, imageFormat);
                }
          
        }

        protected override int TactsForFooter()
        {
            using (SqlCeConnection connection = new SqlCeConnection(dbBusiness.connectionString))
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    var exersizes = TrainingBusiness.GetExersizes(cmd);
                    if (exersizes != null) return exersizes.Count * Koef;
                }
            }
            return 0;
        }
    }
}

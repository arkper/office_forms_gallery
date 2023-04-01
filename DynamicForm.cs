using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace OfficeForms
{
    public partial class DynamicForm : Form
    {
        public bool Test = false;
        
        Bitmap bitmap = null;
        Graphics graph = null;
        bool startSign;
        static int lastX;
        static int lastY;

        private Patient patient;

        internal Patient Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        private Document document;

        internal Document Document
        {
            get { return document; }
            set { document = value; }
        }


        private string targetFile;

        public string TargetFile
        {
            get { return targetFile; }
            set { targetFile = value; }
        }
        private string tempFile;

        public string TempFile
        {
            get { return tempFile; }
            set { tempFile = value; }
        }

        public string templatePath;

        public DynamicForm()
        {
            InitializeComponent();
        }

        private void DynamicForm_Load(object sender, EventArgs e)
        {
            templatePath = ConfigurationManager.AppSettings[document.DocTypeName];
            if (document.Id == 0)
            {
                wbDocView.Url = new Uri(templatePath);

                string fileName = System.Guid.NewGuid().ToString();

                targetFile = ConfigurationManager.AppSettings["docRepositoryFolder"] +
                    fileName + ".pdf";

                tempFile = ConfigurationManager.AppSettings["tempPath"] +
                    fileName + ".html";

            }
            else
            {
                if (!document.DocLink.Contains("/") && !document.DocLink.Contains("\\"))
                    wbDocView.Url = new Uri(("file:///" + ConfigurationManager.AppSettings["docRepositoryFolder"] + document.DocLink).Replace("\\", "/"));
                else
                    wbDocView.Url = new Uri(("file:///" + document.DocLink).Replace("\\", "/"));
                string fileName = new FileInfo(document.DocLink).Name;
                fileName = fileName.Replace(".html", "").Replace(".pdf", "");
                targetFile = ConfigurationManager.AppSettings["docRepositoryFolder"] +
                    fileName + ".pdf";

                tempFile = ConfigurationManager.AppSettings["tempPath"] +
                    fileName + ".html";

                if (document.DocLink.IndexOf("html") < 0)
                {
                    btnSave.Visible = false;
                    btnSign.Visible = false;
                }

            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                Utility.SetupSigPad(sigPlusNET1, ConfigurationManager.AppSettings["Signature Pad Image"]);
                sigPlusNET1.Visible = true;
            }
            catch (Exception ex)
            {
                picSig.Visible = true;
                btnClear.Visible = true;
                btnOK.Visible = true;
                bitmap = new Bitmap(picSig.Width, picSig.Height);
                graph = Graphics.FromImage(bitmap);
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graph.FillRectangle(Brushes.White, new Rectangle(0, 0, picSig.Width, picSig.Height));
                picSig.Image = bitmap;


            }
                       
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            // Save HTML Document to disk
            if (document.Id == 0)
                fs = new FileStream(tempFile, FileMode.Create);
            else
                fs = new FileStream(document.DocLink, FileMode.Create);

            string content = "<html>" +
                wbDocView.Document.Body.InnerHtml +
                "</html>";
            byte[] doc = System.Text.ASCIIEncoding.ASCII.GetBytes(content);

            fs.Write(doc, 0, doc.Length);

            fs.Flush();
            fs.Close();

            if (document.Id == 0)
            {
                document.DocLink = tempFile;
                document.RecordedDate = System.DateTime.Now;
                document.ExpirationDate = System.DateTime.Now.AddYears(1);

                document.Save(Utility.GetConnection(), Patient);
            }
           

            this.Hide();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void wbDocView_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Utility.TransformHtml(wbDocView.Document, tempFile, patient);

            //wbDocView.Url = new Uri(tempFile);

        }


        private void sigPlusNET1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sigPlusNET1.KeyPadQueryHotSpot(0) > 0) //clear chosen
            {
                timer1.Enabled = false;
                sigPlusNET1.ClearSigWindow(1);
                sigPlusNET1.ClearTablet();
                sigPlusNET1.LCDRefresh(1, 32, 153, 37, 15); //invert px at CLEAR so user knows its been tapped
                System.Threading.Thread.Sleep(600);
                sigPlusNET1.LCDRefresh(2, 0, 150, 320, 90); //refresh lcd with background ONLY at bottom of LCD
                sigPlusNET1.ClearSigWindow(1);
                timer1.Enabled = true;
            }

            if (sigPlusNET1.KeyPadQueryHotSpot(1) > 0) //OK chosen
            {
                timer1.Enabled = false;
                sigPlusNET1.ClearSigWindow(1);
                sigPlusNET1.LCDRefresh(1, 250, 153, 34, 15);
                System.Threading.Thread.Sleep(500);
                sigPlusNET1.LCDRefresh(1, 250, 153, 34, 15);

                if (sigPlusNET1.NumberOfTabletPoints() > 0) //if there is a signature
                {
                    sigPlusNET1.LCDRefresh(0, 0, 0, 320, 240);
                    sigPlusNET1.SetTabletState(0);
                    sigPlusNET1.SetJustifyMode(5); //zoom signature within sigplus

                    Font my10font = new System.Drawing.Font("Arial", 10.0F, System.Drawing.FontStyle.Regular);

                    int minX, maxX, minY, maxY, aX, aY, ratio, aIndex, bIndex, fixedY;

                    // First signature

                    minX = sigPlusNET1.GetPointXValue(0, 1);
                    maxX = sigPlusNET1.GetPointXValue(0, 1);
                    minY = sigPlusNET1.GetPointYValue(0, 1);
                    maxY = sigPlusNET1.GetPointYValue(0, 1);

                    for (aIndex = 0; aIndex < sigPlusNET1.GetNumberOfStrokes(); aIndex++)
                    {
                        for (bIndex = 0; bIndex < sigPlusNET1.GetNumPointsForStroke(aIndex); bIndex++)
                        {
                            aX = sigPlusNET1.GetPointXValue(aIndex, bIndex);
                            aY = sigPlusNET1.GetPointYValue(aIndex, bIndex);

                            if (aX < minX)
                            {
                                minX = aX;
                            }

                            if (aX > maxX)
                            {
                                maxX = aX;
                            }

                            if (aY < minY)
                            {
                                minY = aY;
                            }

                            if (aY > maxY)
                            {
                                maxY = aY;
                            }

                        }
                    }

                    ratio = ((maxX - minX) / (maxY - minY));
                    fixedY = 200;
                    sigPlusNET1.SetImagePenWidth((int)(fixedY * 0.1));
                    sigPlusNET1.SetJustifyMode(5);

                    sigPlusNET1.SetImageXSize((int)((ratio * fixedY) * 1.5));
                    sigPlusNET1.SetImageYSize((int)(fixedY * 1.5));
                    sigPlusNET1.SetAntiAliasLineScale(0.4f);
                    sigPlusNET1.SetAntiAliasSpotSize(0.25f);

                    System.Drawing.Image sigImage1 = sigPlusNET1.GetSigImage();
                    sigImage1.Save(ConfigurationManager.AppSettings["Signature Image File"], System.Drawing.Imaging.ImageFormat.Bmp);

                    sigPlusNET1.SetTabletState(1);

                    Font my13font = new System.Drawing.Font("Arial", 13.0F, System.Drawing.FontStyle.Regular);

                    sigPlusNET1.LCDWriteString(0, 2, 63, 180, my13font, "Thank You For Signing!");
                    System.Threading.Thread.Sleep(1000);
                    sigPlusNET1.LCDRefresh(0, 0, 0, 320, 240);
                    sigPlusNET1.SetLCDCaptureMode(1);
                    sigPlusNET1.SetTabletState(0);
                    sigPlusNET1.Visible = false;
                    FinalizeDoc();
                }
            }

        }


        private void FinalizeDoc()
        {
            wbDocView.Document.GetElementById("@signature").SetAttribute("value", ConfigurationManager.AppSettings["Signature Image File"]);
            Utility.TransformPdf(templatePath.Replace(".html", ".pdf"), targetFile, wbDocView.Document);

            //Utility.createPDF(targetFile, wbDocView.Document.Body.OuterHtml);

            wbDocView.Url = new System.Uri("file:///" + targetFile.Replace("\\", "/"));

            document.DocLink = targetFile;
            document.RecordedDate = System.DateTime.Now;
            document.ExpirationDate = System.DateTime.Now.AddYears(1);

            document.Save(Utility.GetConnection(), Patient);

            btnSave.Visible = false;
            btnSign.Visible = false;

        }

        private void picSig_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            startSign = true;
        }
        private void picSig_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            startSign = false;
            lastX = 0;
            lastY = 0;
        }
        private void picSig_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!startSign)
                return;

            try
            {
                int newX = e.X;
                int newY = e.Y;

                if (lastX == 0 && lastY == 0)
                {
                    bitmap.SetPixel (newX, newY, Color.Black);
                }
                else
                {
                    graph.DrawLine(
                        new Pen(Brushes.Black, 3),
                        new Point(lastX, lastY),
                        new Point(newX, newY));
                }
                lastX = newX;
                lastY = newY;

                //Rectangle rect = new Rectangle(e.X, e.Y, 4, 4);
                //graph.FillRegion(Brushes.Black, new Region(rect));
                picSig.Refresh();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graph.FillRectangle(Brushes.White, new Rectangle(0, 0, 400, 100));
            picSig.Refresh();
            lastX = 0;
            lastY = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bitmap.Save(ConfigurationManager.AppSettings["Signature Image File"]);
            FinalizeDoc();
            picSig.Visible = false;
            btnClear.Visible = false;
            btnOK.Visible = false;
        }
    }
}

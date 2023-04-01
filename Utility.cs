using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

namespace OfficeForms
{
    class Utility
    {
        private static OleDbConnection connection = null;
        private static Dictionary<string, string> docTypes;

        public static Dictionary<string, string> DocTypes
        {
            get {
                if (docTypes == null)
                {
                    docTypes = new Dictionary<string, string>();
                    OleDbCommand cmd = new OleDbCommand
                    (
                        "select code, description from code where code_category_cd in (81,93)",
                        GetConnection()
                    );
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        docTypes.Add(reader.GetInt32(0).ToString(), reader.GetString(1));
                    }

                }
                
                return Utility.docTypes; 
            }
            
            
            set { Utility.docTypes = value; }
        }

        public static void GetInsuranceCompanies(ref Dictionary<string, string> companies)
        {
            companies = new Dictionary<string, string>();
            OleDbCommand cmd = new OleDbCommand
            (
                "select insurance_no, insurance_name from insurance order by 2",
                GetConnection()
            );
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                companies.Add(reader.GetString(1), reader.GetInt32(0).ToString());
            }


        }


        public static void GetRecallTypes(ref Dictionary<string, string> recallTypes)
        {
            recallTypes = new Dictionary<string, string>();
            OleDbCommand cmd = new OleDbCommand
            (
                "select recall_no, recall_name from recall_type order by 2",
                GetConnection()
            );
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                recallTypes.Add(reader.GetString(1), reader.GetInt32(0).ToString());
            }


        }


        public static Document.DocTypes GetDocTypeCode(string DocTypeDesc)
        {
            Document.DocTypes docTypeCode = Document.DocTypes.Unknown;

            if (DocTypes.ContainsValue(DocTypeDesc))
            {
                foreach (string key in DocTypes.Keys)
                {
                    if (DocTypes[key] == DocTypeDesc)
                        return (Document.DocTypes) Int32.Parse (key);
                }

            }

            return docTypeCode;
        }

        
        public static OleDbConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new OleDbConnection(Properties.Settings.Default.omateConnectionString);
                connection.Open();
            }

            return connection;
        }

        public static void ShutdownConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }


        public static void TransformPdf(string templateFile, string targetFile, System.Windows.Forms.HtmlDocument htmlDoc)
        {
        
            PdfReader reader = new PdfReader(templateFile);
            FileStream outFile = new FileStream(targetFile, FileMode.Create);
            PdfStamper stamper = new PdfStamper(reader, outFile);
            AcroFields fields = stamper.AcroFields;
            Dictionary<string, AcroFields.Item>.KeyCollection fieldKeys = fields.Fields.Keys;
            string signatureFieldName = null;

            for (IEnumerator<string> enu = fieldKeys.GetEnumerator(); enu.MoveNext();)
            {
                string pdfKey = enu.Current;

                if (pdfKey.IndexOf("signature") >= 0)
                {
                    signatureFieldName = pdfKey;
                    continue;

                }

                string htmlKey = "@" + pdfKey.Replace("[0]", "")
                    .Replace("topmostSubform.Page1.", "")
                    .Replace("topmostSubform.Page2.", "")
                    .Replace("__", "");


                try
                {

                    if (htmlDoc.GetElementById(htmlKey) == null)
                    {
                        Console.Write("Not writable element - skipping");
                        continue;
                    }
                    string value = htmlDoc.GetElementById(htmlKey).GetAttribute("value");
                    if (htmlKey.Contains('_'))
                    {
                        string IsChecked = htmlDoc.GetElementById(htmlKey).GetAttribute("checked");
                        if (IsChecked.ToLower() == "true")
                            //value = "off";
                            value = "1";
                        else
                            //value = "on";
                            value = "0";
                    }
                    else if (htmlDoc.GetElementById(htmlKey).OuterHtml.ToLower().Contains("checked"))
                        value = "1";

                    fields.SetField(pdfKey, value);
                }
                catch (Exception e) {
                    Console.Write(e.Message);
                }

            }

            string imagePath = htmlDoc.GetElementById("@signature").GetAttribute("value");

            IList<AcroFields.FieldPosition> imageArea = fields.GetFieldPositions(signatureFieldName);

            if (imageArea != null)
            {
                float top = imageArea[0].position.Top;
                float left = imageArea[0].position.Left;
                float height = imageArea[0].position.Height;
                float width = imageArea[0].position.Width;

                iTextSharp.text.Image instanceImage = iTextSharp.text.Image.GetInstance(imagePath);
                PdfContentByte overContent = null;
                if (templateFile.Contains("transportation"))
                    overContent = stamper.GetOverContent(2);
                else
                    overContent = stamper.GetOverContent(1);

                instanceImage.ScaleToFit(width, height);
                instanceImage.SetAbsolutePosition(left, top - height);
                overContent.AddImage(instanceImage);
            }

            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            outFile.Close();
        }

        public static void InsertSignature (string sourceFile, string targetFile, string signatureFile)
        {
            PdfReader reader = new PdfReader(sourceFile);
            FileStream outFile = new FileStream(targetFile, FileMode.Create);
            PdfStamper stamper = new PdfStamper(reader, outFile);

            AcroFields testForm = stamper.AcroFields;

            IList<AcroFields.FieldPosition> imageArea = testForm.GetFieldPositions("@signature");

            float top = imageArea[0].position.Top;
            float left = imageArea[0].position.Left;
            float height = imageArea[0].position.Height;
            float width = imageArea[0].position.Width;

            iTextSharp.text.Image instanceImage = iTextSharp.text.Image.GetInstance(signatureFile);
            PdfContentByte overContent = stamper.GetOverContent(1);
            instanceImage.ScaleToFit(width, height);
            instanceImage.SetAbsolutePosition(left, top - height);
            overContent.AddImage(instanceImage);

            stamper.FormFlattening = true;
            stamper.Close();
            reader.Close();
            outFile.Close();

        }

        public static void TransformHtml(System.Windows.Forms.HtmlDocument Source, string DestinatioFile, Patient patient)
        {

            foreach (System.Windows.Forms.HtmlElement element in Source.Body.All)
            {
                Console.Write (element.GetType().Name);

                string id = element.GetAttribute("id");
                if (id != null && id.StartsWith("@"))
                {
                    Console.WriteLine("id=" + id);
                    if (id == "@date")
                    {
                        element.SetAttribute("value", DateTime.Today.ToShortDateString());
                        continue;
                    }
                    string field = id;
                    string compareTo = null;
                    if (id.Contains("_"))
                    {
                        field = id.Split(new char[] { '_' })[0];
                        compareTo = id.Split(new char[] { '_' })[1];
                    }

                    string propKey = ConfigurationManager.AppSettings[field];

                    if (propKey == null)
                        continue;
                    object oValue = patient.GetType().GetProperty(propKey).GetValue(patient, null);
                    if (oValue == null)
                    {
                        element.SetAttribute("value", "");
                        continue;
                    }
                    string value = oValue.ToString();

                    if (compareTo != null && value.ToLower() == compareTo.ToLower())
                        element.SetAttribute("checked", "true");
                    else
                        element.SetAttribute("value", value);

                }
            }

            StreamWriter sw = new StreamWriter(DestinatioFile);
            sw.Write("<html>" + Source.Body.InnerHtml + "</html>");
            sw.Flush();
            sw.Close();
        }

        private static string EvaluateFormula(string formula)
        {
            string[] temp = formula.Split(new char[]{'='});
            formula = temp[1].Replace("\\", "").Replace("\"", "");
            string[] formulaPieces = formula.Split(new char[] { '(', ')', ',' });

            if (formulaPieces[0] == "checked_if")
            {
                if (formulaPieces[1].ToLower() == formulaPieces[2].ToLower())
                    return "checked";
                else
                    return "";

            }
            else
                return "";
        }

        public static void SetupSigPad(Topaz.SigPlusNET sigPlusNET1, string padImage)
        {
            //Sets up SigPlus for LCD 4X5 tablet
            sigPlusNET1.SetTabletXStart(500);
            sigPlusNET1.SetTabletXStop(2600);
            sigPlusNET1.SetTabletYStart(500);
            sigPlusNET1.SetTabletYStop(2100);
            sigPlusNET1.SetTabletLogicalXSize(2100);
            sigPlusNET1.SetTabletLogicalYSize(1600);

            sigPlusNET1.SetTabletState(1);
            if (!sigPlusNET1.LCDRefresh(0, 0, 0, 320, 240))
                throw new Exception("No Signature pad!");

            sigPlusNET1.ClearTablet(); //clears the SigPlus object

            //adds the hotpots on lcd
            sigPlusNET1.KeyPadAddHotSpot(0, 1, 30, 150, 80, 33);
            sigPlusNET1.KeyPadAddHotSpot(1, 1, 250, 150, 60, 33);

            System.Drawing.Bitmap sig_image = new System.Drawing.Bitmap(padImage);

            sigPlusNET1.SetLCDCaptureMode(2); //Sets up LCD to retain text/graphics/ink
            try
            {
                sigPlusNET1.LCDSendGraphic(1, 2, 0, 0, sig_image);
            }
            catch (Exception ex1)
            {
                throw new Exception("No Signature pad!");
            }

            //bring stored background image to foreground
            if (!sigPlusNET1.LCDRefresh(2, 0, 0, 320, 240))
                throw new Exception("No Signature pad!");

            sigPlusNET1.LCDSetWindow(3, 178, 309, 51); //Permits only the section on lcd to ink
            sigPlusNET1.SetSigWindow(1, 12, 190, 318, 55); //permits ink only in the section specified in sigplus object
            sigPlusNET1.SetLCDCaptureMode(2);

        }

        public static void createPDF(string targetFile, string html)
        {
            FileStream msOutput = new FileStream(targetFile, FileMode.Create);

            //MemoryStream msOutput = new MemoryStream();
            TextReader reader = new StringReader(html);

            // step 1: creation of a document-object
            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 30, 30, 30, 30);

            PdfWriter.GetInstance(document, msOutput);

            document.Open();

            List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(html), null);
            for (int k = 0; k < htmlarraylist.Count; k++)
            {
                IElement e = (IElement)htmlarraylist[k];
                if (e is PdfPTable)
                {
                    PdfPTable t = (PdfPTable)e;

                    foreach (PdfPRow row in t.GetRows(0, t.Rows.Count - 1))
                    {
                        foreach (PdfPCell cell in row.GetCells())
                        {
                            Console.Write(cell.ToString());
                        }
                    }
                }

                document.Add((IElement)htmlarraylist[k]);
            }

            document.Close();


        }
    
    }





}

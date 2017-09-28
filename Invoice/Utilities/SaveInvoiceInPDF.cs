using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using BusinessLayers.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using BusinessLayers.MapperClass;
using System.Threading.Tasks;

namespace InvoiceTow.Utilities
{
    public class SaveInvoiceInPDF
    {
        private IHostingEnvironment _env;
        private IOrderMapper _orderMapper;

        public SaveInvoiceInPDF(IOrderMapper order)
        {
            _orderMapper = order;
        }

        public SaveInvoiceInPDF(IHostingEnvironment env)
        {
            _env = env;
        }


        public async Task InvoicePdf(int id)
        {
            var od = await _orderMapper.BlGetById(id);

            //New Code
            Document doc = new Document(PageSize.A4.Rotate());

            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font f_15_bold = new Font(arial, 15, Font.BOLD);
            Font f_12_normal = new Font(arial, 15, Font.NORMAL);

            Random rnd = new Random();
            int name = rnd.Next(1, 1000);

            var destination = _env.ContentRootPath
            + Path.DirectorySeparatorChar.ToString()
            + "~/PDFFile/";
            //+ Path.DirectorySeparatorChar.ToString()
            //+ "yourfilename.txt";


            //var destination = Server.MapPath("~/PDFFile/");
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            string filePath = string.Format("{0}Order_{1}_{2}_{3}.pdf", destination, od.CustomerId, od.OrderId, DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
            FileStream os = new FileStream(filePath, FileMode.Create);
            using (os)
            {
                PdfWriter.GetInstance(doc, os);
                doc.Open();
                //Information about company
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };

                PdfPCell cel1 = new PdfPCell(new Phrase("\n\nVAMONET SARL", f_15_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("Development Solutions Information", f_15_bold));
                PdfPCell cel3 = new PdfPCell(new Phrase("\n\nInformaton Test", f_15_bold));
                PdfPCell cel4 = new PdfPCell(new Phrase("\nTetouan Maroc \nTelephone Portable : (+469) 6 12 12 12\n telephone Fixe : (+469)5 39 39 99 99", f_12_normal));

                cel1.Border = Rectangle.NO_BORDER;
                cel2.Border = Rectangle.NO_BORDER;
                cel3.Border = Rectangle.NO_BORDER;
                cel4.Border = Rectangle.NO_BORDER;

                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel2.HorizontalAlignment = Element.ALIGN_CENTER;
                cel3.HorizontalAlignment = Element.ALIGN_CENTER;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                table1.WidthPercentage = 40;
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);

                table1.SpacingAfter = 20;
                table1.SpacingBefore = 50;
                doc.Add(table1);

                //client
                table1 = new PdfPTable(1);

                cel1 = new PdfPCell(new Phrase("Customer ID : " + od.CustomerId, f_15_bold));
                cel2 = new PdfPCell(new Phrase("Order Date : " + od.CustomerOrdersVm.Address, f_15_bold));
                cel3 = new PdfPCell(new Phrase("Ship City : " + od.CustomerOrdersVm.City, f_15_bold));

                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = Rectangle.NO_BORDER;
                cel2.Border = Rectangle.NO_BORDER;
                cel3.Border = Rectangle.NO_BORDER;

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);

                table1.SpacingAfter = 20;
                table1.SpacingBefore = 10;

                //position Client Box
                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                table2.WidthPercentage = 40;
                doc.Add(table2);


                //Date , Echeance + product
                //todo här
                Paragraph paragraph = new Paragraph(new Phrase("Date : " + DateTime.Now + "\n", f_12_normal));
                paragraph.Add(new Phrase("Echance : " + DateTime.Now + "\n\n", f_12_normal));
                paragraph.Add(new Phrase("Facture N : " + "Input Text här " + "\n\n", f_15_bold));
                paragraph.Alignment = Element.ALIGN_JUSTIFIED;
                doc.Add(paragraph);

                //List of the products
                table1 = new PdfPTable(5);
                decimal ht = 0, tva = 0, ttc = 0;
                //Copier I'entete de la dategridview 
                //for (int j = 0; j < 5; j++)
                //{
                //    cel1 = new PdfPCell(new Phrase(radGridView1.Columns[j].HeaderText));
                //    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                //    cel1.FixedHeight = 20;
                //    table1.AddCell(cel1);
                //}

                ////copie le Contenu du tableau (Grid view)
                //for (int i = 0; i < redGridView1.ChildRows.Count; i++)
                //{
                //    for (int j = 0; j < 5; j++)
                //    {
                //        cel1 = new PdfPCell(new Phrase(radGridView1.Rows[i].Value as string));
                //        cel1.FixedHeight = 20;
                //        table1.AddCell(cel1);
                //    }
                //    ht += decimal.Parse(radGridView1.Rows[i].Cells[4].Value as string);
                //}

                tva = (ht * 20) / (100);
                ttc = ht + tva;

                table1.WidthPercentage = 100;
                width = new float[] { 100f, 450f, 100f, 100, 100 };
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);

                //The Total 
                table1 = new PdfPTable(2);
                cel1 = new PdfPCell(new Phrase("Total HT"));
                cel2 = new PdfPCell(new Phrase(ht.ToString()));
                cel3 = new PdfPCell(new Phrase("TVA"));
                cel4 = new PdfPCell(new Phrase(tva.ToString()));
                PdfPCell cel5 = new PdfPCell(new Phrase("Total a Paye"));
                PdfPCell cel6 = new PdfPCell(new Phrase(ttc.ToString()));

                table1.WidthPercentage = 100;
                width = new float[] { 165, 50 };
                cel1.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel1.FixedHeight = 20;

                cel3.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel3.FixedHeight = 20;
                cel5.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel5.FixedHeight = 20;

                cel2.HorizontalAlignment = Element.ALIGN_CENTER;
                cel4.HorizontalAlignment = Element.ALIGN_CENTER;
                cel6.HorizontalAlignment = Element.ALIGN_CENTER;

                table1.SetWidths(width);
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);
                table1.AddCell(cel5);
                table1.AddCell(cel6);
                doc.Add(table1);

                doc.Close();

                //Open document
                Process.Start(filePath);
            }

            //End New Code
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using ClosedXML.Excel;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library_Librarian_UploadBookData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filePath = Server.MapPath("~/Library/Uploads/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(filePath);

            DataTable dtExcelData = new DataTable();
            dtExcelData.Columns.AddRange(new DataColumn[8] {
                    new DataColumn("BookNo", typeof(string)),
                    new DataColumn("BookName", typeof(string)),
                    new DataColumn("Author", typeof(string)),
                    new DataColumn("Detail", typeof(string)),
                    new DataColumn("Publication", typeof(string)),
                    new DataColumn("PubDate", typeof(DateTime)),
                    new DataColumn("Price", typeof(double)),
                    new DataColumn("ImagePath", typeof(string))
                });

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                bool firstRow = true;

                foreach (var row in worksheet.Rows())
                {
                    if (firstRow)
                    {
                        firstRow = false;
                        continue;
                    }

                    string bookNo = row.Cell(1).Value.ToString();
                    string bookName = row.Cell(2).Value.ToString();
                    string author = row.Cell(3).Value.ToString();
                    string detail = row.Cell(4).Value.ToString();
                    string publication = row.Cell(5).Value.ToString();
                    string pubDateString = row.Cell(6).Value.ToString();
                    string priceString = row.Cell(7).Value.ToString();
                    string imagePath = row.Cell(8).Value.ToString();

                    DateTime pubDate;
                    double price;

                    if (!DateTime.TryParse(pubDateString, out pubDate))
                    {
                        // Handle invalid date, e.g., set a default date or continue to the next row
                        pubDate = DateTime.MinValue;
                    }

                    if (!double.TryParse(priceString, out price))
                    {
                        // Handle invalid price, e.g., set a default price or continue to the next row
                        price = 0.0;
                    }

                    dtExcelData.Rows.Add(bookNo, bookName, author, detail, publication, pubDate, price, imagePath);
                }
            }

            string consString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    sqlBulkCopy.DestinationTableName = "dbo.Book";

                    sqlBulkCopy.ColumnMappings.Add("BookNo", "BookNo");
                    sqlBulkCopy.ColumnMappings.Add("BookName", "BookName");
                    sqlBulkCopy.ColumnMappings.Add("Author", "Author");
                    sqlBulkCopy.ColumnMappings.Add("Detail", "Detail");
                    sqlBulkCopy.ColumnMappings.Add("Publication", "Publication");
                    sqlBulkCopy.ColumnMappings.Add("PubDate", "PubDate");
                    sqlBulkCopy.ColumnMappings.Add("Price", "Price");
                    sqlBulkCopy.ColumnMappings.Add("ImagePath", "ImagePath");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dtExcelData);
                    lblmsg.Text = "Book Added Successfully !!";
                    con.Close();
                }
            }
        }
    }
}
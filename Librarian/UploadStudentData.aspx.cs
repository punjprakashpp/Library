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

public partial class Library_Librarian_UploadStudentData : System.Web.UI.Page
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
            dtExcelData.Columns.AddRange(new DataColumn[13] {
                    new DataColumn("Session", typeof(string)),
                    new DataColumn("Roll", typeof(string)),
                    new DataColumn("Name", typeof(string)),
                    new DataColumn("Mobile", typeof(string)),
                    new DataColumn("Address", typeof(string)),
                    new DataColumn("City", typeof(string)),
                    new DataColumn("Pincode", typeof(string)),
                    new DataColumn("DOB", typeof(DateTime)),
                    new DataColumn("Gender", typeof(string)),
                    new DataColumn("Email", typeof(string)),
                    new DataColumn("Password", typeof(string)),
                    new DataColumn("ImagePath", typeof(string)),
                    new DataColumn("EntryDate", typeof(DateTime))
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

                    string session = row.Cell(1).Value.ToString();
                    string roll = row.Cell(2).Value.ToString();
                    string name = row.Cell(3).Value.ToString();
                    string mobile = row.Cell(4).Value.ToString();
                    string address = row.Cell(5).Value.ToString();
                    string city = row.Cell(6).Value.ToString();
                    string pincode = row.Cell(7).Value.ToString();
                    string dobString = row.Cell(8).Value.ToString();
                    string gender = row.Cell(9).Value.ToString();
                    string email = row.Cell(10).Value.ToString();
                    string password = row.Cell(11).Value.ToString();
                    string imagePath = row.Cell(12).Value.ToString();
                    string entryDateString = row.Cell(13).Value.ToString();

                    DateTime dob;
                    DateTime entryDate;

                    if (!DateTime.TryParse(dobString, out dob))
                    {
                        dob = DateTime.MinValue;
                    }

                    if (!DateTime.TryParse(entryDateString, out entryDate))
                    {
                        entryDate = DateTime.MinValue;
                    }

                    dtExcelData.Rows.Add(session, roll, name, mobile, address, city, pincode, dob, gender, email, password, imagePath, entryDate);
                }
            }

            string consString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    sqlBulkCopy.DestinationTableName = "dbo.Student";

                    sqlBulkCopy.ColumnMappings.Add("Session", "Session");
                    sqlBulkCopy.ColumnMappings.Add("Roll", "Roll");
                    sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                    sqlBulkCopy.ColumnMappings.Add("Mobile", "Mobile");
                    sqlBulkCopy.ColumnMappings.Add("Address", "Address");
                    sqlBulkCopy.ColumnMappings.Add("City", "City");
                    sqlBulkCopy.ColumnMappings.Add("Pincode", "Pincode");
                    sqlBulkCopy.ColumnMappings.Add("DOB", "DOB");
                    sqlBulkCopy.ColumnMappings.Add("Gender", "Gender");
                    sqlBulkCopy.ColumnMappings.Add("Email", "Email");
                    sqlBulkCopy.ColumnMappings.Add("Password", "Password");
                    sqlBulkCopy.ColumnMappings.Add("ImagePath", "ImagePath");
                    sqlBulkCopy.ColumnMappings.Add("EntryDate", "EntryDate");

                    con.Open();
                    sqlBulkCopy.WriteToServer(dtExcelData);
                    lblmsg.Text = "Student Data Added Successfully !!";
                    con.Close();
                }
            }
        }
    }
}

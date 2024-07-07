﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Addbook : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!Page.IsPostBack)
        {
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filePath = Server.MapPath("~/img/book/") + FileUpload1.FileName;
            FileUpload1.SaveAs(filePath);
            string imagePath = "~/img/book/" + FileUpload1.FileName;

            string query = "INSERT INTO Book (BookNo, BookName, Author, Detail, Publication, PubDate, Price, ImagePath) " +
                           "VALUES (@BookNo, @BookName, @Author, @Detail, @Publication, @PubDate, @Price, @ImagePath)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@BookNo", txtBookNo.Text);
                cmd.Parameters.AddWithValue("@BookName", txtBookName.Text);
                cmd.Parameters.AddWithValue("@Author", txtauthor.Text);
                cmd.Parameters.AddWithValue("@Detail", txtdetail.Text);
                cmd.Parameters.AddWithValue("@Publication", txtPublication.Text);
                cmd.Parameters.AddWithValue("@PubDate", txtPubDate.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(txtprice.Text));
                cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                connection.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Book Added Successfully !!";
                ClearFields();
            }
        }
        else
        {
            lblmsg.Text = "Please, Select Book Photo First !!";
        }
    }

    private void ClearFields()
    {
        txtBookNo.Text = "";
        txtBookName.Text = "";
        txtauthor.Text = "";
        txtdetail.Text = "";
        txtPublication.Text = "";
        txtPubDate.Text = "";
        txtprice.Text = "";
        txtBookNo.Focus();
    }
}

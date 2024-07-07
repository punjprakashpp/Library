using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bookreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        lblmsg0.Text = "";

        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = -1;
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        if (rdBookNo.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtBookNo.Text))
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblmsg.Text = "Enter Book No. !!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                LoadBooksByBookNo(txtBookNo.Text);
            }
        }
        else if (rdBookName.Checked)
        {
            if (string.IsNullOrWhiteSpace(txtBookName.Text))
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                lblmsg.Text = "Enter Book Name !!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                MultiView1.ActiveViewIndex = -1;
            }
            else
            {
                LoadBooksByName(txtBookName.Text);
            }
        }
        else
        {
            lblmsg.Text = "Select an option to view books.";
            lblmsg.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void LoadBooksByBookNo(string BookNo)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT BID, BookNo, BookName, Author, Publication, Price FROM Book WHERE BookNo LIKE @BookNo";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BookNo", "%" + BookNo + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                lblmsg0.Text = GridView1.Rows.Count.ToString() + " - Records Found.";
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
            }
        }
    }

    private void LoadBooksByName(string bookName)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT BID, BookNo, bookname, Author, Publication, Price FROM Book WHERE bookname LIKE @bookname";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@bookname", "%" + bookName + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                GridView1.DataSource = reader;
                GridView1.DataBind();
                lblmsg0.Text = GridView1.Rows.Count.ToString() + " - Records Found.";
                MultiView1.ActiveViewIndex = 0;
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            int bookId = Convert.ToInt32(e.CommandArgument);
            LoadBookDetails(bookId);
        }
    }

    private void LoadBookDetails(int bookId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT BID, BookNo, BookName, Author, Publication, Price, Detail, ImagePath FROM Book WHERE BID = @BID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BID", bookId);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblBookNo.Text = reader["BookNo"].ToString();
                    lblBookName.Text = reader["BookName"].ToString();
                    lblauthor.Text = reader["Author"].ToString();
                    lblpub.Text = reader["Publication"].ToString();
                    lblprice.Text = reader["Price"].ToString();
                    lbldetail.Text = reader["Detail"].ToString();
                    Image2.ImageUrl = reader["ImagePath"].ToString();
                }
                MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
            }
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
}

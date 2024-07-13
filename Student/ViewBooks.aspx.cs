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
        if (!rdBookNo.Checked && !rdBookName.Checked && !rdAuthor.Checked && !rdPublication.Checked)
        {
            lblmsg.Text = "Select an option to view books.";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblmsg.Text = "Enter Search Text. !!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            MultiView1.ActiveViewIndex = -1;
            return;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        string query = GetQuery();
        if (query == string.Empty)
        {
            lblmsg.Text = "Invalid Search Option.";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@SearchText", "%" + txtSearch.Text.Trim() + "%");

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    lblmsg0.Text = GridView1.Rows.Count.ToString() + " - Records Found."; 
                    MultiView1.ActiveViewIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
            }
        }
    }

    private string GetQuery()
    {
        if (rdBookNo.Checked)
            return "SELECT BID, BookNo, BookName, Author, Publication, Price FROM Book WHERE BookNo LIKE @SearchText";
        if (rdBookName.Checked)
            return "SELECT BID, BookNo, BookName, Author, Publication, Price FROM Book WHERE BookName LIKE @SearchText";
        if (rdAuthor.Checked)
            return "SELECT BID, BookNo, BookName, Author, Publication, Price FROM Book WHERE Author LIKE @SearchText";
        if (rdPublication.Checked)
            return "SELECT BID, BookNo, BookName, Author, Publication, Price FROM Book WHERE Publication LIKE @SearchText";

        return string.Empty;
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
        string query = "SELECT BID, BookNo, BookName, Author, Publication, Price, Detail, ImagePath FROM Book WHERE BID = @BID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@BID", bookId);

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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

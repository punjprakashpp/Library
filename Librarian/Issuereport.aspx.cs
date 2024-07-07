using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Issuereport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = "";
        if (!Page.IsPostBack)
        {
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lbl.Text = "";
        if (string.IsNullOrWhiteSpace(txtRoll.Text))
        {
            lbl.Text = "Enter Roll Number First !!";
        }
        else
        {
            LoadIssuedBooks(txtRoll.Text.Trim());
        }
    }

    private void LoadIssuedBooks(string rollNumber)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT b.BookNo, b.BookName, r.IssueDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE s.Roll = @rollNumber AND r.Status != 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@rollNumber", rollNumber);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                lbl.Text = "Total Records = " + dataTable.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                lbl.Text = "Error: " + ex.Message;
            }
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Issuereport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!Page.IsPostBack)
        {
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (string.IsNullOrWhiteSpace(txtsearch.Text))
        {
            lblmsg.Text = "Enter Search Text. !!";
        }
        else
        {
            LoadIssuedBooks(txtsearch.Text.Trim());
        }
    }

    private void LoadIssuedBooks(string rollNumber)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = GetQuery();
            if (query == string.Empty)
            {
                lblmsg.Text = "Invalid Search Option.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SearchText", "%" + txtsearch.Text.Trim() + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                lblmsg.Text = "Total Records = " + dataTable.Rows.Count.ToString();
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
            return @"
                SELECT s.Roll, s.Name, b.BookNo, b.BookName, r.IssueDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE b.BookNo LIKE @SearchText AND r.Status != 0";
        if (rdBookName.Checked)
            return @"
                SELECT s.Roll, s.Name, b.BookNo, b.BookName, r.IssueDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE b.BookName LIKE @SearchText AND r.Status != 0"; ;
        if (rdRoll.Checked)
            return @"
                SELECT s.Roll, s.Name, b.BookNo, b.BookName, r.IssueDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE s.Roll LIKE @SearchText AND r.Status != 0";
        if (rdName.Checked)
            return @"
                SELECT s.Roll, s.Name, b.BookNo, b.BookName, r.IssueDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE s.Name LIKE @SearchText AND r.Status != 0";

        return string.Empty;
    }
}

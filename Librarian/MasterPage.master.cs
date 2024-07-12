using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Redirect to default page if session variable "aid" is not set
        if (Session["aid"] == null)
        {
            Response.Redirect("../Default.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            return;
        }

        if (!IsPostBack)
        {
            // Display user name or "Guest" if Session["name"] is null
            lblname.Text = Session["name"] != null ? Session["name"].ToString() : "Guest";

            // Call the function to insert penalties if not already inserted
            InsertPenaltyIfNotExists();

            // Call the function to insert dummy data into Rent table
            InsertDummyDataIntoRentTable();
        }
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        // Clear session variables and redirect to default page
        Session.Clear();
        Response.Redirect("../Default.aspx", false);
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    // Function to insert penalty records if they don't already exist
    private void InsertPenaltyIfNotExists()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
            INSERT INTO Penalty (SID, RID, BID, BookNo, BookName, Price, Penalty, Amount, Detail, EntryDate)
            SELECT r.SID, r.RID, r.BID, b.BookNo, b.BookName, b.Price, 1, @Amount, 'Return Date Passed', GETDATE()
            FROM Rent r
            INNER JOIN Book b ON r.BID = b.BID
            LEFT JOIN Penalty p ON r.SID = p.SID AND r.BID = p.BID
            WHERE r.Status = 1
            AND DATEDIFF(day, r.ReturnDate, GETDATE()) > 0 
            AND p.PID IS NULL"; // Ensures no duplicate penalty records are inserted

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Amount", Convert.ToDouble(100.00));
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Optional: Log or display a message indicating how many penalties were inserted
                    // lblmsg.Text = $"{rowsAffected} new penalty record(s) inserted.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                // You might want to log the exception or display an error message
                // lblmsg.Text = "Error occurred while inserting penalties: " + ex.Message;
            }
        }
    }

    // Function to insert dummy data into Rent table
    private void InsertDummyDataIntoRentTable()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
            INSERT INTO Rent (SID, BID, IssueDate, ReturnDate, Status)
            SELECT 0 AS SID, BID, @IssueDate AS IssueDate, @ReturnDate AS ReturnDate, 0 AS Status
            FROM Book
            WHERE BID NOT IN (SELECT BID FROM Rent)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssueDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReturnDate", DateTime.Now.AddMonths(1));
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Optional: Log or display a message indicating how many dummy records were inserted
                    // lblmsg.Text = $"{rowsAffected} new dummy record(s) inserted into Rent table.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                // You might want to log the exception or display an error message
                // lblmsg.Text = "Error occurred while inserting dummy data: " + ex.Message;
            }
        }
    }
}

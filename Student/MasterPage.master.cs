using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            // Call the function to insert penalties if not already inserted
            InsertPenaltyIfNotExists();
        }

        if (Session["sid"] == null)
        {
            Response.Redirect("../Default.aspx");
        }
        else
        {
            int sid = Convert.ToInt32(Session["sid"]);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            string query = "SELECT * FROM Student WHERE SID = @SID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SID", sid);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string imagePath = reader["ImagePath"].ToString();
                            string studentName = reader["Name"].ToString();
                            Image2.ImageUrl = imagePath;
                            lblname.Text = studentName;
                        }
                    }
                }
            }
        }
    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        // Add your button click logic here
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session["sid"] = null;
        Response.Redirect("../Default.aspx");
    }

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
}

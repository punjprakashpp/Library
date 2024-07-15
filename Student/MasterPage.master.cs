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
            UPDATE Rent
            SET Penalty = 1, Amount = @Amount, Detail = 'Return Date Passed', EntryDate = GETDATE()
            WHERE Status = 1
            AND DATEDIFF(day, ReturnDate, GETDATE()) > 0 
            AND Penalty = 0"; // Ensures no duplicate penalty records are inserted

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Amount", Convert.ToDouble(100.00));
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Optional: Log or display a message indicating how many penalties were updated
                    // lblmsg.Text = $"{rowsAffected} penalty record(s) updated.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                // You might want to log the exception or display an error message
                // lblmsg.Text = "Error occurred while updating penalties: " + ex.Message;
            }
        }
    }
}

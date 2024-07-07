using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Penalty : System.Web.UI.Page
{
    // Class-level variables to store SID, PID, and RID
    private int sid
    {
        get
        {
            return ViewState["sid"] != null ? (int)ViewState["sid"] : -1;
        }
        set
        {
            ViewState["sid"] = value;
        }
    }

    private int pid
    {
        get
        {
            return ViewState["pid"] != null ? (int)ViewState["pid"] : -1;
        }
        set
        {
            ViewState["pid"] = value;
        }
    }

    private int rid
    {
        get
        {
            return ViewState["rid"] != null ? (int)ViewState["rid"] : -1;
        }
        set
        {
            ViewState["rid"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Optionally reset form or perform other initialization
        }
    }

    protected void btnFetchIssueBook_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(txtRoll.Text))
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SID, Name FROM Student WHERE Roll = @Roll";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Roll", txtRoll.Text);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Store the SID in the class-level variable
                        sid = reader.GetInt32(reader.GetOrdinal("SID"));
                        lblmsg.Text = "";
                        LoadBooks(sid);
                    }
                    else
                    {
                        lblmsg.Text = "Student not found.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error: " + ex.Message;
                }
            }
        }
        else
        {
            ResetForm();
        }
    }

    private void LoadBooks(int studentId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT PID, RID, BookNo, BookName 
                FROM Penalty 
                WHERE SID = @SID AND Penalty = 1";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SID", studentId);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Clear existing items first
            drpbook.Items.Clear();
            drpbook.Items.Insert(0, new ListItem("SELECT", "0"));

            while (reader.Read())
            {
                pid = reader.GetInt32(reader.GetOrdinal("PID"));
                rid = reader.GetInt32(reader.GetOrdinal("RID"));
                string bookNo = reader.GetString(reader.GetOrdinal("BookNo"));

                // Add each book to the dropdown list
                drpbook.Items.Add(new ListItem(bookNo, pid.ToString()));
            }
        }
    }

    protected void btnSelectBook_Click(object sender, EventArgs e)
    {
        if (drpbook.SelectedIndex == 0)
        {
            lblmsg.Text = "Select Book !!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            MultiView1.ActiveViewIndex = -1;
        }
        else
        {
            DisplayBookDetails(Convert.ToInt32(drpbook.SelectedValue)); // Display details for the selected penalty's PID
        }
    }

    private void DisplayBookDetails(int penaltyId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT b.BookNo, b.BookName, b.Author, b.Publication, b.Price, b.ImagePath,
                       s.Roll, s.Name, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days, r.IssueDate 
                FROM Penalty p
                INNER JOIN Rent r ON p.RID = r.RID
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE p.PID = @PID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PID", penaltyId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MultiView1.ActiveViewIndex = 0;
                    lblBookNo.Text = reader["BookNo"].ToString();
                    lblBookName.Text = reader["BookName"].ToString();
                    lblauthor.Text = reader["Author"].ToString();
                    lblpub.Text = reader["Publication"].ToString();
                    lblprice.Text = reader["Price"].ToString();
                    Image2.ImageUrl = reader["ImagePath"].ToString();
                    lblRoll.Text = reader["Roll"].ToString();
                    lblstudent.Text = reader["Name"].ToString();
                    lbldays.Text = reader["Days"].ToString();
                    lblidate.Text = Convert.ToDateTime(reader["IssueDate"]).ToString("dd-MM-yyyy");

                    int daysAllowed = Convert.ToInt32(reader["Days"]);
                    DateTime issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    DateTime currentDate = DateTime.Now;
                    int daysPassed = (currentDate - issueDate).Days;

                    lblpanalty.Text = daysPassed > daysAllowed ? "Yes" : "No";
                }
                else
                {
                    lblmsg.Text = "Book details not found for the selected penalty.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error retrieving book details: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnpaypenalty_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtpenalty.Text))
        {
            lblpay.Text = "Enter amount !!";
            lblpay.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (string.IsNullOrEmpty(txtdetail.Text))
        {
            lblpay.Text = "Enter detail !!";
            lblpay.ForeColor = System.Drawing.Color.Red;
            return;
        }

        PayPenalty(Convert.ToInt32(drpbook.SelectedValue), Convert.ToDouble(txtpenalty.Text), txtdetail.Text);
    }

    private void PayPenalty(int penaltyId, double amount, string detail)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string updatePenaltyQuery = @"
                UPDATE Penalty 
                SET Penalty = 0, Price = @Amount, Detail = @Detail 
                WHERE PID = @PID";

            string updateRentQuery = @"
                UPDATE Rent 
                SET Status = 0 
                WHERE RID = @RID";

            SqlCommand updatePenaltyCommand = new SqlCommand(updatePenaltyQuery, connection);
            updatePenaltyCommand.Parameters.AddWithValue("@Amount", amount);
            updatePenaltyCommand.Parameters.AddWithValue("@Detail", detail);
            updatePenaltyCommand.Parameters.AddWithValue("@PID", penaltyId);

            SqlCommand updateRentCommand = new SqlCommand(updateRentQuery, connection);
            updateRentCommand.Parameters.AddWithValue("@RID", rid); // Use rid for Rent ID

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                updatePenaltyCommand.Transaction = transaction;
                updateRentCommand.Transaction = transaction;

                updatePenaltyCommand.ExecuteNonQuery();
                updateRentCommand.ExecuteNonQuery();

                transaction.Commit();

                lblmsg.Text = "Amount paid successfully !!";
                lblmsg.ForeColor = System.Drawing.Color.Green;
                ResetForm();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                lblmsg.Text = "Error occurred while processing the payment: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    private void ResetForm()
    {
        sid = -1; // Reset sid
        pid = -1; // Reset pid
        rid = -1; // Reset rid
        txtdetail.Text = "";
        txtpenalty.Text = "";
        MultiView1.ActiveViewIndex = -1;
        drpbook.Items.Clear();
        drpbook.Items.Insert(0, new ListItem("SELECT", "0"));
    }
}

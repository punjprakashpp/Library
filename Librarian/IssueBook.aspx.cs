using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class BookIssue : System.Web.UI.Page
{
    // Class-level variables to store SID & BID
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

    private int bid
    {
        get
        {
            return ViewState["bid"] != null ? (int)ViewState["bid"] : -1;
        }
        set
        {
            ViewState["bid"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize sid & bid
            sid = -1;
            bid = -1;
        }
    }

    protected void btnFetchBook_Click(object sender, EventArgs e)
    {
        string bookNo = txtBookNo.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT BID, BookNo, BookName, Author, Publication FROM Book WHERE BookNo = @BookNo";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@BookNo", bookNo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Store the BID in the class-level variables
                        bid = reader.GetInt32(reader.GetOrdinal("BID"));
                        txtBookName.Text = reader.GetString(reader.GetOrdinal("BookName"));
                        txtAuthor.Text = reader.GetString(reader.GetOrdinal("Author"));
                        txtPublication.Text = reader.GetString(reader.GetOrdinal("Publication"));
                        lblMessage.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Book not found.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }

    protected void btnFetchStudent_Click(object sender, EventArgs e)
    {
        string rollNo = txtRollNo.Text;

        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT SID, Session, Roll, Name FROM Student WHERE Roll = @Roll";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Roll", rollNo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Store the SID in the class-level variable
                        sid = reader.GetInt32(reader.GetOrdinal("SID"));
                        txtStudentName.Text = reader.GetString(reader.GetOrdinal("Name"));
                        txtSession.Text = reader.GetString(reader.GetOrdinal("Session"));
                        lblMessage.Text = "";
                    }
                    else
                    {
                        lblMessage.Text = "Student not found.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }

    protected void btnIssueBook_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (sid != -1) // Check if BID is valid
            {
                if (bid != -1) // Check if SID is valid
                {
                    DateTime issueDate;
                    DateTime returnDate;

                    if (DateTime.TryParseExact(txtIssueDate.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out issueDate) &&
                        DateTime.TryParseExact(txtReturnDate.Text, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out returnDate))
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string checkStatusQuery = "SELECT Status FROM Rent WHERE BID = @BID";

                            using (SqlCommand checkStatusCmd = new SqlCommand(checkStatusQuery, connection))
                            {
                                checkStatusCmd.Parameters.AddWithValue("@BID", bid);

                                try
                                {
                                    connection.Open();
                                    int status = (int)checkStatusCmd.ExecuteScalar();
                                    if (status == 1)
                                    {
                                        lblMessage.Text = "Book is already issued to someone.";
                                        lblMessage.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        string updateQuery = "UPDATE Rent SET SID = @SID, IssueDate = @IssueDate, ReturnDate = @ReturnDate, Status = @Status WHERE BID = @BID";

                                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                                        {
                                            cmd.Parameters.AddWithValue("@BID", bid); // Use the stored BID
                                            cmd.Parameters.AddWithValue("@SID", sid); // Use the stored SID
                                            cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                                            cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                                            cmd.Parameters.AddWithValue("@Status", 1); // Assuming 1 indicates book issued

                                            try
                                            {
                                                cmd.ExecuteNonQuery();
                                                lblMessage.Text = "Book issued successfully.";
                                                lblMessage.ForeColor = System.Drawing.Color.Green;

                                                // Clear form fields
                                                txtRollNo.Text = "";
                                                txtStudentName.Text = "";
                                                txtBookNo.Text = "";
                                                txtBookName.Text = "";
                                                txtIssueDate.Text = "";
                                                txtReturnDate.Text = "";

                                                // Reset the SID, BID, and BookNo after issuing the book
                                                sid = -1;
                                                bid = -1;
                                            }
                                            catch (Exception ex)
                                            {
                                                lblMessage.Text = "Error: " + ex.Message;
                                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    lblMessage.Text = "Error: " + ex.Message;
                                    lblMessage.ForeColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid date format. Please use dd-MM-yyyy.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = "Please fetch book details first."; 
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please fetch student details first.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

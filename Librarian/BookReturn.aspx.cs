using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class BookReturn : System.Web.UI.Page
{
    // Class-level variable to store the SID
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = -1;
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
                        LoadBooksByStudent(sid);
                    }
                    else
                    {
                        lblmsg.Text = "Student not found.";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        ClearBookDetails();
                    }

                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error: " + ex.Message;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    ClearBookDetails();
                }
            }
        }
        else
        {
            ClearBookDetails();
        }
    }

    private void LoadBooksByStudent(int studentId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT RID, BookNo, Bookname FROM Rent WHERE SID = @studentId AND Status = 1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) // Check if there are any rows before binding
                {
                    drpbook.DataSource = reader;
                    drpbook.DataTextField = "BookNo";
                    drpbook.DataValueField = "RID";
                    drpbook.DataBind();
                }
                else
                {
                    lblmsg.Text = "No books found for this student.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    ClearBookDetails();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                ClearBookDetails();
            }
            finally
            {
                drpbook.Items.Insert(0, new ListItem("SELECT", "0"));
            }
        }
    }

    protected void btnSelectBook_Click(object sender, EventArgs e)
    {
        if (drpbook.SelectedIndex > 0)
        {
            ShowBookDetails(sid, drpbook.SelectedItem.Text);
        }
        else
        {
            lblmsg.Text = "Select a book!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            ClearBookDetails();
        }
    }

    private void ShowBookDetails(int studentId, string BookNo)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT b.BID, b.BookNo, b.Bookname, b.author, b.publication, b.price, b.ImagePath, " +
               "r.IssueDate, DATEDIFF(day, r.IssueDate, ReturnDate) AS Days, " +
               "s.Name AS StudentName " +
               "FROM Book b " +
               "INNER JOIN Rent r ON b.BID = r.Bid " +
               "INNER JOIN Student s ON r.sid = s.sid " +
               "WHERE r.sid = @studentId AND b.BookNo = @BookNo AND r.Status = 1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@BookNo", BookNo);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblbname.Text = reader["Bookname"].ToString();
                    lblauthor.Text = reader["author"].ToString();
                    lblpub.Text = reader["publication"].ToString();
                    lblprice.Text = reader["price"].ToString();
                    lblstudent.Text = reader["StudentName"].ToString();
                    lbldays.Text = reader["Days"].ToString();
                    lblidate.Text = reader["IssueDate"].ToString();
                    Image2.ImageUrl = reader["ImagePath"].ToString();

                    // Determine penalty status
                    int days = Convert.ToInt32(reader["Days"]);
                    DateTime issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    int penaltyDays = (DateTime.Now - issueDate).Days;
                    lblpanalty.Text = (penaltyDays > days) ? "Yes" : "No";

                    MultiView1.ActiveViewIndex = 0;
                }
                else
                {
                    lblmsg.Text = "Book details not found!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    ClearBookDetails();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                ClearBookDetails();
            }
        }
    }

    protected void btnreturnbook_Click(object sender, EventArgs e)
    {
        if (lblpanalty.Text == "Yes")
        {
            lblbook.Text = "Please pay the penalty before returning the book!";
            lblbook.ForeColor = System.Drawing.Color.Red;
            ClearBookDetails();
            // Your logic to handle penalty payment
        }
        else
        {
            // Update the status of the book to indicate it has been returned and delete the record from Rent table
            int studentId = sid;
            int rentId = Convert.ToInt32(drpbook.SelectedValue);

            string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Rent SET Status = 0 WHERE RID = @rentId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@rentId", rentId);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        lblbook.Text = "Book returned successfully!";
                        lblbook.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblbook.Text = "Failed to return book!";
                        lblbook.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblbook.Text = "Error: " + ex.Message;
                    lblbook.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    ClearBookDetails();
                }
            }
        }
    }

    private void ClearBookDetails()
    {
        lblbname.Text = "";
        lblauthor.Text = "";
        lblpub.Text = "";
        lblprice.Text = "";
        lbldays.Text = "";
        lblidate.Text = "";
        Image2.ImageUrl = "";
        lblpanalty.Text = "";
        MultiView1.ActiveViewIndex = -1;
        lblbook.Text = "";
    }
}

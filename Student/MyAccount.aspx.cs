using System;
using System.Data.SqlClient;

public partial class Student_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "";
        MultiView1.ActiveViewIndex = 0;

        // Retrieve student data from the database
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
                        // Populate labels with student data
                        lblnam.Text = reader["Name"].ToString();
                        lblmobile.Text = reader["Mobile"].ToString();
                        lbladd.Text = reader["Address"].ToString();
                        lblcity.Text = reader["City"].ToString();
                        lblpincode.Text = reader["Pincode"].ToString();
                        lblemail.Text = reader["Email"].ToString();
                    }
                }
            }
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        // Switch to view 0
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button13_Click(object sender, EventArgs e)
    {
        // Switch to view 1
        MultiView1.ActiveViewIndex = 1;

        // Retrieve and populate text boxes with student data
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
                        txtname.Text = reader["Name"].ToString();
                        txtname0.Text = reader["Mobile"].ToString();
                        txtname1.Text = reader["Address"].ToString();
                        txtname2.Text = reader["City"].ToString();
                        txtname3.Text = reader["Pincode"].ToString();
                        txtname4.Text = reader["Email"].ToString();
                    }
                }
            }
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        // Update student data in the database
        int sid = Convert.ToInt32(Session["sid"]);
        string name = txtname.Text.Trim();
        string mobile = txtname0.Text.Trim();
        string address = txtname1.Text.Trim();
        string city = txtname2.Text.Trim();
        string pincode = txtname3.Text.Trim();
        string email = txtname4.Text.Trim();

        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        string query = "UPDATE Student SET Name = @Name, Mobile = @Mobile, Address = @Address, City = @City, Pincode = @Pincode, Email = @Email WHERE SID = @SID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SID", sid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Pincode", pincode);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Switch back to view 0
        MultiView1.ActiveViewIndex = 0;
    }

    protected void Button14_Click(object sender, EventArgs e)
    {
        // Switch to view 2
        MultiView1.ActiveViewIndex = 2;
    }

    protected void Button15_Click(object sender, EventArgs e)
    {
        if (txtpass.Text == "")
        {
            Label1.Text = "Enter Password";
        }
        else if (txtpass.Text != txtcpass.Text)
        {
            Label1.Text = "Password not same !!";
        }
        else
        {
            // Change password for the student
            int sid = Convert.ToInt32(Session["sid"]);
            string password = txtpass.Text.Trim();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            string query = "UPDATE Student SET Password = @Password WHERE SID = @SID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SID", sid);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Label1.Text = "Password has been changed !!";
        }

        // Switch to view 2
        MultiView1.ActiveViewIndex = 2;
    }
}

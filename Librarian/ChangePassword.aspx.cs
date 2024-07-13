using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

public partial class Library_Librarian_Change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (Session["email"] == null)
            {
                lblMessage.Text = "Session expired. Please log in again.";
                return;
            }

            string userName = Session["email"].ToString();
            string oldPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;

            if (ValidateCurrentPassword(userName, oldPassword))
            {
                if (UpdatePassword(userName, newPassword))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Password changed successfully!";
                }
                else
                {
                    lblMessage.Text = "An error occurred while updating the password.";
                }
            }
            else
            {
                lblMessage.Text = "Current password is incorrect.";
            }
        }
    }

    private bool ValidateCurrentPassword(string userName, string password)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Admin WHERE UserName = @UserName AND Password = @Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@Password", password);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            return reader.Read();
        }
    }

    private bool UpdatePassword(string userName, string newPassword)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string sql = "UPDATE Admin SET Password = @Password WHERE UserName = @UserName";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Password", newPassword);
            cmd.Parameters.AddWithValue("@UserName", userName);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}

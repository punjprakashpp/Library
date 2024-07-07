using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl.Text = "";
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            if (rdolibrary.Checked == true)
            {
                string query = "SELECT AID, Name FROM Admin WHERE UserName = @UserName AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", txtuname.Text);
                    cmd.Parameters.AddWithValue("@Password", txtupass.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session["aid"] = reader["AID"].ToString();
                            Session["email"] = txtuname.Text;
                            Session["name"] = reader["Name"].ToString();
                            Response.Redirect("Librarian/Default.aspx");
                        }
                        else
                        {
                            lbl.Text = "Invalid Credential";
                        }
                    }
                }
            }
            else
            {
                string query = "SELECT SID FROM Student WHERE Email = @Email AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", txtuname.Text);
                    cmd.Parameters.AddWithValue("@Password", txtupass.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session["sid"] = reader["SID"].ToString();
                            Session["email"] = txtuname.Text;
                            Response.Redirect("Student/Default.aspx");
                        }
                        else
                        {
                            lbl.Text = "Invalid Credential";
                        }
                    }
                }
            }
        }
    }
}

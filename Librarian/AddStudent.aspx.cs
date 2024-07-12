using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class AddStudent : System.Web.UI.Page
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        // Populate Session dropdown
        PopulateSessionDropdown();
    }

    private void PopulateSessionDropdown()
    {
        ddlSession.Items.Add(new ListItem("-Select-Session-", string.Empty));
        int year = DateTime.Now.Year;
        ddlSession.Items.Add(new ListItem(year.ToString() + " - " + (year + 2).ToString(), year.ToString()));
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (ddlSession.SelectedIndex == 0)
        {
            lblmsg.Text = "Select Proper Session !!";
            lblmsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        string gender = rdomale.Checked ? "Male" : "Female";
        string filePath = "~/Library/img/std/std.png";

        if (fileUpload.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(fileUpload.FileName).ToLower();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };

            if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
            {
                filePath = "~/Library/img/std/" + fileUpload.FileName;
                fileUpload.SaveAs(Server.MapPath(filePath));
            }
            else
            {
                lblFileTypeError.Visible = true;
                return;
            }
        }

        string query = "INSERT INTO Student (Session, Roll, Name, Mobile, Address, City, Pincode, DOB, Gender, Email, Password, ImagePath, EntryDate) " +
                       "VALUES (@Session, @Roll, @Name, @Mobile, @Address, @City, @Pincode, @DOB, @Gender, @Email, @Password, @ImagePath, @EntryDate)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Session", ddlSession.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Roll", txtRoll.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@City", txtcity.Text);
            cmd.Parameters.AddWithValue("@Pincode", txtpincode.Text);
            cmd.Parameters.AddWithValue("@DOB", DateTime.ParseExact(txtBirthDate.Text, "dd-MM-yyyy", null));
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Password", txtmobile.Text); // Change as per your logic
            cmd.Parameters.AddWithValue("@ImagePath", filePath);
            cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Student Added Successfully ! Username is Email and Password is Mobile No.!";
                lblmsg.ForeColor = System.Drawing.Color.Green;

                // Clear form fields
                ddlSession.SelectedIndex = 0;
                txtRoll.Text = "";
                txtName.Text = "";
                txtmobile.Text = "";
                txtaddress.Text = "";
                txtcity.Text = "";
                txtpincode.Text = "";
                txtBirthDate.Text = "";
                txtemail.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}

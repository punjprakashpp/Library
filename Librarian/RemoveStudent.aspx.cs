using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Librarian_RemoveStudent : System.Web.UI.Page
{
    private string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        // Populate Session dropdown
        if (!Page.IsPostBack)
        {
            PopulateSessionDropdown();
            MultiView1.ActiveViewIndex = -1;
        }
    }

    private void PopulateSessionDropdown()
    {
        ddlSession.Items.Clear();
        ddlSession.Items.Add(new ListItem("-Select-Session-", string.Empty));
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT DISTINCT Session FROM Student";
            SqlCommand cmd = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string session = reader.GetString(reader.GetOrdinal("Session"));
                    ddlSession.Items.Add(new ListItem(session, session));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtsearch.Text))
        {
            lblmsg.Text = "Enter search criteria!";
            GridView1.DataSource = null;
            GridView1.DataBind();
            MultiView1.ActiveViewIndex = -1;
        }
        else
        {
            string searchCriteria = txtsearch.Text.Trim();
            string query = string.Empty;
            string parameterName = "@SearchParam";

            if (rdRoll.Checked)
            {
                query = "SELECT sid, Roll, Name, Session FROM Student WHERE Roll LIKE @SearchParam";
            }
            else if (rdName.Checked)
            {
                query = "SELECT sid, Roll, Name, Session FROM Student WHERE Name LIKE @SearchParam";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue(parameterName, searchCriteria + "%");
                DataTable studentTable = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(studentTable);
                    GridView1.DataSource = studentTable;
                    GridView1.DataBind();
                    MultiView1.ActiveViewIndex = 0;
                    lbl.Text = GridView1.Rows.Count.ToString() + " Student(s) Found.";
                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error: " + ex.Message;
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int sid = Convert.ToInt32(e.CommandArgument);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Student WHERE sid = @sid";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sid", sid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblmsg.Text = "Student removed successfully.";
                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }

    protected void btnRemSem_Click(object sender, EventArgs e)
    {
        string selectedSession = ddlSession.SelectedValue;
        if (string.IsNullOrEmpty(selectedSession))
        {
            lblmsg.Text = "Please select a session.";
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Student WHERE Session = @Session";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Session", selectedSession);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                lblmsg.Text = "Students from the selected session removed successfully.";
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Error: " + ex.Message;
            }
        }
    }
}

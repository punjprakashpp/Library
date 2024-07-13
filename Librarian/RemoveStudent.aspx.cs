using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Librarian_RemoveStudent : System.Web.UI.Page
{
    private readonly string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            PopulateSessionDropdown();
            MultiView1.ActiveViewIndex = -1;
        }
    }

    private void PopulateSessionDropdown()
    {
        ddlSession.Items.Clear();
        ddlSession.Items.Add(new ListItem("--- Select Session ---", string.Empty));

        string query = "SELECT DISTINCT Session FROM Student";
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, connection))
        {
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string session = reader.GetString(reader.GetOrdinal("Session"));
                    ddlSession.Items.Add(new ListItem(session, session));
                }
            }
            catch (Exception ex)
            {
                DisplayError("Error populating session dropdown: " + ex.Message);
            }
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtsearch.Text))
        {
            DisplayError("Enter search criteria!");
            ClearGridView();
            return;
        }

        string searchCriteria = txtsearch.Text.Trim();
        string query = string.Empty;

        if (rdRoll.Checked)
        {
            query = "SELECT sid, Roll, Name, Session FROM Student WHERE Roll LIKE @SearchParam";
        }
        else if (rdName.Checked)
        {
            query = "SELECT sid, Roll, Name, Session FROM Student WHERE Name LIKE @SearchParam";
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
        {
            adapter.SelectCommand.Parameters.AddWithValue("@SearchParam", "%" + searchCriteria + "%");
            DataTable studentTable = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(studentTable);
                GridView1.DataSource = studentTable;
                GridView1.DataBind();
                MultiView1.ActiveViewIndex = 0;
                lbl.Text = studentTable.Rows.Count + " Student(s) Found.";
            }
            catch (Exception ex)
            {
                DisplayError("Error searching students: " + ex.Message);
                ClearGridView();
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            int sid = Convert.ToInt32(e.CommandArgument);
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("DELETE FROM Student WHERE sid = @sid", connection))
            {
                command.Parameters.AddWithValue("@sid", sid);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblmsg.Text = "Student removed successfully.";
                }
                catch (Exception ex)
                {
                    DisplayError("Error removing student: " + ex.Message);
                }
            }
        }
    }

    protected void btnRemSem_Click(object sender, EventArgs e)
    {
        string selectedSession = ddlSession.SelectedValue;
        if (string.IsNullOrEmpty(selectedSession))
        {
            DisplayError("Please select a session.");
            return;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand("DELETE FROM Student WHERE Session = @Session", connection))
        {
            command.Parameters.AddWithValue("@Session", selectedSession);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                lblmsg.Text = "Students from the selected session removed successfully.";
                PopulateSessionDropdown();
            }
            catch (Exception ex)
            {
                DisplayError("Error removing students by session: " + ex.Message);
            }
        }
    }

    private void DisplayError(string message)
    {
        lblmsg.Text = message;
        lblmsg.ForeColor = System.Drawing.Color.Red;
    }

    private void ClearGridView()
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        MultiView1.ActiveViewIndex = -1;
    }
}

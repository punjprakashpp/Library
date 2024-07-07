using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Studenteport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            MultiView1.ActiveViewIndex = -1;
        }
        lblmsg.Text = "";
    }

    protected void btnseach_Click(object sender, EventArgs e)
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
            string parameterName = string.Empty;

            if (rdRoll.Checked)
            {
                query = "SELECT sid, Roll, Name, Session FROM Student WHERE Roll LIKE @SearchParam";
                parameterName = "@SearchParam";
            }
            else if (rdName.Checked)
            {
                query = "SELECT sid, Roll, Name, Session FROM Student WHERE Name LIKE @SearchParam";
                parameterName = "@SearchParam";
            }

            string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
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
        if (e.CommandName == "View")
        {
            MultiView1.ActiveViewIndex = 1;
            int sid = Convert.ToInt32(e.CommandArgument);
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student WHERE sid = @sid";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@sid", sid);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        lblsem.Text = reader["Session"].ToString();
                        lblRoll.Text = reader["Roll"].ToString();
                        lblname.Text = reader["Name"].ToString();
                        lblmobile.Text = reader["Mobile"].ToString();
                        lbladdress.Text = reader["Address"].ToString();
                        lblcity.Text = reader["City"].ToString();
                        lblpin.Text = reader["Pincode"].ToString();
                        DateTime dob = Convert.ToDateTime(reader["dob"]);
                        lbldob.Text = dob.ToString("dd MMM yyyy");
                        lblGen.Text = reader["Gender"].ToString();
                        lblemai.Text = reader["Email"].ToString();
                        lblpass.Text = reader["Password"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblmsg.Text = "Error: " + ex.Message;
                }
            }
        }
    }

    protected void Button12_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
}

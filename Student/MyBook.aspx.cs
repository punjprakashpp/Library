using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_MyBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchRentData(null);
        }
    }

    protected void btntaken_Click(object sender, EventArgs e)
    {
        FetchRentData(sender);
    }

    protected void btnreturn_Click(object sender, EventArgs e)
    {
        FetchRentData(sender);
    }

    private void FetchRentData(object sender)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        int sid = Convert.ToInt32(Session["sid"]);

        int status = 0; // Default to borrowed books
        if (sender != null && sender is Button)
        {
            Button button = (Button)sender;
            status = button.ID == "btntaken" ? 1 : 0;
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT BookName, IssueDate, DATEDIFF(day, IssueDate, ReturnDate) AS Days, ReturnDate FROM Rent WHERE SID = @SID AND Status = @Status";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@SID", sid);
                command.Parameters.AddWithValue("@Status", status);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (status == 1)
                        {
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                            lblb.Text = GridView1.Rows.Count.ToString();
                            MultiView1.ActiveViewIndex = 0;
                        }
                        else
                        {
                            GridView2.DataSource = reader;
                            GridView2.DataBind();
                            lblr.Text = GridView2.Rows.Count.ToString();
                            MultiView1.ActiveViewIndex = 1;
                        }
                    }
                    else
                    {
                        // Handle no rows found scenario
                    }
                }
            }
        }
    }
}

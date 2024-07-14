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
        }
    }

    protected void btntaken_Click(object sender, EventArgs e)
    {
        FetchRentData(1);
    }

    protected void btnreturn_Click(object sender, EventArgs e)
    {
        FetchRentData(0);
    }

    private void clear()
    {
        lblmsg.Text = "";
        MultiView1.ActiveViewIndex = -1;
    }

    private void FetchRentData(int status)
    {
        clear();
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        int sid = Convert.ToInt32(Session["sid"]);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT b.BookNo, b.BookName, r.IssueDate, r.ReturnDate, DATEDIFF(day, r.IssueDate, r.ReturnDate) AS Days
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE s.SID = @SID AND r.Status = @Status";
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
                        lblmsg.Text = "No Books Found !!";
                        MultiView1.ActiveViewIndex = -1;
                    }
                }
            }
        }
    }
}

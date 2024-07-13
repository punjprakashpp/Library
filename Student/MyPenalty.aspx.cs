using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Student_MyPanalty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FetchPenaltyData();
        }
    }

    private void FetchPenaltyData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;
        string query = @"
                SELECT b.BookNo, b.BookName, b.Price, r.Amount, r.Detail, r.EntryDate
                FROM Rent r
                INNER JOIN Book b ON r.BID = b.BID
                INNER JOIN Student s ON r.SID = s.SID
                WHERE s.SID = @SID AND r.Penalty = @Penalty";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Assuming SID is stored in session, adjust as needed
                int sid = Convert.ToInt32(Session["sid"]);

                cmd.Parameters.AddWithValue("@SID", sid);
                cmd.Parameters.AddWithValue("@Penalty", 1);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else
                {
                    lblmsg.Text = "No Penalty is found.";
                }
                    
            }
        }
    }
}

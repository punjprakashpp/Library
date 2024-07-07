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
        string query = "SELECT PID, SID, BookName, Price, Penalty, Amount, Detail, EntryDate FROM Penalty WHERE SID = @SID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Assuming SID is stored in session, adjust as needed
                int sid = Convert.ToInt32(Session["sid"]);

                cmd.Parameters.AddWithValue("@SID", sid);

                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
        }
    }
}

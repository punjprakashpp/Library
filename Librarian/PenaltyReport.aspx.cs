using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Student_MyPenalty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPenaltyData();
        }
    }

    private void LoadPenaltyData()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LibraryConnectionString"].ConnectionString;

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        s.Roll,
                        s.Name,
                        p.BookNo,
                        p.BookName,
                        p.Price,
                        p.Amount,
                        p.Detail
                    FROM 
                        Penalty p
                    INNER JOIN 
                        Student s ON p.SID = s.SID
                    WHERE p.Penalty = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable penaltyTable = new DataTable();
                    adapter.Fill(penaltyTable);

                    if (penaltyTable.Rows.Count > 0)
                    {
                        GridView3.DataSource = penaltyTable;
                        GridView3.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "No penalty records found.";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error loading penalty data: " + ex.Message;
        }
    }
}

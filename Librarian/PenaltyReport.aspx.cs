using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
                        b.BookNo,
                        b.BookName,
                        b.Price,
                        r.Amount,
                        r.Detail
                    FROM 
                        Rent r
                    INNER JOIN 
                        Student s ON r.SID = s.SID
                    INNER JOIN 
                        Book b ON r.BID = b.BID
                    WHERE r.Penalty = 1 AND r.Status = 1";

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

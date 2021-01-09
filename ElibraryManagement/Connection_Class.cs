using System.Configuration;
using System.Data.SqlClient;

public class Connection_Class
{
    //-- code to get a connection object
    public static SqlConnection GetConnection()
    {
       
        string str = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con = new SqlConnection(str);
        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        return con;
        
    }

    //-- code to make sure to close connection and dispose the object
    public static void Dispose(SqlConnection con)
    {
        if (con.State == System.Data.ConnectionState.Open)
            con.Close();
        con.Dispose();
    }
}
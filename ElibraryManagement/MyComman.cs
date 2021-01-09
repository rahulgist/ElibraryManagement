using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ElibraryManagement
{
    public class MyComman
    {
        static SqlConnection con = Connection_Class.GetConnection();
        public static bool CheckMemberExists(String MemberID) 
        {
            SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + MemberID + "';", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
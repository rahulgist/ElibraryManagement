using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class userlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = Connection_Class.GetConnection();

                String username = TextBox1.Text.Trim();
                String password = TextBox2.Text.Trim();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.member_master_tbl WHERE member_id='"+username+"' AND password='"+password+"';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid User Found');</script>");
                }

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}
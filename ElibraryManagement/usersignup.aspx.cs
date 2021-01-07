using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class usersignup : System.Web.UI.Page
    {   
        //create a connection string
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //signup button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists()) {
                Response.Write("<script>alert('Member Already Exist with this member id');</script>");

            }
            else
            {
                Response.Write("<script>alert('checkMemberExists');</script>");
                SignupNewMember();
            }
            
        }


        bool checkMemberExists() {

            try
            {
                //creating con object
                SqlConnection con = new SqlConnection(strcon);

                //check whether connection is connected or not
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                string username = TextBox8.Text.Trim();
                SqlCommand cmd = new SqlCommand("SELECT * member_master_tbl where member_id='" + username + "';", con);
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
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;

            }

            
        }


        void SignupNewMember() {

            try
            {
                //creating con object
                SqlConnection con = new SqlConnection(strcon);

                //check whether connection is connected or not
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into member_master_tbl(member_id,fullname,dob,contact_no,email,state,city,pincode,full_address,password,account_status) " +
                    "values(@member_id,@fullname,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@password,@account_status)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@fullname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Signup Successful!!');</script>");

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LoginPortal
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
                {
                    string uid = txtUserName.Text;
                    string pass = txtPwd.Text;
                    con.Open();
                    string qry = "SELECT * FROM Userlogin WHERE UserName='" + uid + "' AND Password='" + pass + "'";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        lblMessage.Text = "You can move forward!!";
                    }
                    else
                    {
                        lblMessage.Text = "Kripya bahar jaye!";
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            
        }
    }
}
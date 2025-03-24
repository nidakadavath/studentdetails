using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentdetails
{
    public partial class login : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(user_id) from login where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string count = ob.fn_scalar(str);
            int i = Convert.ToInt32(count);
            if (i == 1)
            {
                Response.Redirect("userdetails.aspx");
            }
        }
    }
}
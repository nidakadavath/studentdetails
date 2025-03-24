using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace studentdetails
{
    public partial class register : System.Web.UI.Page
    {
        Class1 ob = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("coursename");
                dt.Columns.Add("percentage");
                dt.Columns.Add("yearofpassing");

                ViewState["QualificationData"] = dt;
                BindGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["QualificationData"];

            
            dt.Rows.Add(TextBox11.Text, TextBox12.Text, TextBox13.Text);

          
            ViewState["QualificationData"] = dt;

         
            BindGrid();
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
        }

        public void BindGrid()
        {
            GridView1.DataSource = ViewState["QualificationData"] as DataTable;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string str = "insert into details values('" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','"+TextBox5.Text+"','"+TextBox6.Text+"',"+TextBox7.Text+",'"+TextBox14.Text+"','"+TextBox10.Text+"')";
            int ins = ob.fn_nonquery(str);
            if (ins == 1)
            {
                string str3 = "insert into qual values('" + TextBox11.Text + "','" + TextBox12.Text + "','"+TextBox13.Text+"')";
                int ins1 = ob.fn_nonquery(str3);
                if(ins1==1)
                {
                    using (SqlConnection sqlconn = new SqlConnection(@"server=LAPTOP-A7D9DENM\SQLEXPRESS;database=student1;integrated security=true"))
                    {
                        sqlconn.Open();

                        foreach (GridViewRow gr in GridView1.Rows)
                        {
                            string sqlquery = "INSERT INTO qual (course_name, percentage,yearofpassing) VALUES (@course_name, @percentage, @yearofpassing)";
                            using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                            {
                                sqlcomm.Parameters.AddWithValue("@course_name", gr.Cells[0].Text);
                                sqlcomm.Parameters.AddWithValue("@percentage", gr.Cells[1].Text);
                                sqlcomm.Parameters.AddWithValue("@yearofpassing", gr.Cells[2].Text);

                                sqlcomm.ExecuteNonQuery();
                            }
                        }

                        sqlconn.Close();
                        Label1.Text = "Records Inserted Successfully!";
                    }

                }

            }
          
        }
    }
}
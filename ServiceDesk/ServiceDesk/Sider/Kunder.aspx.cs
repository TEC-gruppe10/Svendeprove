using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace ServiceDesk
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Populating a DataTable from database.
                DataTable kunder = this.GetList();
                GridView1.DataSource = kunder;
                GridView1.DataBind();
                int[,] medarbejdere = new int[kunder.Rows.Count, 3];
                for (int i = 0; i < kunder.Rows.Count; i++)
                {
                    medarbejdere[i, 0] = Convert.ToInt32(kunder.Rows.Find("ID")[i].ToString());
                    
                }
            }
        }

        private DataTable GetList()//skal rettes til med ip og login. Evt kalde stored precedure
        {
            /*string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name, Country FROM Customers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            */
            DataTable dt = new DataTable();
            return dt;
        }
        private DataTable GetNumbers()//Skal rettes til med ip og login. Evt kalde en stored procedure
        {
            DataTable dt = new DataTable();
            return dt;
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                mMedarbejder.Text = "Hello";
                uMedarbejder.Text = "Hello";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
    }
}

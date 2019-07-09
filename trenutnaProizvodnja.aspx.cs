using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Drawing;

namespace PrikazBazePodatkovProizvodnja
{
    public partial class trenutnaProizvodnja : System.Web.UI.Page
    {
        static int maxID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            var queryString = "SELECT max(id) FROM testnaTabela4";
            var dbConnection = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConnection);
            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            DataTable dataTableMaxId = new DataTable();
            dataAdapter.Fill(dataTableMaxId);
            object field = dataTableMaxId.Rows[0][0];
            maxID = Convert.ToInt32(field);
            BindData(maxID);
            BindDataToCount(maxID);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        private DateTime GetStartOfWork(DateTime currentTime)
        {
            int hourNow = currentTime.Hour;
            if (hourNow > 5 && hourNow < 14)
            {
                return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 6, 0, 0);
            }
            else
            {
                return new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 14, 0, 0);
            }
        }

        DataTable dataTableCount = new DataTable();


        protected void BindDataToCount(int maxID)
        {
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT * FROM testnaTabela4   WHERE";

                    if (radioButtonTimeValue.Value != "1")
                    {
                    }
                    else
                    {
                        sql += " id > @id";
                        cmd.Parameters.AddWithValue("@id", maxID - 1000);
                    }
                    if (radioButtonTimeValue.Value == "2")
                    {
                        sql += " cas > @datum";
                        cmd.Parameters.AddWithValue("@datum", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0));
                    }

                    if (radioButtonTimeValue.Value == "3")
                    {
                        sql += " cas > @datum";
                        cmd.Parameters.AddWithValue("@datum", GetStartOfWork(new DateTime(2019, 7, 5, 16, 1, 0)));
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        var ds = new DataSet();
                        sda.Fill(ds);
                        sda.Fill(dataTableCount);
                        countRows();
                    }
                }
            }
        }


        protected void BindData(int maxID)
        {
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT * FROM testnaTabela4 WHERE";

                    if (radioButtonTimeValue.Value == "1")
                    {
                        sql += " id > @id";
                        cmd.Parameters.AddWithValue("@id", maxID - 1000);
                    }
                    if (radioButtonTimeValue.Value == "2")
                    {
                        sql += " cas > @datum";
                        cmd.Parameters.AddWithValue("@datum", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0));
                    }

                    if (radioButtonTimeValue.Value == "3")
                    {
                        sql += " cas > @datum";
                        cmd.Parameters.AddWithValue("@datum", GetStartOfWork(new DateTime(2019, 7, 5, 16, 1, 0)));
                    }



                    if (radioButtonStatusValue.Value == "2")
                    {
                        sql += "  AND";
                        sql += " genStat = @status";
                        cmd.Parameters.AddWithValue("@status", 1);
                    }

                    if (radioButtonStatusValue.Value == "3")
                    {
                        sql += "  AND";
                        sql += " genStat > @status";
                        cmd.Parameters.AddWithValue("@status", 1);
                    }

                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        var ds = new DataSet();
                        sda.Fill(ds);
                        datagrid.DataSource = ds.Tables[0];
                        datagrid.DataBind();
                    }
                }
            }
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagrid.PageIndex = e.NewPageIndex;
            BindData(maxID);
        }

        protected void countRows()
        {
            int countAll = dataTableCount.Rows.Count;
            int countOk = dataTableCount.Select("genStat = 1").Length;
            Label2.Text = countAll.ToString();
            Label3.Text = countOk.ToString();
            Label4.Text = (countAll - countOk).ToString();
        }

        protected void datagrid_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            int globalniStatusStolpec = 3;//stolpec, ki definira globalni status
            int[] arrayStolpcevStatusov = new int[] { 4, 5, 6, 9, 11, 12, 13, 15, 17, 19, 21, 24, 27 };//solpci, ki jih je potrebno pregledati da lahko pobarvamo celice, ki nimajo ok statusov
            int sirinaPrvegaStolpca = 80;
            if (e.Row.RowType != DataControlRowType.Pager)//vse vrstice, ki niso pager (spremeba strani)
            {
                e.Row.Cells[0].Visible = false;//skrije prvi stolpec
            }

            if (e.Row.RowType == DataControlRowType.Header)//ce je vrstica glava
            {
                e.Row.Cells[1].Width = sirinaPrvegaStolpca;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)//only look at datarows (not header, footer,...)
            {

                e.Row.Cells[1].CssClass = "pinned";//set the first column to locked through css class pinned
                e.Row.Cells[1].Width = sirinaPrvegaStolpca;

                if (Convert.ToInt32(e.Row.Cells[globalniStatusStolpec].Text) != 1)//ce globalni status ni 1(ok) potem pobarvaj vrstico rdeče in poglej ostale statuse
                {
                    e.Row.BackColor = Color.LightSalmon;
                    foreach (int i in arrayStolpcevStatusov)
                    {
                        if (Convert.ToInt32(e.Row.Cells[i].Text) != 1)
                        {
                            e.Row.Cells[i].BackColor = Color.Red;
                        }
                    }

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();

        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Matech" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            datagrid.AllowPaging = false;
            datagrid.DataBind();
            datagrid.GridLines = GridLines.Both;
            datagrid.HeaderStyle.Font.Bold = true;
            datagrid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

    }
}
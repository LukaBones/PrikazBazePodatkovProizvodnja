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
    public partial class zgodovina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            var queryString = "SELECT TOP 35 * FROM testnaTabela4";
            //"SELECT * FROM testnaTabela WHERE ime LIKE '%U%'";
            var dbConnection = new SqlConnection(dbConnectionString);
            var dataAdapter = new SqlDataAdapter(queryString, dbConnection);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);

            var ds = new DataSet();
            dataAdapter.Fill(ds);

            if (!IsPostBack)
            {
                GridView1.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                //Label1.Text = GridView1.Rows.Count.ToString();

            }
            //getRowCount(1);
            /*
            datagrid.Attributes.Add("style", "word-break:keep-all;word-wrap:normal");
            datagrid.DataSource = ds.Tables[0];
            datagrid.DataBind();
            //Label1.Text = GridView1.Rows.Count.ToString();
            */

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers();
        }
        private void SearchCustomers()
        {
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT * FROM testnaTabela4";
                    if (!string.IsNullOrEmpty(TextBox6.Text.Trim()))
                    {
                        sql += " WHERE liv2DRead LIKE '%' + @ime + '%'";
                        cmd.Parameters.AddWithValue("@ime", TextBox6.Text.Trim());
                    }
                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt.DefaultView;
                        GridView1.DataBind();
                        //Label1.Text = GridView1.Rows.Count.ToString();
                    }
                }
            }
        }
        public string ReturnRandomString(Random random)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public int ReturnRandomInt(Random random, int min, int max)
        {
            return random.Next(min, max);
        }



        public byte ReturnRandomByte(Random random, int[] arrayOfNumbers)
        {
            int intFromArray = arrayOfNumbers[random.Next(0, arrayOfNumbers.Length)];
            byte ranByte = Convert.ToByte(intFromArray);
            return ranByte;
        }

        public double ReturnRandomFloat(Random random)
        {
            return random.NextDouble() * 2;
        }

        public static DateTime ReturnRandomDateTime(Random random, DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        private void InsertTestDataToTable()
        {
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                int i = 0;
                string sql = "INSERT INTO testnaTabela4 ([laser2DRead],[cas],[genStat],[liv2DStat],[liv2DRead],[laser2DStatGrav],[laser2DStatRead],[laser2DWrite],[tesnostStat],[tesnostResult],[prehStatA],[prehStatB],[navojStatA],[navojValueA],[navojStatB],[navojValueB],[navojStatC],[navojValueC],[navojStatD],[navojValueD],[podlozkaStatA],[podlozkaGlobA],[podlozkaSilaA],[podlozkaStatB],[podlozkaGlobB],[podlozkaSilaB],[podlozkaStatC],[podlozkaGlobC],[podlozkaSilaC]) " +
                                                     "values(@laser2DRead,@cas,@genStat,@liv2DStat,@liv2DRead,@laser2DStatGrav,@laser2DStatRead,@laser2DWrite,@tesnostStat,@tesnostResult,@prehStatA,@prehStatB,@navojStatA,@navojValueA,@navojStatB,@navojValueB,@navojStatC,@navojValueC,@navojStatD,@navojValueD,@podlozkaStatA,@podlozkaGlobA,@podlozkaSilaA,@podlozkaStatB,@podlozkaGlobB,@podlozkaSilaB,@podlozkaStatC,@podlozkaGlobC,@podlozkaSilaC) ";
                cnn.Open();
                var ran = new Random();

                DateTime start = new DateTime(2012, 1, 1);

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.Add("@laser2DRead", SqlDbType.Char);
                    cmd.Parameters.Add("@cas", SqlDbType.DateTime);
                    cmd.Parameters.Add("@genStat", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@liv2DStat", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@liv2DRead", SqlDbType.Char);
                    cmd.Parameters.Add("@laser2DStatGrav", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@laser2DStatRead", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@laser2DWrite", SqlDbType.Char);
                    cmd.Parameters.Add("@tesnostStat", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@tesnostResult", SqlDbType.Decimal);
                    cmd.Parameters.Add("@prehStatA", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@prehStatB", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@navojStatA", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@navojValueA", SqlDbType.Int);
                    cmd.Parameters.Add("@navojStatB", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@navojValueB", SqlDbType.Int);
                    cmd.Parameters.Add("@navojStatC", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@navojValueC", SqlDbType.Int);
                    cmd.Parameters.Add("@navojStatD", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@navojValueD", SqlDbType.Int);
                    cmd.Parameters.Add("@podlozkaStatA", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@podlozkaGlobA", SqlDbType.Decimal);
                    cmd.Parameters.Add("@podlozkaSilaA", SqlDbType.Decimal);
                    cmd.Parameters.Add("@podlozkaStatB", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@podlozkaGlobB", SqlDbType.Decimal);
                    cmd.Parameters.Add("@podlozkaSilaB", SqlDbType.Decimal);
                    cmd.Parameters.Add("@podlozkaStatC", SqlDbType.TinyInt);
                    cmd.Parameters.Add("@podlozkaGlobC", SqlDbType.Decimal);
                    cmd.Parameters.Add("@podlozkaSilaC", SqlDbType.Decimal);




                    while (i < 10000)
                    {
                        cmd.Parameters["@laser2DRead"].Value = ReturnRandomString(ran);
                        cmd.Parameters["@cas"].Value = ReturnRandomDateTime(ran, new DateTime(2014, 1, 1, 6, 0, 0), new DateTime(2019, 7, 3, 6, 0, 0));
                        cmd.Parameters["@genStat"].Value = ReturnRandomByte(ran, new int[] { 1, 2, 3, 4 });
                        cmd.Parameters["@liv2DStat"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@liv2DRead"].Value = ReturnRandomString(ran);
                        cmd.Parameters["@laser2DStatGrav"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@laser2DStatRead"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@laser2DWrite"].Value = ReturnRandomString(ran);
                        cmd.Parameters["@tesnostStat"].Value = ReturnRandomByte(ran, new int[] { 1, 2, 4 });
                        cmd.Parameters["@tesnostResult"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@prehStatA"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@prehStatB"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@navojStatA"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@navojValueA"].Value = ReturnRandomInt(ran, 1, 100);
                        cmd.Parameters["@navojStatB"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@navojValueB"].Value = ReturnRandomInt(ran, 1, 100);
                        cmd.Parameters["@navojStatC"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@navojValueC"].Value = ReturnRandomInt(ran, 1, 100);
                        cmd.Parameters["@navojStatD"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@navojValueD"].Value = ReturnRandomInt(ran, 1, 100);
                        cmd.Parameters["@podlozkaStatA"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@podlozkaGlobA"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@podlozkaSilaA"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@podlozkaStatB"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@podlozkaGlobB"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@podlozkaSilaB"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@podlozkaStatC"].Value = ReturnRandomByte(ran, new int[] { 1, 2 });
                        cmd.Parameters["@podlozkaGlobC"].Value = ReturnRandomFloat(ran);
                        cmd.Parameters["@podlozkaSilaC"].Value = ReturnRandomFloat(ran);

                        cmd.ExecuteNonQuery();

                        i++;
                    }
                }


            }
        }
        private int getRowCount(int tipStatusa, int buttonValue)
        {
            string sqlNew;
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            int i = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT COUNT(*) FROM testnaTabela4 WHERE";

                    if (!string.IsNullOrEmpty(TextBox6.Text.Trim()))
                    {

                        sql += " liv2DRead LIKE '%' + @ime + '%'";
                        cmd.Parameters.AddWithValue("@ime", TextBox6.Text.Trim());
                    }

                    else
                    {

                        if (!string.IsNullOrEmpty(TextBox4.Text.Trim()))
                        {
                            sql += " cas > @datum";
                            cmd.Parameters.AddWithValue("@datum", TextBox4.Text.Trim());
                            i++;
                        }



                        if (!string.IsNullOrEmpty(TextBox5.Text.Trim()))
                        {
                            if (i > 0)
                            {
                                sql += " AND";
                            }
                            sql += " cas < @datum2";
                            cmd.Parameters.AddWithValue("@datum2", TextBox5.Text.Trim());
                            i++;
                        }
                    }

                    if (tipStatusa == 0)//za generalni status
                    {

                        sql += " AND genStat ";
                        if (buttonValue == 1)
                        {
                            sql += "= @genSatus";
                            cmd.Parameters.AddWithValue("@genSatus", buttonValue);
                        }
                        else
                        {
                            buttonValue = 1;
                            sql += "!= @genSatus";
                            cmd.Parameters.AddWithValue("@genSatus", buttonValue);
                        }
                    }

                    if (tipStatusa == 1)//za vtiskovanje
                    {

                        sql += " AND liv2DStat ";
                        if (buttonValue == 1)
                        {
                            sql += "= @liv2DStat";
                            cmd.Parameters.AddWithValue("@liv2DStat", buttonValue);
                        }
                        else
                        {
                            buttonValue = 1;
                            sql += "!= @liv2DStat";
                            cmd.Parameters.AddWithValue("@liv2DStat", buttonValue);
                        }
                    }

                    if (tipStatusa == 2)//za vijačenje
                    {

                        sql += " AND laser2DStatGrav ";
                        if (buttonValue == 1)
                        {
                            sql += "= @laser2DStatGrav";
                            cmd.Parameters.AddWithValue("@laser2DStatGrav", buttonValue);
                        }
                        else
                        {
                            buttonValue = 1;
                            sql += "!= @laser2DStatGrav";
                            cmd.Parameters.AddWithValue("@laser2DStatGrav", buttonValue);
                        }
                    }

                    if (tipStatusa == 3)//za tesnost
                    {

                        sql += " AND tesnostStat ";
                        if (buttonValue == 1)
                        {
                            sql += "= @tesnostStat";
                            cmd.Parameters.AddWithValue("@tesnostStat", buttonValue);
                        }
                        if (buttonValue == 2)
                        {
                            sql += "= @tesnostStat";
                            cmd.Parameters.AddWithValue("@tesnostStat", buttonValue);
                        }
                        if (buttonValue == 4)
                        {
                            sql += "= @tesnostStat";
                            cmd.Parameters.AddWithValue("@tesnostStat", buttonValue);
                        }
                    }

                    cmd.CommandText = sql;
                    cmd.Connection = con;
                    con.Open();
                    Int32 count = (Int32)cmd.ExecuteScalar();
                    //Label2.Text = count.ToString();
                    return count;
                }
            }
        }
        private bool isTextBoxFull(TextBox textBox)
        {
            if (textBox.Text.Length > 4)
                return true;
            else
                return false;
        }

        private bool checkTextBoxDateFormat(TextBox textBox)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                try
                {
                    DateTime dt = DateTime.ParseExact(textBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);//CultureInfo.InvariantCulture
                    textBox.BackColor = Color.White;
                    return (true);
                }
                catch (FormatException)
                {
                    textBox.BackColor = Color.Red;
                    return (false);
                }
            }
            textBox.BackColor = Color.White;
            return (true);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            if (!checkTextBoxDateFormat(TextBox4))
            {
                return;
            }

            if (!checkTextBoxDateFormat(TextBox5))
            {
                return;
            }

            //InsertTestDataToTable();
           
            
            if(i == 0)//if there is no filters active get all row count
            {
               getRowCount(1);
            }
            else//if there are filters active get filtered row count
            {
                getRowCount(0);
            }
            */
            //BindData();
        }

        private void ExportGridToExcel(bool all)
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
            GridView gvexport = GridView1;
            gvexport.Columns[0].Visible = false;
            gvexport.HeaderRow.Visible = true;

            string[] headerText = new string[] { "", "IME", "DATUM", "STATUS", "PARAMETER 1", "PARAMETER 2", "PARAMETER 3", "PARAMETER 4", "PARAMETER 5", "PARAMETER 6", "PARAMETER 7", "PARAMETER 8", "PARAMETER 9", "PARAMETER 10", "PARAMETER 11", "PARAMETER 12", "PARAMETER 13", "PARAMETER 14", "PARAMETER 15", "PARAMETER 16" };
            _ = new TableCell();

            for (int i = 1; i < 16; i++)
            {
                TableCell tbCell1 = new TableCell();
                tbCell1.Text = headerText[i];
                gvexport.HeaderRow.Cells.AddAt(i, tbCell1);
            }

            if (!all)
            {
                foreach (GridViewRow i in GridView1.Rows)
                {
                    gvexport.Rows[i.RowIndex].Visible = false;
                    CheckBox cb = (CheckBox)i.FindControl("SelectCheckBox");
                    if (cb.Checked)
                    {
                        gvexport.Rows[i.RowIndex].Visible = true;
                    }
                }
            }

            gvexport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(false);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(true);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            InsertTestDataToTable();
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //SearchCustomers();
            BindData();
        }

        protected void BindData()
        {
            string constr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            int i = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string sql = "SELECT * FROM testnaTabela4 WHERE";//TOP 100

                    if (!string.IsNullOrEmpty(TextBox6.Text.Trim()))
                    {

                        sql += " liv2DRead LIKE '%' + @ime + '%'";
                        cmd.Parameters.AddWithValue("@ime", TextBox6.Text.Trim());
                    }

                    else
                    {

                        if (!string.IsNullOrEmpty(TextBox4.Text.Trim()))
                        {
                            sql += " cas > @datum";
                            cmd.Parameters.AddWithValue("@datum", TextBox4.Text.Trim());
                            i++;
                        }



                        if (!string.IsNullOrEmpty(TextBox5.Text.Trim()))
                        {
                            if (i > 0)
                            {
                                sql += " AND";
                            }
                            sql += " cas < @datum2";
                            cmd.Parameters.AddWithValue("@datum2", TextBox5.Text.Trim());
                            i++;
                        }

                        if (radioButtonHistoryStatusValue.Value != "0")//ce ni izbran gumb VSI potem poglej kateri je izbran in prikaži le tega
                        {
                            if (DropDownList1.SelectedIndex == 0)//za generalni status
                            {

                                sql += " AND genStat ";
                                if (radioButtonHistoryStatusValue.Value == "1")
                                {
                                    sql += "= @genSatus";
                                    cmd.Parameters.AddWithValue("@genSatus", 1);
                                }
                                if (radioButtonHistoryStatusValue.Value == "2")
                                {
                                    sql += "!= @genSatus";
                                    cmd.Parameters.AddWithValue("@genSatus", 1);
                                }
                            }
                        }




                    }


                    cmd.CommandText = sql;
                    cmd.Connection = con;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        //GridView1.Visible = false;
                        //Label1.Text = GridView1.Rows.Count.ToString();
                    }
                }

            }
            Label8.Text = getRowCount(10, 10).ToString();
            Label8.Visible = true;
            Label9.Text = getRowCount(DropDownList1.SelectedIndex, 1).ToString();
            Label9.Visible = true;
            Label10.Text = getRowCount(DropDownList1.SelectedIndex, 2).ToString();
            Label10.Visible = true;
            if (DropDownList1.SelectedIndex == 3)
            {
                Label1.Text = getRowCount(DropDownList1.SelectedIndex, 4).ToString();
                Label1.Visible = true;
            }

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            divToHide.Visible = false;
            Label8.Text = getRowCount(10, 10).ToString();
            Label8.Visible = true;
            Label9.Text = getRowCount(DropDownList1.SelectedIndex, 1).ToString();
            Label9.Visible = true;
            Label10.Text = getRowCount(DropDownList1.SelectedIndex, 2).ToString();
            Label10.Visible = true;
            if (DropDownList1.SelectedIndex == 3)
            {
                divToHide.Visible = true;
                Label1.Text = getRowCount(DropDownList1.SelectedIndex, 4).ToString();
                Label1.Visible = true;
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class admin_sjgl : System.Web.UI.Page
{
    string sql = "";
    SqlDataReader rds;
    protected string f_nav = "";
    protected string c_nav = "";
    protected string _nav_cla = "none_none";
    protected int p = 1;
    protected string c = "";
    db_help obj;

    public string nav_cla
    {
        get
        {
            return _nav_cla;
        }
        set
        {
            _nav_cla = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(_nav_cla == ""))
        {
            string[] navs = _nav_cla.Split('_');
            f_nav = navs[0];
            c_nav = _nav_cla;
        }
        function_all.adminLoginChack(0, "Default.aspx");
        c = Request.QueryString["c"];
        p = System.Convert.ToInt32(Request.QueryString["p"]);
        if (!IsPostBack)
        {
            drop_cla_bind();

        }


    }
    public void drop_cla_bind()
    {
        obj = new db_help();
        string connectingstring = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        SqlConnection scon = new SqlConnection(connectingstring);
        scon.Open();
        string sql = "select * from txk order by txID";
        SqlDataAdapter sda = new SqlDataAdapter(sql, scon);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        drop_cla.DataSource = ds;
        drop_cla.DataTextField = "stlx";
        drop_cla.DataValueField = "txID";
        drop_cla.DataBind();
        sda.Dispose();
        scon.Close();

        for (int n = 0; n < drop_cla.Items.Count; n++)
        {
            if (System.Convert.ToString(drop_cla.Items[n].Value) == c)
            {
                drop_cla.Items[0].Selected = false;
                drop_cla.Items[n].Selected = true;
                break;
            }
        }
    }
    protected void drop_cla_SelectedIndexChanged(object sender, EventArgs e)
    {

        function_all.adminLoginChack(0, "Default.aspx");
        function_all.TiaoZhuan("", "sjgl.aspx?c=" + drop_cla.SelectedValue, 0);
        Response.End();
    }




    protected void butt_ok_Click(object sender, EventArgs e)
    {

        int a = System.Convert.ToInt32(Txt_1.Text);
        obj = new db_help();
        if (System.Convert.ToUInt32(c)==1)
        {
           
                sql = "select top "+a+" [X_nr] from xzt where X_zj= " + Txt_3.Text + " and X_nd= '" + Txt_2.Text.ToString() + "'";
                rds = obj.ExecReaderSql(sql);
                if (rds.Read())
                {
                    if (!Convert.IsDBNull(rds["X_nr"]))
                    {
                        Text_nr.Text = rds["X_nr"].ToString();

                    }
                }


               
        }
        if(System.Convert.ToUInt32(c)==2)
        
          {
                sql = "select top " +a + " p_nr from  pdt where p_zj=" + Txt_3.Text + "and p_nd='" + Txt_2.Text.ToString() + "'";
                rds = obj.ExecReaderSql(sql);
                if (rds.Read())
                {
                    if (!Convert.IsDBNull(rds["p_nr"]))
                    {
                        Text_nr.Text = rds["p_nr"].ToString();

                    }
                }
              
           }
        if(System.Convert.ToUInt32(c)==3)
         {
             
                sql = "select top "+a+" d_nr from  dcx where d_zj=" + Txt_3.Text + "and d_nd='" + Txt_2.Text.ToString() + "'";
                rds = obj.ExecReaderSql(sql);
                if (rds.Read())
                {
                    if (!Convert.IsDBNull(rds["d_nr"]))
                    {
                        Text_nr.Text = rds["d_nr"].ToString();

                    }
                }
           }

                
           
       if(System.Convert.ToUInt32(c)==4)
        { 
                sql = "select top " + a + " j_nr from  jdt where j_zj=" + Txt_3.Text + "and j_nd='" + Txt_2.Text.ToString() + "'";
                rds = obj.ExecReaderSql(sql);
                if (rds.Read())
                {
                    if (!Convert.IsDBNull(rds["j_nr"]))
                    {
                        Text_nr.Text = rds["j_nr"].ToString();

                    }
                }
                
       }
            
         if(System.Convert.ToUInt32(c)==5)
         { 
                 sql = "select top " + a + " b_nr from  bct where b_zj=" + Txt_3.Text + "and b_nd='" + Txt_2.Text.ToString() + "'";
                 rds = obj.ExecReaderSql(sql);
                 if (rds.Read())
                    {
                        if (!Convert.IsDBNull(rds["b_nr"]))
                        {
                            Text_nr.Text = rds["b_nr"].ToString();

                        }
                     }
               
        }



    }


    protected void butt_ok_Click1(object sender, EventArgs e)
    {
        //把文本框中的数据存入数组中，然后读取数组中的数据
        string str = Text_nr.Text;
        string[] sItems = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"); for (int i = 0; i < sItems.Length; i++)
        {
            sw.WriteLine(sItems[i]);
        }
        sw.Close();
        function_all.TiaoZhuan("导出成功", "sjgl.aspx?p=" + p + "&c=" + c, 0);

    }
    protected void butt_ok_Click2(object sender, EventArgs e)
    {
        function_all.TiaoZhuan("", "shoudonng.aspx", 0);
    }
}

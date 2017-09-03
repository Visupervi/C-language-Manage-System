using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

public partial class admin_shoudonng : System.Web.UI.Page
{
    string sql;
    db_help obj;
    SqlDataReader rds = default(SqlDataReader);
    PagedDataSource pds;
    protected int p = 1;
    protected string c = "";
    protected string f_nav = "";
    protected string c_nav = "";
    protected string _nav_cla = "none_none";
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
        //
        function_all.adminLoginChack(0, "Default.aspx");
        c = Request.QueryString["c"];
        p = System.Convert.ToInt32(Request.QueryString["p"]);
        if (!IsPostBack)
        {
            drop_cla_bind();
            rep_list_bind();
        }
    }
    public void drop_cla_bind()
    {
        obj = new db_help();
        sql = "select * From txk order by txID";
        pds = obj.MPagedDataSource(sql, 0, 0);
        obj.Close();
        drop_cla.DataSource = pds;
        drop_cla.DataTextField = "stlx";
        drop_cla.DataValueField = "txbz";
        drop_cla.DataBind();

        for (int n = 0; n < drop_cla.Items.Count; n++)
        {
            if (System.Convert.ToString(drop_cla.Items[n].Value) == c)
            {
                drop_cla.Items[0].Selected = false;
                drop_cla.Items[n].Selected = true;
                break;
            }
        }
        c = drop_cla.SelectedValue;

    }
    public void rep_list_bind()
    {
        obj = new db_help();
        sql = "select stID,stlx,stnr,stsj from stk where(txbz='" + c + "') order by stID DESC";
        pds = obj.MPagedDataSource(sql, p, 10);
        obj.Close();
        Rep_list.DataSource = pds;
        Rep_list.DataBind();
        pega.pageNow = p;
        pega.pageTotle = pds.PageCount;
        pega.otherQuery = "&c=" + c;

    }
    protected void drop_cla_SelectedIndexChanged(object sender, EventArgs e)
    {

        function_all.adminLoginChack(0, "Default.aspx");
        function_all.TiaoZhuan("", "shoudonng.aspx?c=" + drop_cla.SelectedValue, 0);
        Response.End();
    }
    protected void Rep_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
        function_all.adminLoginChack(0, "Default.aspx");
        obj = new db_help();
        if (e.CommandName == "dele")
        {
           
            sql = "delete from stk where(stID=" + e.CommandArgument + ")";
            obj.ExecNonSql(sql);
            function_all.TiaoZhuan("删除成功", "shoudonng.aspx?p=" + p + "&c=" + c, 0);
        }
        if (e.CommandName == "tianjia")
        {
            //可以用if语句来实现分类查询

            sql = "select stnr from stk where(stID="+e.CommandArgument+")";
            rds = obj.ExecReaderSql(sql);
            if (rds.Read())
            {
                if (!Convert.IsDBNull(rds["stnr"]))
                {
                   // Text_nr.Text = "First Line\r\nSecond Line\r\nThird Line";
                    Text_nr.Text = rds["stnr"].ToString();
                   //Server.HtmlEncode(br);
                }
            }
           
          
                Text_nr.Text = rds["stnr"].ToString();
               
            
            
        }
    }
    protected void butt_ok_Click(object sender, EventArgs e)
    {
        string str = Text_nr.Text;
        string[] sItems = str.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //StreamWriter sw = new StreamWriter("F:\\shiti.txt");
        StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
        for (int i = 0; i < sItems.Length; i++)
        {
            sw.WriteLine(sItems[i]);
        }
        sw.Close();
        function_all.TiaoZhuan("导出成功", "shoudonng.aspx?p=" + p + "&c=" + c, 0);

    }
    
}
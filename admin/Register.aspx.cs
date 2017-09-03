using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class admin_Register : System.Web.UI.Page
{
    db_help obj;
    SqlDataReader rds;
    protected int a = 0;
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
        this.Load += new System.EventHandler(Page_Load);
        if (_nav_cla != null)
        {
            string[] navs = _nav_cla.Split('_');
            f_nav = navs[0];
            c_nav = _nav_cla;
        }
    }

    //用户密码注册
    protected void butt_ok_Click1(object sender, System.EventArgs e)
    {
        string sql = "";
        string adm = System.Convert.ToString(text_adm.Text);
        string npw = System.Convert.ToString(text_npw.Text);
        obj = new db_help();
        //sql = "insert into T_user (U_name,U_password) values ( '"+ adm+ "','" + npw + "'）";
         sql = "Insert into T_user(U_name, U_password) values('"+adm+"','"+npw+"')";
        obj.ExecNonSql(sql);
        obj.Close();
        function_all.TiaoZhuan("注册成功，请登录！", "Default.aspx", 0);
         
  
    }


}


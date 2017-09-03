using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class admin_password : System.Web.UI.Page
{
    string sql;
    db_help obj;
    SqlDataReader rds;
    protected int a = 0;
    protected string f_nav ="";
    protected string c_nav ="";
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
        //
        function_all.adminLoginChack(0, "Default.aspx");

        a = System.Convert.ToInt32(Session["aid"]);
        if (!IsPostBack)
        {
            controls_bind();
        }

    }
    //用户名匹配
    public void controls_bind()
    {
        obj = new db_help();
        sql = "SELECT UserName FROM admin ";
        rds = obj.ExecReaderSql(sql);
        if (rds.Read())
        {
            if (Convert.IsDBNull(rds["UserName"])==null)
            {
                text_adm.Text = System.Convert.ToString(rds["UserName"]);
            }
        }
        rds.Close();
        obj.Close();
    }
    //用户密码匹配与密码修改
    protected void butt_ok_Click1(object sender, System.EventArgs e)
    {
        function_all.adminLoginChack(0, "Default.aspx");

        string ers = null;
        string adm = System.Convert.ToString(text_adm.Text.Trim());
        string opw = System.Convert.ToString(text_opw.Text);
        string npw = System.Convert.ToString(text_npw.Text);
        string spw = System.Convert.ToString(text_spw.Text);

        Regex umReg = new Regex("^[A-Za-z0-9]{1,50}$");
        if (!umReg.IsMatch(adm))
        {
            ers = "管理员账号不能为空，最大支持50个字符，可以是0-9、a-z、A-Z的组合";
        }

        if (string.IsNullOrEmpty(ers))
        {
            if (opw.Length <= 0 || npw.Length <= 0 ||spw.Length <= 0)
            {
                ers = "密码不能为空";
            }
            else
            {
                if (npw != spw)
                {
                    ers = "两次输入的新密码不一样";
                }
            }
        }
        if (string.IsNullOrEmpty(ers))
        {
            string dbpwd ="";

            obj = new db_help();
            sql = "SELECT PassWord FROM admin"; 
            rds = obj.ExecReaderSql(sql);
            if (rds.Read())
            {
                if (!Convert.IsDBNull(rds["PassWord"]))
                {
                    dbpwd = System.Convert.ToString(rds["PassWord"]);
                }
            }
            rds.Close();
            obj.Close();

            if (opw != dbpwd)
            {
                ers = "原密码不正确";
            }
        }

        if (string.IsNullOrEmpty(ers))
        {
            obj = new db_help();
            sql = "UPDATE admin SET UserName = '" + adm + "', PassWord = '" + npw + "' ";
            obj.ExecNonSql(sql);
            obj.Close();

            function_all.TiaoZhuan("密码修改成功，下次登录生效！", "welcome.aspx", 0);
            Response.End();
        }
        else
        {
            function_all.TiaoZhuan(ers, "password.aspx", 0);

            Response.End();
        }
    }
}


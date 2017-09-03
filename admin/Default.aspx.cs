using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Configuration;
public partial class Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改
    /// 此方法的内容。
    /// </summary>

    protected void butt_log_Click(object sender, EventArgs e)
    {
       
        string sql = "";
        db_help obj = new db_help();
        SqlDataReader rds = default(SqlDataReader);
        string gadm = "";
        string gpwd = "";
        gadm = System.Convert.ToString(text_adm.Text);
        gpwd = System.Convert.ToString(text_pwd.Text);
        //判断用户输出是否为空或者过长
        if (gadm.Length <= 0 || gpwd.Length <= 0)
        {
            function_all.TiaoZhuan("用户名/密码不能为空", "Default.aspx", 0);
            Response.End();
        }
        int bdid = 0;
        string dbpwd = "";
        sql = "Select * from T_user where U_name ='" + gadm + "' and U_password ='" + gpwd + "'";
        rds = obj.ExecReaderSql(sql);
        if (rds.Read())
        {
            Session["aid"] = rds.GetValue(rds.GetOrdinal("U_name"));//获取该用户名
            Session["aid"] = rds.GetValue(rds.GetOrdinal("U_password"));//获取该用户密码
            Page.Response.Redirect("welcome.aspx");
            rds.Close();
            rds.Close();
        }
        else
        {
            function_all.TiaoZhuan("账号/密码错误", "Default.aspx", 0);//提示
            Response.End();
        }

        //文本框中输入的账号和密码与session存储的数据比对

        if (gpwd == dbpwd)
        {
            Session["aid"] = bdid;
            HttpCookieCollection myCookieCollection = new HttpCookieCollection();
            //HttpCookie类专门由C#用于读取和写入Cookie的类。
            HttpCookie cstgl = new HttpCookie("cstgl");
            cstgl.Value = DateTime.Now.ToString();
            myCookieCollection.Add(cstgl);
            Response.AppendCookie(cstgl);

        }
        else
        {
            function_all.TiaoZhuan("账号/密码错误", "Default.aspx", 0);
            Response.End();
        }
    }
    protected void butt_re_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Register.aspx"); ;
    }
}

    

        
    